using CommanderCSCMD.Commands;

namespace CommanderCSCMD.Commands
{

    [CommandHandler("help", " - shows help page >:3", CommandType.All)]
    internal class HelpCommand : Command
    {
        public override void Run(string[] args)
        {
            foreach (Command Cmd in CommandFactory.Commands)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("      " + Cmd.Name);
                Console.ResetColor();
                c.Trail(Cmd.Description);
            }
        }
    }
}
