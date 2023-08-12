using StellarGK.Logic.ExcelReader;

namespace StellarGK.Commands
{
    [CommandHandler("level", "[id], <1-140>", CommandType.Player)]
    public class LevelCommand : Command
    {
        public override void Run(string[] args)
        {
            int accountId = int.Parse(args[0]);
            int level = int.Parse(args[1]);

            int exp = UserLevelData.GetInstance().FromLevel(level).uExp;

            // TODO UPDATE
            //DatabaseManager.Resources.UpdateExpAndLevel(accountId, exp, level);

            Console.WriteLine($"Changed {args[0]}, exp and level to {exp} & {level}");

        }
    }
}