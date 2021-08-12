using System;

namespace BankingSystem
{
    public class SavingsBank : IAccount
    {
        private decimal _interest;
        private readonly ILogger _logger;
        private readonly IStandardMessage _message;
        public string AccountHolder { get; set; }
        public string AccountType => "savings";
        public string AccountNo { get; private set; }
        public decimal Rate => 5;
        public decimal Balance { get; private set; }
        public decimal MinBalance => 1000;

        public SavingsBank()
        {
            AccountNo = new Random().Next().ToString();
        }

        public SavingsBank(ILogger logger, IStandardMessage message) : this()
        {
            _logger = logger;
            _message = message;
        }

        public void CalculateInterest()
        {
            _interest = (Rate * Balance) / 100;
            _logger.LogInfo($"Interest : Rs {_interest}");
        }

        public void Deposit(decimal amt)
        {
            if (amt <= 0)
            {
                throw new InvalidOperationException(_message.InvalidAmount());
            }

            Balance += amt;
            _logger.LogInfo(_message.SuccessDeposit(amt, Balance));
        }

        public void Withdraw(decimal amt)
        {
            if (amt <= 0)
            {
                throw new InvalidOperationException(_message.InvalidAmount());
            }

            if (amt <= Balance)
            {
                Balance -= amt;
                _logger.LogInfo(_message.SuccessWithdraw(amt, Balance));
            }
            else
            {
                throw new InvalidOperationException(_message.InsufficientBalance());
            }
            
        }

        public override string ToString()
        {
            return $"\n-----------------------\nAccount Num : {AccountNo}\nAccount Holder : {AccountHolder}\nAccount Type : {AccountType}\nBalance : Rs {Balance}\n------------------------\n";
        }
    }
}
