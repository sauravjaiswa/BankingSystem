namespace BankingSystem
{
    public interface IAccount
    {
        string AccountHolder { get; set; }
        string AccountType { get; }
        string AccountNo { get; }
        decimal Rate { get; }
        decimal Balance { get; }

        void Deposit(decimal amt);
        void Withdraw(decimal amt = 0);
        void CalculateInterest();
    }
}
