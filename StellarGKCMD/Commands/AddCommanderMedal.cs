using StellarGK.Database;
using StellarGK.Logic.ExcelReader;

namespace StellarGK.Commands
{
    [CommandHandler("AddCommanderMedal", "[MemberId], <commanderId>", CommandType.Console)]
    public class AddCommanderMedalCommand : Command
    {
        public override void Run(string[] args)
        {
            var commanders = CommanderCostumeData.GetInstance().AddSpecificCommanderMedals(int.Parse(args[1]));

            int accountId = int.Parse(args[0]);

            DatabaseManager.GameProfile.UpdateMedalData(accountId, commanders);

            Console.WriteLine($"Added medals to Chars {args[1]}");

        }
    }
}
