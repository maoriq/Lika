using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ShopApp
{
    public partial class PaymentForm : Form
{
    private List<CartItem> cart;
    private Customer customer;
    private decimal totalAmount;

    public PaymentForm(List<CartItem> cart, Customer customer)
    {
        InitializeComponent();
        this.cart = cart;
        this.customer = customer;
        this.totalAmount = CalculateTotalAmount();

        lblTotal.Text = $"Общая сумма: {totalAmount:C}";
        cmbPayment.Items.AddRange(new object[] { "Наличные", "Карта", "Бонусы", "Комбинированная оплата" });
        cmbPayment.SelectedIndex = 0;

        // Проверяем сразу, хватит ли средств у покупателя
        CheckCustomerBalance();
    }

    private decimal CalculateTotalAmount()
    {
        decimal total = 0;
        
        foreach (var item in cart)
        {
            total += item.Product.IsWeighted 
                ? item.Product.Price * (decimal)item.Weight 
                : item.Product.Price * item.Quantity;
        }
        
        return total;
    }

    private void CheckCustomerBalance()
    {
        decimal totalAvailable = customer.CashBalance + customer.CardBalance + customer.BonusBalance;
        
        if (totalAvailable < totalAmount)
        {
            MessageBox.Show($"У покупателя недостаточно средств!\n" +
                          $"Необходимо: {totalAmount:C}\n" +
                          $"Доступно: {totalAvailable:C}", 
                          "Ошибка оплаты", 
                          MessageBoxButtons.OK, 
                          MessageBoxIcon.Warning);
            btnPay.Enabled = false;
        }
    }

    private bool ProcessPayment()
    {
        string paymentMethod = cmbPayment.SelectedItem.ToString();
        decimal remainingAmount = totalAmount;
        decimal bonusPayment = 0;
        decimal cardPayment = 0;
        decimal cashPayment = 0;

        // Всегда сначала списываем бонусы (максимально возможную сумму)
        if (customer.BonusBalance > 0)
        {
            bonusPayment = Math.Min(customer.BonusBalance, remainingAmount);
            remainingAmount -= bonusPayment;
        }

        // Если осталась сумма и выбран соответствующий способ оплаты
        if (remainingAmount > 0)
        {
            if (paymentMethod == "Наличные")
            {
                if (customer.CashBalance >= remainingAmount)
                {
                    cashPayment = remainingAmount;
                    remainingAmount = 0;
                }
                else
                {
                    MessageBox.Show("Недостаточно наличных для полной оплаты!");
                    return false;
                }
            }
            else if (paymentMethod == "Карта")
            {
                if (customer.CardBalance >= remainingAmount)
                {
                    cardPayment = remainingAmount;
                    remainingAmount = 0;
                }
                else
                {
                    MessageBox.Show("Недостаточно средств на карте для полной оплаты!");
                    return false;
                }
            }
            else if (paymentMethod == "Комбинированная оплата")
            {
                // Сначала пробуем списать с карты, потом наличные
                cardPayment = Math.Min(customer.CardBalance, remainingAmount);
                remainingAmount -= cardPayment;

                if (remainingAmount > 0)
                {
                    if (customer.CashBalance >= remainingAmount)
                    {
                        cashPayment = remainingAmount;
                        remainingAmount = 0;
                    }
                    else
                    {
                        MessageBox.Show("Недостаточно средств для полной оплаты!");
                        return false;
                    }
                }
            }
        }

        if (remainingAmount > 0)
        {
            MessageBox.Show("Не удалось полностью оплатить заказ!");
            return false;
        }

        // Обновляем балансы
        customer.BonusBalance -= bonusPayment;
        customer.CardBalance -= cardPayment;
        customer.CashBalance -= cashPayment;

        // Сохраняем в БД
        return SaveCustomerBalance(cashPayment, cardPayment, bonusPayment, customer.Id);
    }

    private bool SaveCustomerBalance(decimal cash, decimal card, decimal bonus, int customerId)
    {
        string connStr = "server=localhost;user=root;database=shopdb;password=root;port=8889";

        try
        {
            using (var connection = new MySqlConnection(connStr))
            {
                connection.Open();
                
                string sql = @"UPDATE customers 
                              SET cash_balance = cash_balance - @cash,
                                  card_balance = card_balance - @card,
                                  bonus_balance = bonus_balance - @bonus
                              WHERE id = @id";

                using (var cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@cash", cash);
                    cmd.Parameters.AddWithValue("@card", card);
                    cmd.Parameters.AddWithValue("@bonus", bonus);
                    cmd.Parameters.AddWithValue("@id", customerId);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при сохранении баланса: {ex.Message}", "Ошибка", 
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

        private void btnPay_Click(object sender, EventArgs e)
        {
            // Сохраняем балансы до оплаты
            decimal initialBonus = customer.BonusBalance;
            decimal initialCard = customer.CardBalance;
            decimal initialCash = customer.CashBalance;

            if (ProcessPayment())
            {
                // Вычисляем списанные суммы
                decimal bonusSpent = initialBonus - customer.BonusBalance;
                decimal cardSpent = initialCard - customer.CardBalance;
                decimal cashSpent = initialCash - customer.CashBalance;

                MessageBox.Show("Оплата прошла успешно!\n" +
                              $"Бонусов списано: {bonusSpent:C}\n" +
                              $"С карты списано: {cardSpent:C}\n" +
                              $"Наличными списано: {cashSpent:C}",
                              "Успешно",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
