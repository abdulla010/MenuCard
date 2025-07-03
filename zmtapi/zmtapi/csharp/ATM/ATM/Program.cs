using System;
using System.Collections.Generic; // Added to use List<>.

public class CardHolder
{
    private string cardNum;
    private int pin;
    private string firstName;
    private string lastName;
    private double balance;

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string GetCardNum() // Updated method names to follow C# naming conventions.
    {
        return cardNum;
    }

    public int GetPin()
    {
        return pin;
    }

    public string GetFirstName()
    {
        return firstName;
    }

    public string GetLastName()
    {
        return lastName;
    }

    public double GetBalance()
    {
        return balance;
    }

    public void SetCardNum(string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void SetPin(int newPin)
    {
        pin = newPin;
    }

    public void SetFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void SetLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void SetBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(string[] args)
    {
        void PrintOptions()
        {
            Console.WriteLine("Please choose from one of the following options");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void Deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit?");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.SetBalance(currentUser.GetBalance() + deposit);
            Console.WriteLine("Thank you for your money. Your new balance is: " + currentUser.GetBalance());
        }

        void Withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw?");
            double withdrawal = double.Parse(Console.ReadLine());
            if (currentUser.GetBalance() < withdrawal) // Corrected the condition here.
            {
                Console.WriteLine("Insufficient Balance :(");
            }
            else
            {
                currentUser.SetBalance(currentUser.GetBalance() - withdrawal);
                Console.WriteLine("You are good to go! Thank you :)");
            }
        }

        void ShowBalance(CardHolder currentUser) // Renamed the method to avoid conflicts with variable names.
        {
            Console.WriteLine("Current balance: " + currentUser.GetBalance());
        }

        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("4532772818527395", 1234, "John", "Griffith", 150.31));
        cardHolders.Add(new CardHolder("4532761841325802", 4321, "Ashley", "Jones", 321.13));
        cardHolders.Add(new CardHolder("5128381368581872", 9999, "Frida ", "Dickerson", 105.59));
        cardHolders.Add(new CardHolder("6011188364697109", 2468, "Muneeb", "Harding", 851.84));
        cardHolders.Add(new CardHolder("3490693153147110", 4826, "Dawn", "Smith", 54.27));

        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card:");
        string debitCardNum = "";
        CardHolder currentUser = null;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.Find(a => a.GetCardNum() == debitCardNum); // Fixed the Find method.
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");
            }
        }

        Console.WriteLine("Please enter your pin:");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.GetPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect pin. Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect pin. Please try again");
            }
        }

        Console.WriteLine("Welcome, " + currentUser.GetFirstName() + ":)");
        int option = 0;
        do
        {
            PrintOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch 
            {
                option = 0;
            }
            if (option == 1)
            {
                Deposit(currentUser);
            }
            else if (option == 2)
            {
                Withdraw(currentUser);
            }
            else if (option == 3)
            {
                ShowBalance(currentUser);
            }
            else if (option == 4)
            {
                break;
            }
            else
            {
                option = 0;
            }
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :)");
    }
}
