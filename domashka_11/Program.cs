class Publisher
{
    public delegate void Notify(string message);

    public event Notify onNotify;

    public void DoSomething()
    {
        Console.WriteLine("Publisher: an event occurred!");

        onNotify?.Invoke("Hello be Publisher!");
    }
}

class SubscriberA
{
    public void Update(string message)
    {
        Console.WriteLine("SubscriberA received a message: " + message);
    }
}

class SubscriberB
{
    public void Update(string message)
    {
        Console.WriteLine("SubscriberB received a message: " + message);
    }
}

class Program
{
    static void Main()
    {
        Publisher publisher = new Publisher();

        SubscriberA subA = new SubscriberA();
        SubscriberB subB = new SubscriberB();

        publisher.onNotify += subA.Update;
        publisher.onNotify -= subB.Update;

        publisher.DoSomething();

        publisher.onNotify -= subA.Update;

        Console.WriteLine("\nAfter unsubscribes SubscriberA:\n");

        publisher.DoSomething();
    }
}