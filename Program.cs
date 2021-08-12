namespace BankingSystem
{
    partial class Program
    {
        static void Main(string[] args)
        {
            InputProcessor processor = new InputProcessor(new ConsoleLogger(), new Message());
            processor.Process();
            
        }
    }
}
