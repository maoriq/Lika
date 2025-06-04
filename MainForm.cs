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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private Customer selectedCustomer;

        private void btnEnterShop_Click(object sender, EventArgs e)
        {
            if (selectedCustomer == null)
            {
                MessageBox.Show("Сначала выберите покупателя в настройках.");
                return;
            }

            var shopForm = new ShopForm(selectedCustomer);
            this.Hide();
            shopForm.ShowDialog();
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm(selectedCustomer);
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                selectedCustomer = settingsForm.SelectedCustomer;
                MessageBox.Show($"Выбран покупатель: {selectedCustomer.Name}", "Настройки", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
