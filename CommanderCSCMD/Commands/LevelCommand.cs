using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Regulation;

namespace CommanderCSCMD.Commands
{
    [CommandHandler("level", "[id], <1-140>", CommandType.Player)]
    public class LevelCommand : Command
    {
        public override void Run(string[] args)
        {
            int accountId = int.Parse(args[0]);
            int level = int.Parse(args[1]);

            int exp = RemoteObjectManager.instance.regulation.userLevelDtbl.Find(x => x.level == level).uExp;

#warning TODO UPDATE
            DatabaseManager.GameProfile.UpdateExpAndLevel(accountId, exp, level);

            Console.WriteLine($"Changed {args[0]}, exp and level to {exp} & {level}");

        }
    }
}