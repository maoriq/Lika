using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace ShopApp
{

    public class ProductRepository
    {
        private string connectionString = "server=localhost;user=root;database=shopdb;password=root;port=8889";

        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM products", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("name"),
                        Price = reader.GetDecimal("price"),
                        IsWeighted = reader.GetBoolean("is_weighted"),
                        Weight = null // вручную вводится при взвешивании
                    });
                }
            }

            return products;
        }
    }

}
