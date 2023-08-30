using StellarGK.Commands;
using System.Diagnostics;

namespace StellarGKCMD.Commands
{
    [CommandHandler("ShowRam", "[0], should display ram usage for the Emulator", CommandType.Console)]
    internal class ShowRamUsageCommand : Command
    {
        public override void Run(string[] args)
        {
            long memory;
            Process[] proccesses;
            proccesses = Process.GetProcessesByName("StellarGK.exe");
            memory = proccesses[0].PrivateMemorySize64;
            Console.WriteLine("Memory used: {0}.", memory);

        }
    }
}
