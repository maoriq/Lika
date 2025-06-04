using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ShopApp
{
    public partial class ShopForm : Form
    {
        private List<Product> products;
        private List<CartItem> cart = new List<CartItem>();
        private ProductRepository productRepo = new ProductRepository();
        private Customer customer; // Покупатель
        public ShopForm(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            lblCustomerInfo.Text = $"Вы вошли как: {customer.Name} | 💵 Нал: {customer.CashBalance}₽ | 💳 Карта: {customer.CardBalance}₽ | 🎁 Бонусы: {customer.BonusBalance}₽";

            LoadProducts();
            UpdateCartDisplay();
        }

        private void UpdateCartDisplay()
        {
            lstCart.Items.Clear();
            foreach (var item in cart)
            {
                if (item.Product.IsWeighted)
                    lstCart.Items.Add($"{item.Product.Name} — {item.Weight} кг = {item.TotalPrice:0.00} ₽");
                else
                    lstCart.Items.Add($"{item.Product.Name} — {item.Quantity} шт. = {item.TotalPrice:0.00} ₽");
            }

            lblTotal.Text = $"Сумма: {cart.Sum(i => i.TotalPrice):0.00} ₽";
        }

        private void LoadProducts()
        {
            products = productRepo.GetAllProducts();
            dgvProducts.DataSource = products;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;

            var product = dgvProducts.CurrentRow.DataBoundItem as Product;

            if (product.IsWeighted)
            {
                if (!product.Weight.HasValue || product.Weight <= 0)
                {
                    MessageBox.Show("Сначала необходимо взвесить товар.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cart.Add(new CartItem { Product = product, Weight = product.Weight });
                product.Weight = null; // сбрасываем после добавления
            }
            else
            {
                cart.Add(new CartItem { Product = product, Quantity = 1 });
            }

            UpdateCartDisplay();

        }
        private void btnProceedToPayment_Click(object sender, EventArgs e)
        {
            this.Show();
            if (!cart.Any())
            {
                MessageBox.Show("Корзина пуста. Добавьте товары для оплаты.");
                return;
            }

            var paymentForm = new PaymentForm(cart, customer);
            this.Hide();
            paymentForm.ShowDialog();
            this.Show();

            // После оплаты корзину можно очистить
            cart.Clear();
            UpdateCartDisplay();
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            cart.Clear();
            UpdateCartDisplay();
        }

        private void btnWeighProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;

            var product = dgvProducts.CurrentRow.DataBoundItem as Product;

            if (!product.IsWeighted)
            {
                MessageBox.Show("Этот товар не требует взвешивания.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var weightForm = new WeightForm();
            if (weightForm.ShowDialog() == DialogResult.OK && weightForm.Weight.HasValue)
            {
                product.Weight = weightForm.Weight.Value;
                MessageBox.Show($"Вес {product.Name} установлен: {product.Weight} кг");
            }
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (lstCart.SelectedIndex >= 0 && lstCart.SelectedIndex < cart.Count)
            {
                cart.RemoveAt(lstCart.SelectedIndex);
                UpdateCartDisplay();
            }
        }
    }
}
