namespace BankingSystem
{
    public class SavingsBank : IWithdrawable
    {
        public string AccountHolder { get; set; }
        public string AccountType => "savings";
        public string AccountNo { get; set; }
        public decimal Rate => 5;
        public decimal Balance { get; set; }

        public bool IsWithdrawable => true;

        public decimal MinBalance => 1000;

        public decimal CalculateInterest()
        {
            return (Rate * Balance) / 100;
        }

        public decimal Withdraw(decimal amt)
        {
            if (amt >= Balance)
            {
                Balance -= amt;
            }

            return Balance;
        }
    }
}
