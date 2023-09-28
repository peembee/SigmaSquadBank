using SigmaSquadBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualTests
{
    public class ManualTest_DisplayAllBankaccountsAndSaveAccount
    {
        //First add accounts to bank, then return them and display them to Console.
        // --> if list being added with data, it should display the new data.

        public ManualTest_DisplayAllBankaccountsAndSaveAccount()
        {
            DisplayAllBankAccountsAndSaveAccounts();
        }

        public void DisplayAllBankAccountsAndSaveAccounts()
        {
            Customer customer = new Customer("Kalle", "Stengatan 1", 43, 1011, "hej", 2000);

            // There should 0 accounts.
            if (customer.saveAccList.Count == 0 && customer.bankAccList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nTest succeed");
                Console.WriteLine("There is no objects in the saveAccList and bankAccList, press Enter");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Test Failed");
            }
            Console.ReadKey();
            Console.WriteLine("\n---------------------------\n");

            // Adding data to Lists
            customer.saveAccList.Add(new SavingAccount("SaveAccount 1", 554445, 300));
            customer.bankAccList.Add(new BankAccount("BankAccount 1", 552322, 2000));

            // There should be one account on each list
            if (customer.saveAccList.Count == 1 && customer.bankAccList.Count == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nTest succeed");
                Console.WriteLine("Displaying Accounts press Enter");
                Console.ReadKey();
                customer.DisplayAllBankAndSavingAccount();
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Test Failed to Display all accounts");
            }
        }
    }
}
