namespace BankingSystem
{
    public interface IWithdrawable : IAccount
    {
        decimal MinBalance { get; }
        decimal Withdraw(decimal amt);
    }
}
