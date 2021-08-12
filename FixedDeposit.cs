namespace BankingSystem
{
    public class FixedDeposit : IAccount
    {
        public string AccountHolder { get; set; }

        public string AccountType => "fixed";

        public string AccountNo { get; set; }

        public decimal Rate => 8;

        public decimal Balance { get; set; }

        public bool IsWithdrawable => false;

        public decimal CalculateInterest()
        {
            decimal interest = (Rate * Balance) / 100;

            if (interest > 20000 && interest <= 100000) 
            {
                interest -= (0.1m * interest);
            }
            else if (interest > 100000)
            {
                interest -= (0.25m * interest);
            }

            return interest;
        }
    }
}
