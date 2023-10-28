using StellarGK.Commands;

namespace StellarGKCMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CommandFactory.LoadCommandHandlers();
            ReadLine.GetInstance().Start();
        }
    }
}