using System;
using System.Collections.Generic;
using System.Linq;

namespace BankingSystem
{
    public class BankService
    {
        private readonly IList<IAccount> _accounts;

        public BankService()
        {
            _accounts = new List<IAccount>();
        }

        public void RegisterAccount(IAccount account)
        {
            _accounts.Add(account);
        }

        public void CheckWithdrawable(string accountNo)
        {
            var isWithdrawable = _accounts.SingleOrDefault(a => a.AccountNo == accountNo).IsWithdrawable;
            
            Console.WriteLine($"Account {accountNo} is withdrawable? -> {isWithdrawable}");
        }

        public void CalculateInterest(string accountNo)
        {
            var interest = _accounts.SingleOrDefault(a => a.AccountNo == accountNo).CalculateInterest();

            Console.WriteLine($"Account {accountNo} Interest is -> {interest}");
        }

        public void DisplayAll()
        {
            foreach(IAccount account in _accounts)
            {
                Console.WriteLine($"{account.AccountNo}\t{account.AccountHolder}\t{account.AccountType}\t{account.IsWithdrawable}\t{account.Balance}");
            }
        }
    }
}
