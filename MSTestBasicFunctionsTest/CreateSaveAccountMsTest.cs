using SigmaSquadBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestBasicFunctionsTest
{
    [TestClass]
    public class CreateSaveAccountMsTest
    {
        [TestMethod]
        public void Add_SaveAccount_Return_Amount_Of_Accounts()
        {
            //-- Arrange
            // Adding a test-Customer
            Customer customer = new Customer("Kalle", "Stengatan 1", 43, 1011, "hej", 2000);
            //Setup save-accounts
            string accountName = "Account 1";
            int accountNumber = 1012;
            double deposit = 5000;
            string accountName2 = "Account 2";
            int accountNumber2 = 1013;
            double deposit2 = 6000;

            //Adding to saveAccountList
            customer.addSaveAccountToList(accountName, accountNumber, deposit);
            customer.addSaveAccountToList(accountName2, accountNumber2, deposit2);

            // Act           
            int expectedNumberOfAccounts = 2;

            Assert.AreEqual(expectedNumberOfAccounts, customer.saveAccList.Count());

        }
    }
}
