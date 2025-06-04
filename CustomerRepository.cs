using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ShopApp
{
    public class CustomerRepository
    {
        private string connStr = "server=localhost;user=root;database=shopdb;password=root;port=8889";

        public List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();

            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM customers", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("name"),
                        CashBalance = reader.GetDecimal("cash_balance"),
                        CardBalance = reader.GetDecimal("card_balance"),
                        BonusBalance = reader.GetDecimal("bonus_balance")
                    });
                }
            }

            return customers;
        }
    }
}
