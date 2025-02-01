using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.ConsoleApp.Models
{
    public class Inventory
    {
        private List<Product> _products = new();

        public bool AddProduct(string name, decimal price, int quantity, string description)
        {
            if (price < 0 || quantity < 0)
            {
                return false;
            }

            var product = new Product(name, price, quantity, description);
            _products.Add(product);
            return true;
        }

        public bool UpdateProduct(string id, string name, decimal price, int quantity, string description)
        {
            var product = GetProduct(id);
            if (product == null || price < 0 || quantity < 0)
            {
                return false;
            }

            product.Name = name;
            product.Price = price;
            product.Quantity = quantity;
            product.Description = description;
            return true;
        }

        public bool RemoveProduct(string id)
        {
            var product = GetProduct(id);
            if (product == null)
            {
                return false;
            }

            return _products.Remove(product);
        }

        public Product GetProduct(string id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetAllProducts()
        {
            return new List<Product>(_products);
        }

        // Helper method to initialize some sample products
        public void InitializeDefaultProducts()
        {
            AddProduct("Laptop", 999.99m, 10, "High-performance laptop");
            AddProduct("Mouse", 29.99m, 20, "Wireless gaming mouse");
            AddProduct("Keyboard", 59.99m, 15, "Mechanical keyboard");
            AddProduct("Monitor", 299.99m, 5, "27-inch 4K monitor");
            AddProduct("Headphones", 79.99m, 25, "Noise-cancelling headphones");
        }
    }
}
