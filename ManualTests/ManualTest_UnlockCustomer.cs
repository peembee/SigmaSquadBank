using SigmaSquadBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualTests
{
    public class ManualTest_UnlockCustomer
    {
        public ManualTest_UnlockCustomer()
        {
            UnlockCustomerTest();
        }

        public void UnlockCustomerTest()
        {
            // Skapa en admin
            Admin admin = new Admin("AdminName", 30, 1234, "AdminPassword");
            admin.AdminMainMenu();

            // While creating a customer you have the options to chose to lock the customer or not by pressing Y || N.

            // Step 1: Create a customer and lock the customer by pressing Y
            // Step 2: Unlock the customer by ID when you have pressed option 1 in the menu "Unlock customer".
        }
    }
}
