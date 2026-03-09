using System;
using System.Reflection.Metadata.Ecma335;

class PaymentStrategy
{
    public virtual bool Pay(decimal amount)
    {
        return false;
    }
}

class CreditCartdPayment : PaymentStrategy
{
    public override bool Pay(decimal amount)
    {
        Console.WriteLine("payment by card...");
        Console.WriteLine("Card rejected!");
        return false;
    }
}

class PayPalPayment : PaymentStrategy
{
    public override bool Pay(decimal amount)
    {
        Console.WriteLine("Payment via PayPal was successful\r\n");
        return true;
    }
}

class PashPayment : PaymentStrategy
{
    public override bool Pay(decimal amount)
    {
        Console.WriteLine("Payment in cash upon receipt.\r\n");
        return true;
    }
}

class Order
{
    public decimal Amount;
    public PaymentStrategy Payment;

    public bool Checkout()
    {
        return Payment.Pay(Amount);
    }
}

class Program
{
    static void Main()
    {
        Order order = new Order();
        order.Amount = 300;

        Console.WriteLine("Order amount:" + order.Amount);
        Console.WriteLine("1 - card");
        Console.WriteLine("2 - PayPal");
        Console.WriteLine("3 - Cash");

        int choice = int.Parse(Console.ReadLine());

        if (choice == 1) order.Payment = new CreditCartdPayment();
        if (choice == 2) order.Payment = new PayPalPayment();
        if (choice == 3) order.Payment = new PashPayment();

        bool result = order.Checkout();

        if(!result)
        {
            Console.WriteLine("Let's try PayPal...");
            order.Payment = new PayPalPayment();
            order.Checkout();
        }
    }
}