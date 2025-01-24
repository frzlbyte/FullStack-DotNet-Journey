using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.ConsoleApp.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public Product(string name, decimal price, int quantity, string description)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Price = price;
            Quantity = quantity;
            Description = description;
        }
    }
}
