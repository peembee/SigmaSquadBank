using SigmaSquadBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestBasicFunctionsTest
{
    [TestClass]
    public class AddMembersTest
    {
        [TestMethod]
        public void addMembersToBankTest()
        {
            //-- Arrange
            Bank bank = new Bank("Admin");


            // Act
            bank.addNewCustomer("Urban", "gatan1", 20, 1011, "hej", 2212, false);
            bank.addNewCustomer("Lisa", "gatan2", 22, 1012, "hej", 3212, false);
            bank.addNewCustomer("Olle", "gatan3", 30, 1013, "hej", 4212, false);
            var customerList = bank.cloneCustomerList();
            int expectedLength = 3;

            Assert.AreEqual(expectedLength, customerList.Count());
        }
    }
}
