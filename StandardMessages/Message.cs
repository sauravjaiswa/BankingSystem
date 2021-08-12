namespace BankingSystem
{
    public class Message : IStandardMessage
    {
        public string InsufficientBalance()
        {
            return "Sorry! Your account balance is low.\n";
        }

        public string InvalidAccount()
        {
            return "Given Account number does not exists!!\n";
        }

        public string SuccessDeposit(decimal amt, decimal bal)
        {
            return $"Deposit Amt: Rs {amt}----Total Amt: Rs{bal}\n";
        }

        public string SuccessfulRegistration()
        {
            return "Account Registered successfully\n";
        }

        public string SuccessWithdraw(decimal amt, decimal bal)
        {
            return $"Withdrawn Amt: Rs {amt}----Total Amt: Rs{bal}\n";
        }

        public string FailedDeposit()
        {
            return "Failed to deposit";
        }

        public string FailedWithdrawal()
        {
            return "Failed to withdraw";
        }

        public string InvalidAmount()
        {
            return "Invalid amount entered";
        }
    }
}
