namespace BankingSystem
{
    public interface IAccount
    {
        string AccountHolder { get; set; }
        string AccountType { get; set; }
        string AccountNo { get; set; }
        decimal Balance { get; set; }
        decimal Interest { get; set; }
        public bool IsWithdrawable { get; }

        void CalculateInterest();
    }
}
