using System;
using StockApp;
using RandomLib;


class Program
{     
    static void Main(string[] args)
    {
        Stock stock = new Stock();
        RandomStringGenerator stringGenerator = new RandomStringGenerator();
        RandomNumberGenerator numberGenerator = new RandomNumberGenerator();
        for(int i = 0; i < 10; i++)
        {
            string name = stringGenerator.Generate(5);
            int quantity = numberGenerator.Generate(1, 100);
            Product product = new Product(name, quantity);
            stock.Add(product);
        }
        foreach(var product in stock.Products)
        {
            Console.WriteLine($"Product: {product.Name}, Quantity: {product.Quantity}");
        }
    }
}