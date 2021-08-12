namespace BankingSystem
{
    public interface IWithdrawable : IAccount
    {
        decimal MinBalance { get; set; }
        decimal Withdraw();
    }
}
