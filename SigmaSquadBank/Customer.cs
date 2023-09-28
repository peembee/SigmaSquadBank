﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SigmaSquadBank
{
    public class Customer : User
    {
        private double bankLoan;
        private double wallet;
        public bool debtToBank = false;
        private string adress;
        public bool lockedOut = false;
        private int passwordTries = 3;

        public List<BankAccount> bankAccList = new List<BankAccount>();
        public List<SavingAccount> saveAccList = new List<SavingAccount>();
        BankLoan newLoan = new BankLoan();

        public int ChangePasswordTries
        {
            get
            {
                return passwordTries;
            }
            set
            {
                passwordTries = value;
            }
        }
        public double BankLoan
        {
            get { return bankLoan; }
            set { bankLoan = value; }
        }
        public double Wallet
        {
            get
            { return wallet; }
            private set
            { wallet = value; }
        }
        public bool LockedOut
        {
            get
            {
                return lockedOut;
            }
            set
            {
                lockedOut = value;
            }
        }
        public string Password
        {
            get
            { return password; }
            set
            { password = value; }
        }
        public int IdNumber
        {
            get
            { return id; }
            set
            { id = value; }
        }

        public Customer(string Name, string adress, int Age, int idNumber, string password, double wallet, bool locked = false)
        {
            this.Name = Name;
            this.adress = adress;
            this.Age = Age;
            this.id = idNumber;
            this.password = password;
            this.wallet = wallet;
            IsAdmin = false;
            this.lockedOut = locked;
        }

        public bool Login(string username, string password)
        {
            return this.Name == username && this.password == password;
        }


        private double totalMoney()
        {
            double totalMoney = 0;
            foreach (var getMoney in saveAccList)
            {
                totalMoney += getMoney.Deposit;
            }
            foreach (var getMoney in bankAccList)
            {
                totalMoney += getMoney.Balance;
            }
            totalMoney += wallet;
            return totalMoney;
        }
        public int PasswordTries(bool readPasswordTries = false) // this function will be called when user entered wrong password. Password decreases with 1. then getting locked. : Or just read value of passwordTries
        {
            if (readPasswordTries == false)
            {
                passwordTries--;
            }
            if (passwordTries <= 0)
            {
                passwordTries = 0;
                lockedOut = true;
            }
            return passwordTries;
        }
        public void AddNewBankAccount()
        {
            string accountName = "";
            int accountNumber = 0;
            double balance = 0;
            while (true)
            {
                bool breakeLoop = true;
                Console.Clear();
                Console.Write("Account name: ");
                accountName = Console.ReadLine();
                accountName = accountName.ToLower();
                accountName = accountName.Trim();
                if (accountName.Length > 2 && accountName.Length < 11)
                {
                    accountName = char.ToUpper(accountName[0]) + accountName.Substring(1);
                    if (bankAccList.Count >= 1)
                    {
                        foreach (var bankAcc in bankAccList)
                        {
                            if (accountName == bankAcc.BankAccountName)
                            {
                                breakeLoop = false;
                            }
                        }
                    }
                    if (breakeLoop == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You can't have the same name as another bankaccount");
                        System.Threading.Thread.Sleep(1500);
                    }
                }
                else
                {
                    Console.WriteLine("Minimum 3 Characters");
                    Console.WriteLine("Max 10 Characters");
                    System.Threading.Thread.Sleep(1000);
                }
            }

            accountNumber = getBankAccountNumber();

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("--------");
                Console.WriteLine("Wallet: " + wallet);
                Console.WriteLine("--------");
                Console.ResetColor();
                Console.Write("Account balance: ");
                try
                {
                    balance = Convert.ToDouble(Console.ReadLine());
                    if (wallet >= balance)
                    {
                        wallet -= balance;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You wallet only contains $" + wallet);
                        System.Threading.Thread.Sleep(1500);
                    }
                }
                catch (Exception)
                {

                    // do nothing
                }
            }

            Console.Clear();
            Console.WriteLine("New account has been added");
            bankAccList.Add(new BankAccount(accountName, accountNumber, balance));
            System.Threading.Thread.Sleep(1000);
        }
        public void AddSavingAccount()
        {
            string accountName = "";
            int accountNumber;
            double deposit;
            Console.Clear();
            while (true)
            {
                bool breakeLoop = true;
                Console.Clear();
                Console.Write("Account name: ");
                accountName = Console.ReadLine();
                accountName = accountName.ToLower();
                accountName = accountName.Trim();
                if (accountName.Length > 2 && accountName.Length < 11)
                {
                    accountName = char.ToUpper(accountName[0]) + accountName.Substring(1);
                    if (saveAccList.Count >= 1)
                    {
                        foreach (var bankAcc in saveAccList)
                        {
                            if (accountName == bankAcc.BankAccountName)
                            {
                                breakeLoop = false;
                            }
                        }
                    }
                    if (breakeLoop == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You can't have the same name as another bankaccount");
                        System.Threading.Thread.Sleep(1500);
                    }
                }
                else
                {
                    Console.WriteLine("Minimum 3 Characters");
                    Console.WriteLine("Max 10 Characters");
                    System.Threading.Thread.Sleep(1000);
                }
            }
            accountNumber = getBankAccountNumber();

            while (true)
            {
                Console.Clear();
                Console.Write("Amount to deposit: ");
                try
                {
                    deposit = Convert.ToDouble(Console.ReadLine());
                    if (wallet >= deposit)
                    {
                        wallet -= deposit;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You wallet only contains $" + wallet);
                        System.Threading.Thread.Sleep(1500);
                    }
                }
                catch (Exception)
                {
                    // do nothing
                }
            }
            Console.Clear();
            Console.Write("The current interest rate will be 30%. Do you wish to continue? (Y/N)");
            var keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Y || keyPressed.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("New saving account has been added.");
                addSaveAccountToList(accountName, accountNumber, deposit);
            }
            else
            {
                wallet += deposit;
            }
            System.Threading.Thread.Sleep(1000);
        }

        public void addSaveAccountToList(string accountName, int accountNumber, double deposit)
        {
            saveAccList.Add(new SavingAccount(accountName, accountNumber, deposit));
        }

        public void AddLoan()
        {
            Console.Clear();
            if (debtToBank == true)
            {
                Console.WriteLine("You already have a mortgage");
            }
            else
            {
                double loan;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("The max loan you will get is: $" + totalMoney() * 5);
                    Console.Write("How much do you want to borrow? ");
                    loan = Convert.ToDouble(Console.ReadLine());
                    if (loan > totalMoney() * 5)
                    {
                        Console.WriteLine("The loan is to high for you.");
                        System.Threading.Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("The mortgage that you want will have 30% interest rate and you will have to pay $" + newLoan.Loan(loan));
                        break;
                    }
                }
                Console.WriteLine("Do you want to borrow money? (Y/N)");
                var KeyPressed = Console.ReadKey();
                Console.Clear();
                if (KeyPressed.Key == ConsoleKey.Y)
                {
                    bankLoan = newLoan.Loan(loan);
                    debtToBank = true;
                    Console.WriteLine("The mortgage is accepted");
                }
                else
                {
                    Console.WriteLine("Welcome back!");
                }
            }
            System.Threading.Thread.Sleep(1000);
        }
        public void DisplaySaveAccount()
        {
            Console.Clear();
            if (saveAccList.Count == 0)
            {
                Console.WriteLine("You dont have any Saving-Account..");
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                foreach (var savingAccounts in saveAccList)
                {
                    Console.WriteLine(savingAccounts);
                    Console.WriteLine("---------------");
                }
                Console.WriteLine("Key for menu..");
                Console.ReadKey();
            }
        }
        public void DisplayBankLoan()
        {
            Console.Clear();
            if (debtToBank == false)
            {
                Console.WriteLine("You don't have any loan on this bank..");
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Total loan: $" + bankLoan);
                System.Threading.Thread.Sleep(1500);
            }
        }
        public void AllTransactionOnCustomer()
        {
            Console.Clear();
            if (bankAccList.Count == 0)
            {
                Console.WriteLine("You don't have any transactions..");
            }
            else
            {
                foreach (var transaction in bankAccList)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Bank-Account: " + transaction.BankAccountName + ":");
                    Console.ResetColor();
                    Console.WriteLine(transaction.displayAllTransactionsFromBankAccount());
                }
            }
            Console.WriteLine("\nKey for menu..");
            Console.ReadKey();
        }
        public void DisplayAllBankAndSavingAccount()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Bank-Accounts");
            Console.ResetColor();
            Console.WriteLine("------------------");
            if (bankAccList.Count == 0)
            {
                Console.WriteLine("You dont have any Bank-Accounts");
                Console.WriteLine("------------------\n");
            }
            else
            {
                foreach (var bankAccount in bankAccList)
                {
                    Console.WriteLine(bankAccount);
                    Console.WriteLine("------------------");
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nSaving-Accounts");
            Console.ResetColor();
            Console.WriteLine("------------------");
            if (saveAccList.Count == 0)
            {
                Console.WriteLine("You dont have any Saving-Accounts");
                Console.WriteLine("------------------\n");
            }
            else
            {
                foreach (var saveAccounts in saveAccList)
                {
                    Console.WriteLine(saveAccounts);
                    Console.WriteLine("------------------");
                }
            }
            Console.WriteLine("Key for menu..");
            Console.ReadKey();
        }
        public void TransferMoneyBetweenBankAccounts()
        {
            string getAccount;
            string toAccount;
            double withdraw = 0;
            Console.Clear();
            if (bankAccList.Count <= 1)
            {
                Console.WriteLine("You need to have atleast two bankaccounts to do transfers");
                Console.WriteLine("Key for menu..");
                Console.ReadKey();
            }
            else
            {
                while (true)
                {
                    bool breakLoop = false;
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("--------------------------");
                        foreach (var bankaccounts in bankAccList)
                        {
                            Console.WriteLine(bankaccounts.BankAccountName + ": $" + bankaccounts.Balance);
                        }
                        Console.WriteLine("--------------------------");
                        Console.Write("Which Bank-Account would you like withdraw from: ");
                        getAccount = Console.ReadLine();
                        getAccount = getAccount.Trim();
                        getAccount = getAccount.ToLower();

                        if (getAccount.Length > 0)
                        {
                            getAccount = char.ToUpper(getAccount[0]) + getAccount.Substring(1);
                            break;
                        }
                    }
                    foreach (var bankaccounts in bankAccList)
                    {
                        if (getAccount == bankaccounts.BankAccountName)
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Balance $: " + bankaccounts.Balance.ToString());
                                Console.Write("Enter amount to withdraw: ");
                                try
                                {
                                    withdraw = Convert.ToDouble(Console.ReadLine());
                                    if (withdraw <= bankaccounts.Balance)
                                    {
                                        bankaccounts.Withdraw(withdraw);
                                        breakLoop = true;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You can't withdraw more than you have in " + bankaccounts.BankAccountName + ", Try again");
                                    }
                                }
                                catch (Exception)
                                {
                                    // Do nothing
                                }
                            }
                        }
                    }
                    if (breakLoop == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Did not find any Bankaccount with that name");
                        System.Threading.Thread.Sleep(1500);
                    }
                }

                while (true)
                {
                    bool breakLoop = false;
                    Console.Clear();
                    Console.WriteLine("--------------------------");
                    foreach (var bankaccounts in bankAccList)
                    {
                        Console.WriteLine(bankaccounts.BankAccountName);
                    }
                    Console.WriteLine("--------------------------");
                    Console.Write("Which Bank-Account would you like to deposit to: ");
                    toAccount = Console.ReadLine();
                    toAccount = toAccount.Trim();
                    toAccount = toAccount.ToLower();

                    if (toAccount.Length > 0)
                    {
                        toAccount = char.ToUpper(toAccount[0]) + toAccount.Substring(1);
                        if (toAccount == getAccount)
                        {
                            Console.WriteLine("You cant transfer to the same account.");
                            System.Threading.Thread.Sleep(1500);
                        }
                        else
                        {
                            foreach (var bankaccounts in bankAccList)
                            {
                                if (toAccount == bankaccounts.BankAccountName)
                                {

                                    bankaccounts.GetMoney(withdraw);
                                    breakLoop = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (breakLoop == true)
                    {
                        break;
                    }
                    else if (toAccount != getAccount)
                    {
                        Console.WriteLine("Did not find the Account, try again..");
                        System.Threading.Thread.Sleep(1500);
                    }
                }
                Console.WriteLine("Transaction succeed..");
                System.Threading.Thread.Sleep(1500);
            }
        }
        private int getBankAccountNumber()
        {
            Random rnd = new Random();
            string getBankAccountNumber = "";
            int bankAccountNumber;
            bool breakeLoop = true;
            while (true)
            {
                for (int i = 0; i < 5; i++)
                {
                    getBankAccountNumber += rnd.Next(1, 10);
                }
                bankAccountNumber = Convert.ToInt32(getBankAccountNumber);
                if (bankAccList.Count >= 1)
                {
                    foreach (var accountNumber in bankAccList)
                    {
                        if (bankAccountNumber == accountNumber.BankAccountNumber)
                        {
                            breakeLoop = false;
                        }
                    }
                }
                if (saveAccList.Count >= 1)
                {
                    foreach (var accountNumber in saveAccList)
                    {
                        if (bankAccountNumber == accountNumber.BankAccountNumber)
                        {
                            breakeLoop = false;
                        }
                    }
                }
                if (breakeLoop == true)
                {
                    break;
                }
            }
            return bankAccountNumber;
        }
        public override string ToString()
        {
            return Name + "\nAge: " + Age + "\nAdress: " + adress + "\nID: " + id + "\nPassword: " + password;
        }
    }
}
