using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.ConsoleApp.Models
{
    public class ShoppingCart
    {
        private Dictionary<string, int> _items = new(); // Product ID -> Quantity
        private readonly Inventory _inventory;  // Reference to inventory to check stock

        public ShoppingCart(Inventory inventory)
        {
            _inventory = inventory;
        }

        public bool AddItem(string productId, int quantity)
        {
            var product = _inventory.GetProduct(productId);
            if (product == null || product.Quantity < quantity)
            {
                return false;
            }

            if (_items.ContainsKey(productId))
            {
                _items[productId] += quantity;
            }
            else
            {
                _items[productId] = quantity;
            }

            product.Quantity -= quantity;
            return true;
        }

        public bool RemoveItem(string productId, int quantity)
        {
            if (!_items.ContainsKey(productId)) return false;

            if (_items[productId] < quantity)
            {
                return false;
            }

            _items[productId] -= quantity;
            var product = _inventory.GetProduct(productId);
            product.Quantity += quantity;

            if (_items[productId] == 0)
            {
                _items.Remove(productId);
            }

            return true;
        }

        public Dictionary<string, int> GetItems()
        {
            return new Dictionary<string, int>(_items);
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in _items)
            {
                var product = _inventory.GetProduct(item.Key);
                total += product.Price * item.Value;
            }
            return total;
        }

        public void Clear()
        {
            _items.Clear();
        }
    }
}
