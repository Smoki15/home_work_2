
class AccountEventArgs
{
    public DateTime Date { get; set; }
    public string User { get; set; }
    public decimal Amount { get; set; }
}

class Account
{
    public delegate void AccountHandler(AccountEventArgs e);

    public event AccountHandler OnAdded;
    public event AccountHandler OnWithdrawen;

    public string Owner { get; set; }
    public decimal Balance { get; private set; }

    public void Add(decimal amount)
    {
        Balance += amount;

        OnAdded?.Invoke(new AccountEventArgs
        {
            Date = DateTime.Now,
            User = Owner,
            Amount = amount
        });
    }

    public void Withdraw(decimal amount)
    {
        if(amount > Balance)
        {
            Console.WriteLine("Insufficient funds");
            return;
        }

        Balance -= amount;

        OnWithdrawen?.Invoke(new AccountEventArgs
        {
            Date = DateTime.Now,
            User = Owner,
            Amount = amount
        });
    }
}

class Logger
{
    public void OnAddedHandler(AccountEventArgs e)
    {
        Console.WriteLine($"[+] {e.Date} | {e.User} topped up the account {e.Amount}");
    }

    public void OnWithdrawHandler(AccountEventArgs e)
    {
        Console.WriteLine($"[-] {e.Date} | {e.User} withdrawn from account {e.Amount}");
    }
}

class Program
{
    static void Main()
    {
        Account acc = new Account { Owner = "Danil" };
        Logger logger = new Logger();

        acc.OnAdded += logger.OnAddedHandler;
        acc.OnWithdrawen += logger.OnWithdrawHandler;

        acc.Add(1000);
        acc.Withdraw(300);
        acc.Withdraw(800); 

        Console.WriteLine($"Баланс: {acc.Balance}");
    }

}