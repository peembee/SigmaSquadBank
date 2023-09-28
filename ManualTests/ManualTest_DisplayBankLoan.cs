using SigmaSquadBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualTests
{
    public class ManualTest_DisplayBankLoan
    {
        public ManualTest_DisplayBankLoan()
        {
            Display_BankLoan_Return_AllBankLoan();
        }
        public void Display_BankLoan_Return_AllBankLoan()
        {
            Customer customer = new Customer("Kalle", "Stengatan 1", 43, 1011, "hej", 2000);
            BankLoan getTestBankLoan = new BankLoan();

            // if customer.debtToBank is false, test succeed. customer have not yet created a bankloan
            if (customer.debtToBank == false)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nTest succeed");
                Console.WriteLine("Customer bankLoan is false");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Test Failed, there should not be any debt to the bank yet");
                Console.ResetColor();
            }

            //Displaying bankloan to console
            Console.WriteLine("\n display bankloan, Press enter");
            Console.ReadKey();
            customer.DisplayBankLoan();

            Console.WriteLine("\n add test data for bankloan, Press enter");
            Console.ReadKey();

            double newTestBankLoan = 2000;
            customer.BankLoan = getTestBankLoan.Loan(newTestBankLoan);
            customer.debtToBank = true;

            // if customer.debtToBank is true, test succeed. customer have now created a bankloan
            if (customer.debtToBank == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nTest succeed");
                Console.WriteLine("Customer bankLoan is true");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Test Failed, customer.debtToBank should be true");
                Console.ResetColor();
            }
            Console.WriteLine("\n display bankloan, Press enter");
            Console.ReadKey();

            //Displaying bankloan to console
            customer.DisplayBankLoan();
        }
    }
}
