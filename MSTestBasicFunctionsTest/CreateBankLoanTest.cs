using SigmaSquadBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestBasicFunctionsTest
{
    [TestClass]
    public class CreateBankLoanTest
    {
        [TestMethod]
        public void CreateABankLoanTest()
        {
            // Arrange
            BankLoan bankLoan = new BankLoan();
            double loan;

            // Act
            loan = bankLoan.Loan(5000);

            Assert.IsTrue(loan == 5000 * 1.3);

        }
    }
}
