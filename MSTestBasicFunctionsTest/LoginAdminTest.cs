using SigmaSquadBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestBasicFunctionsTest
{
    [TestClass]
    public class LoginAdminTest
    {
        [TestMethod]
        public void LoginAsAdminTest()
        {
            int id = 1111;
            string password = "password";
            bool loginSuccess = false;


            Admin admin = new Admin("Fredrik", 30, id, password);

            if (admin.VerifyUser(id) == true)
            {
                if (admin.VerifyUser(password) == true)
                {
                    if (admin.IsAdmin == true)
                    {
                        loginSuccess = true;
                    }
                }
            }
            Assert.AreEqual(admin.IsAdmin, loginSuccess);
        }
    }
}
