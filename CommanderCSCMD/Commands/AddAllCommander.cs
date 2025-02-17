using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Protocols;
using CommanderCSLibrary.Shared.Regulation.DataRows;

namespace CommanderCSCMD.Commands
{
    [CommandHandler("AddAllCommanders", "[id]", CommandType.Console)]
    public class AddAllCommandersCommand : Command
    {
        public override void Run(string[] args)
        {
            var commanders = GetAllCommandersWithDefaultValue();

            int accountId = int.Parse(args[0]);

            DatabaseManager.GameProfile.UpdateCommanderData(accountId, commanders);

            Console.WriteLine($"Added All Chars to id {args[0]}");

        }

        public Dictionary<string, UserInformationResponse.Commander> GetAllCommandersWithDefaultValue()
        {
            Dictionary<string, UserInformationResponse.Commander> commanderDataDict = new();

            foreach (var item in RemoteObjectManager.instance.regulation.commanderCostumeDtbl)
            {
                int cid = item.cid;

                // Check if the cid already exists in the dictionary to avoid duplicates
                if (!commanderDataDict.ContainsKey(cid.ToString()))
                {
                    UserInformationResponse.Commander commanderData = new()
                    {
                        state = "N",
                        __skv1 = "1",
                        __skv2 = "1",
                        __skv3 = "1",
                        __skv4 = "1",
                        favorRewardStep = 0,
                        favorStep = 0,
                        currentCostume = item.ctid,
                        equipItemInfo = new() { },
                        equipWeaponInfo = new() { },
                        eventCostume = new() { },
                        favorPoint = new() { },
                        favr = 0,
                        fvrd = 0,
                        haveCostume = new() { item.ctid },
                        id = "" + cid,
                        marry = 0,
                        medl = cid,
                        role = "A",
                        transcendence = new() { 0, 0, 0, 0 },
                        __cls = "1",
                        __exp = "0",
                        __level = "1",
                        __rank = "1",
                    };

                    commanderDataDict.Add(cid.ToString(), commanderData);
                }

            }

            return commanderDataDict;
        }

    }
}
