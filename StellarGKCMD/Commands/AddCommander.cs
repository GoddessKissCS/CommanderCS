using StellarGK.Database;
using StellarGK.Logic.ExcelReader;

namespace StellarGK.Commands
{
    [CommandHandler("AddCommander", "[memberId], <commanderId>", CommandType.Console)]
    public class AddCommanderCommand : Command
    {
        public override void Run(string[] args)
        {
            int accountId = int.Parse(args[0]);

            var commanders = CommanderCostumeData.GetInstance().AddSpecificCommander(int.Parse(args[1]));

            DatabaseManager.GameProfile.UpdateCommanderData(accountId, commanders);

            Console.WriteLine($"Added All Chars to id {args[0]}");

        }
    }
}
