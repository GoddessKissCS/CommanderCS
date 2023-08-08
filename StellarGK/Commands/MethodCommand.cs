using StellarGK.Host;

namespace StellarGK.Commands
{
    [CommandHandler("Method", "[id], displays the CmdId for the method", CommandType.Console)]
    internal class MethodCommand : Command
    {
        public override void Run(string[] args)
        {
            if (Enum.TryParse(int.Parse(args[0]).ToString(), out CommandId enumValue))
            {
                Console.WriteLine($"Parsed Enum Name: {enumValue}");
            }
            else
            {
                Console.WriteLine("Failed to parse the integer into the enum.");
            }

        }
    }
}
