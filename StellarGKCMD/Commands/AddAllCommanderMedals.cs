using StellarGK.Database;
using StellarGK.Logic.ExcelReader;

namespace StellarGK.Commands
{
    [CommandHandler("AddAllCommandersMedals", "[id]", CommandType.Console)]
    public class AddAllCommandersMedalsCommand : Command
    {
        public override void Run(string[] args)
        {
            var commanders = CommanderCostumeData.GetInstance().GetAllCommandersMedalsWithDefaultValue();


            int accountId = int.Parse(args[0]);

            DatabaseManager.GameProfile.UpdateMedalData(accountId, commanders);

            Console.WriteLine($"Added All Chars to id {args[0]}");

        }
    }
}
