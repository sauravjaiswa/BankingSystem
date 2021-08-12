namespace BankingSystem
{
    public interface IAccount
    {
        string AccountHolder { get; set; }
        string AccountType { get; }
        string AccountNo { get; set; }
        decimal Rate { get; }
        decimal Balance { get; set; }
        public bool IsWithdrawable { get; }

        decimal CalculateInterest();
    }
}
