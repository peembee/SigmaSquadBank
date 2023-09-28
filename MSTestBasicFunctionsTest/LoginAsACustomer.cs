using SigmaSquadBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestBasicFunctionsTest
{
    [TestClass]
    public class LoginAsACustomer
    {
        [TestMethod]

        public void LoginAsACustomerTest_ValidCredentials()
        {
            //-- Arrange
            Customer customer = new Customer("TestCustomer", "TestAddress", 30, 1234, "password123", 1000);

            //-- Act
            bool loginResult = customer.Login("TestCustomer", "password123");

            //-- Assert
            Assert.IsTrue(loginResult);
            // Kontrollera att andra egenskaper i din Customer-klass är korrekta efter inloggningen om sådana finns
        }


        [TestMethod]
        public void LoginAsACustomerTest_InvalidCredentials()
        {
            //-- Arrange
            Customer customer = new Customer("TestCustomer", "TestAddress", 30, 1234, "password123", 1000);

            //-- Act
            bool loginResult = customer.Login("TestCustomer", "felaktiglösenord");

            //-- Assert
            Assert.IsFalse(loginResult);
            // Kontrollera att andra egenskaper i din Customer-klass är korrekta efter ett misslyckat inloggningsförsök om sådana finns
        }
    }
}
