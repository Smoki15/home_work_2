using StockApp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace StockApp
{
    internal class Stock
    {
        public List<Product> Products = new List<Product>();

        public void Add(Product product) 
        {
            Products.Add(product);
        }

        public void Remove(Product product)
        {
            Products.Remove(product);
        }
    }
}
