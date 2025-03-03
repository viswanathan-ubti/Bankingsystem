using System;

namespace Bankingsystem
{
    // Account structure
    struct Account
    {
        // Field to store account holder details
        public string Accountholder;
        public string Accountnumber;
        public string Bankname;
        public decimal Balance; 

        // Method to deposit amount into the account
        public void Deposit(decimal amount)
        {
            try
            {
            Balance += amount;
            Console.WriteLine("Deposited: " + amount);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Deposited amount successfully");
            }
        }

        // Method to Withdraw amount from the account
        public void Withdraw(decimal amount)
        {
            try
            {
                // Check the withdraw amount is less than or equal to balance amount
                if (amount <= Balance)
                {
                    Balance -= amount;
                    Console.WriteLine("Withdraw: " + amount);
                }
                // If withdraw amount is greater than balance then print Insufficient Balance
                else
                {
                    Console.WriteLine("Insufficient Balance");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("withdraw operation completed...");
            }

        }

        // Method to Inquriy or display the account details
        public void BalanceInquiry()
        {
            Console.WriteLine("Account Holder: " + Accountholder);
            Console.WriteLine("Account Number: " + Accountnumber);
            Console.WriteLine("Bank Name: " + Bankname);
            Console.WriteLine("Current Balance: " + Balance);
        }
    }

    // class for bankingsystem
    class Bankingsystem
    {
        // Main method
        static void Main(string[] args)
        {
            // Initialize account with default values
            Account myaccount = new Account();
            myaccount.Accountholder = "viswa";
            myaccount.Accountnumber = "1234554513156";
            myaccount.Bankname = "HDFC";
            myaccount.Balance = 10000;

            bool exit = true;

            while (exit)
            {
                // display menu for users
                Console.WriteLine("Banking System");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Balance Inquiry");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                // handle the operation based on user choice
                switch (choice)
                {
                    case "1":
                        // For deposit operation
                        String Message = "Enter amount to deposit: ";
                        decimal depositamount = GetDecimalInput(Message);
                        myaccount.Deposit(depositamount);
                        break;
                    case "2":
                        // For withdraw operation
                        Message = "Enter amount to withdraw: ";
                        decimal withdrawamount = GetDecimalInput(Message);
                        myaccount.Withdraw(withdrawamount);
                        break;
                    case "3":
                        // For balance inquiry
                        myaccount.BalanceInquiry();
                        break;
                    case "4":
                        // For exit program
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option Please try again");
                        break;
                }
            }
        }
        // Method to prompt user for amount input with validation
        static decimal GetDecimalInput(String Message)
        {
            Console.Write(Message);
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.Write("Invalid amount entered Please enter valid amount: ");
            }
            return amount;
        }
    }
}