using System;

namespace BankingSystem
{
    public class SavingsBank : IWithdrawable
    {
        public string AccountHolder { get; set; }
        public string AccountType { get; set; }
        public string AccountNo { get; set; }
        public decimal Balance { get; set; }
        public decimal Interest { get; set; }

        public bool IsWithdrawable => true;

        public decimal MinBalance { get; set; }

        public void CalculateInterest()
        {
            throw new NotImplementedException();
        }

        public decimal Withdraw()
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
