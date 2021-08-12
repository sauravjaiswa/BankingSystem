using System;

namespace BankingSystem
{
    public class FixedDeposit : IAccount
    {
        private DateTime _regTime;
        private decimal _interest;
        private readonly ILogger _logger;
        private readonly IStandardMessage _message;

        public string AccountHolder { get; set; }
        public string AccountType => "fixed";
        public string AccountNo { get; private set; }
        public decimal Rate => 8;
        public decimal Balance { get; private set; }

        public FixedDeposit()
        {
            _regTime = DateTime.Now;
            AccountNo = new Random().Next().ToString();
        }

        public FixedDeposit(ILogger logger, IStandardMessage message) : this()
        {
            _logger = logger;
            _message = message;
        }

        public void CalculateInterest()
        {
            _interest = (Rate * Balance) / 100;

            if (_interest > 20000 && _interest <= 100000) 
            {
                _interest -= (0.1m * _interest);
            }
            else if (_interest > 100000)
            {
                _interest -= (0.25m * _interest);
            }

            _logger.LogInfo($"Interest gained : Rs {_interest}");
        }

        public void Deposit(decimal amt)
        {
            if (amt <= 0)
            {
                throw new InvalidOperationException(_message.InvalidAmount());
            }

            if (Balance == 0)
            {
                Balance += amt;
                _logger.LogInfo(_message.SuccessDeposit(amt, Balance));
                return;
            }
            throw new InvalidOperationException(_message.FailedDeposit());
        }

        public void Withdraw(decimal amt)
        {
            if (amt <= 0)
            {
                throw new InvalidOperationException(_message.InvalidAmount());
            }

            CalculateInterest();
            if (DateTime.Now > _regTime)
            {
                amt = Balance + _interest;
                Balance = 0;
                _logger.LogInfo(_message.SuccessWithdraw(amt, Balance));
                return;
            }
            throw new InvalidOperationException(_message.FailedWithdrawal());
        }

        public override string ToString()
        {
            return $"\n-----------------------\nAccount Num : {AccountNo}\nAccount Holder : {AccountHolder}\nAccount Type : {AccountType}\nBalance : Rs {Balance}\n------------------------\n";
        }
    }
}
