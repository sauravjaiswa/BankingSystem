namespace BankingSystem
{
    public interface IStandardMessage
    {
        string SuccessfulRegistration();
        string InvalidAccount();
        string InsufficientBalance();
        string InvalidAmount();
        string SuccessWithdraw(decimal amt, decimal bal);
        string SuccessDeposit(decimal amt, decimal bal);
        string FailedDeposit();
        string FailedWithdrawal();
    }
}
