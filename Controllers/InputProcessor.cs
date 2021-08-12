using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    class InputProcessor
    {
        private readonly ILogger _logger;
        private readonly IStandardMessage _message;

        public InputProcessor(ILogger logger, IStandardMessage message)
        {
            _logger = logger;
            _message = message;
        }
        public void Process()
        {
            string ch, ch2, name;
            BankService bs = new BankService(_logger, _message);
            do
            {
                Console.WriteLine("Enter a choice:");
                Console.WriteLine("1 for new account registration");
                Console.WriteLine("2 for old account");
                Console.WriteLine("Any key for exit");
                ch = Console.ReadLine();

                if (ch == "1")
                {
                    Console.WriteLine("Enter account type:");
                    Console.WriteLine("1 for Fixed Deposit");
                    Console.WriteLine("2 for Savings Bank");
                    ch2 = Console.ReadLine();

                    switch (ch2)
                    {
                        case "1":
                            Console.WriteLine("Enter holder name;");
                            name = Console.ReadLine();
                            bs.RegisterAccount(new FixedDeposit(_logger, _message) { AccountHolder = name });
                            break;
                        case "2":
                            Console.WriteLine("Enter holder name:");
                            name = Console.ReadLine();
                            bs.RegisterAccount(new SavingsBank(_logger, _message) { AccountHolder = name });
                            break;
                        default:
                            _logger.LogError("Invalid choice!");
                            break;
                    }
                }
                else if (ch == "2") 
                {
                    IAccount acc = null;
                    try
                    {
                        Console.WriteLine("Enter account number:");
                        string accNo = Console.ReadLine();
                        acc = bs.GetAccount(accNo);

                        Console.WriteLine("Enter choice:");
                        Console.WriteLine("1 for deposit");
                        Console.WriteLine("2 for withdrawal");
                        Console.WriteLine("3 for interest calculation");
                        Console.WriteLine("Any other key for exit");
                        ch2 = Console.ReadLine();

                        switch (ch2)
                        {
                            case "1":
                                Console.WriteLine("Enter amt to be deposited :");
                                decimal amt = decimal.Parse(Console.ReadLine());
                                acc.Deposit(amt);
                                break;
                            case "2":
                                Console.WriteLine("Enter amt to be withdrawn :");
                                amt = decimal.Parse(Console.ReadLine());
                                acc.Withdraw(amt);
                                break;
                            case "3":
                                acc.CalculateInterest();
                                break;
                            default:
                                Console.WriteLine("Invalid choice!");
                                break;
                        }
                    }
                    catch(Exception e)
                    {
                        _logger.LogError(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
            } while (true);
            

        }
    }
}
