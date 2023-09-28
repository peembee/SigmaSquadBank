namespace ManualTests
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
              Test-Classes:
                 --> ManualTest_DisplayAllBankaccountsAndSaveAccount
                 --> ManualTest_UnlockCustomer
             */

            ManualTest_DisplayAllBankaccountsAndSaveAccount manualTest_DisplayAllBankaccountsAndSaveAccount = new ManualTest_DisplayAllBankaccountsAndSaveAccount();
            ManualTest_UnlockCustomer manualTest_UnlockCustomer = new ManualTest_UnlockCustomer();

            // Anropa testmetoderna
            manualTest_DisplayAllBankaccountsAndSaveAccount.DisplayAllBankAccountsAndSaveAccounts();
            manualTest_UnlockCustomer.UnlockCustomerTest();
        }
    }
}