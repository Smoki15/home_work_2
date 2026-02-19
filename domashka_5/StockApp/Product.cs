using System;
using System.Collections.Generic;
using System.Text;

namespace StockApp
{
    internal class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Product(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
