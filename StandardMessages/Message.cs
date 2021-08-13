namespace BankingSystem
{
    public class Message : IStandardMessage
    {
        public string InsufficientBalance()
        {
            return "\nSorry! Your account balance is low.\n";
        }

        public string InvalidAccount()
        {
            return "\nGiven Account number does not exists!!\n";
        }

        public string SuccessDeposit(decimal amt, decimal bal)
        {
            return $"\n------------------\nDeposit Amt: Rs {amt}\nTotal Amt: Rs{bal}\n-----------------\n";
        }

        public string SuccessfulRegistration()
        {
            return "\nAccount Registered successfully\n";
        }

        public string SuccessWithdraw(decimal amt, decimal bal)
        {
            return $"\n------------------\nWithdrawn Amt: Rs {amt}\nTotal Amt: Rs{bal}\n-----------------\n";
        }

        public string FailedDeposit()
        {
            return "\nFailed to deposit\n";
        }

        public string FailedWithdrawal()
        {
            return "\nFailed to withdraw\n";
        }

        public string InvalidAmount()
        {
            return "\nInvalid amount entered\n";
        }
    }
}
