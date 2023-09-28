using SigmaSquadBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestBasicFunctionsTest
{
    [TestClass]
    public class Test_CreateBankAccount
    {
        [TestMethod]
        public void createBankAccountTest()
        {
            //Arrange
            string accountName = "BankAccount";
            int accountNumber = 1234;
            double accountBalance = 1200;

            //Act
            BankAccount account = new BankAccount(accountName, accountNumber, accountBalance);

            //Assert
            Assert.AreEqual(accountName, account.BankAccountName);
            Assert.AreEqual(1200, account.Balance);
        }
    }
}
