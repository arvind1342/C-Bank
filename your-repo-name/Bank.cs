using System;

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of a bank account
        BankAccount myAccount = new BankAccount("John Doe", 1000);

        Console.WriteLine("Welcome to the Bank Account System");

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nPlease choose an operation:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1/2/3/4): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter amount to deposit: ");
                    double depositAmount = Convert.ToDouble(Console.ReadLine());
                    myAccount.Deposit(depositAmount);
                    break;

                case 2:
                    Console.Write("Enter amount to withdraw: ");
                    double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                    myAccount.Withdraw(withdrawAmount);
                    break;

                case 3:
                    myAccount.CheckBalance();
                    break;

                case 4:
                    exit = true;
                    Console.WriteLine("Thank you for using the Bank Account System.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

// Base class: Account
public class Account
{
    public string Owner { get; set; }
    protected double Balance { get; set; }

    public Account(string owner, double balance)
    {
        Owner = owner;
        Balance = balance;
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Account Owner: {Owner}");
        Console.WriteLine($"Current Balance: {Balance:C}");
    }
}

// Derived class: BankAccount that extends Account
public class BankAccount : Account
{
    public BankAccount(string owner, double balance) : base(owner, balance) { }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited: {amount:C}. New Balance: {Balance:C}");
        }
        else
        {
            Console.WriteLine("Deposit amount must be greater than zero.");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount > 0)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew: {amount:C}. New Balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Insufficient funds for withdrawal.");
            }
        }
        else
        {
            Console.WriteLine("Withdrawal amount must be greater than zero.");
        }
    }
}
