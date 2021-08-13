using System;
using System.Collections.Generic;
using System.Linq;

namespace BankingSystem
{
    public class BankService
    {
        private readonly List<IAccount> _accounts;
        private readonly ILogger _logger;
        private readonly IStandardMessage _message;

        public BankService(ILogger logger, IStandardMessage message)
        {
            _accounts = new List<IAccount>();
            _logger = logger;
            _message = message;
        }

        public void RegisterAccount(IAccount account)
        {
            _accounts.Add(account);
            Display(account);
            _logger.LogInfo(_message.SuccessfulRegistration());
        }

        public IAccount GetAccount(string accountNum)
        {
            var account = _accounts.FirstOrDefault(a => a.AccountNo.Equals(accountNum));

            if (account == null)
                throw new InvalidOperationException(_message.InvalidAccount());

            return account;
        }

        public void Display(IAccount account)
        {
            _logger.LogInfo(account.ToString());
        }

        //public void Deposit(decimal amt)
        //{
        //    decimal prevBal = _account.Balance;
        //    _account.Deposit(amt);
        //    Console.WriteLine($"Amount of Rs {amt} deposited.\nPrev Bal: Rs {prevBal}\nNew Bal: Rs {_account.Balance}");
        //}

        //public void Withdraw(decimal amt)
        //{
        //    decimal prevBal = _account.Balance;
        //    _account.Withdraw(amt);
        //    Console.WriteLine($"Amount of Rs {amt} withdrawn.\nPrev Bal: Rs {prevBal}\nNew Bal: Rs {_account.Balance}");
        //}

        //public void DisplayAll()
        //{
        //    foreach(IAccount account in BankDb.GetAll())
        //    {
        //        Console.WriteLine($"{account.AccountNo}\t{account.AccountHolder}\t{account.AccountType}\t{account.Balance}");
        //    }
        //}
    }
}
