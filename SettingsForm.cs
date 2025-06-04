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
    public partial class SettingsForm : Form
    {
        private List<Customer> customers;
        public Customer SelectedCustomer { get; private set; }

        public SettingsForm(Customer currentCustomer = null)
        {
            InitializeComponent();
            LoadCustomers();

            if (currentCustomer != null)
            {
                int index = customers.FindIndex(c => c.Id == currentCustomer.Id);
                if (index >= 0) cmbCustomers.SelectedIndex = index;
            }
        }

        private void LoadCustomers()
        {
            var repo = new CustomerRepository();
            customers = repo.GetAllCustomers();

            cmbCustomers.Items.Clear();
            foreach (var c in customers)
            {
                cmbCustomers.Items.Add($"{c.Id} — {c.Name} | Нал: {c.CashBalance}₽, Карта: {c.CardBalance}₽, Бонусы: {c.BonusBalance}₽");
            }

            if (cmbCustomers.Items.Count > 0)
                cmbCustomers.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCustomers.SelectedIndex >= 0)
            {
                SelectedCustomer = customers[cmbCustomers.SelectedIndex];
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Выберите покупателя.");
            }
        }
    }
}

