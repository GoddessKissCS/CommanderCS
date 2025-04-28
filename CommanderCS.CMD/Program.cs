using CommanderCSCMD.Commands;

namespace CommanderCSCMD
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