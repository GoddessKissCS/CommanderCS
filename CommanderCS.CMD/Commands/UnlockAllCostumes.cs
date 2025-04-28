using CommanderCS.MongoDB;
using CommanderCS.Library.Shared.Protocols;
using CommanderCS.Library.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommanderCS.Packets.Handlers.Profile;

namespace CommanderCSCMD.Commands
{

    [CommandHandler("unlockallcostumes", "[id], adds all costumes to the Commanders", CommandType.Console)]
    public class UnlockAllCostumes : Command
    {
        public override void Run(string[] args)
        {

            var data = DatabaseManager.GameProfile.FindByMemberIdList(args[0]).FirstOrDefault().CommanderData;

            var commanders = GetAllCommandersWithDefaultValue(data);

            int accountId = int.Parse(args[0]);

            DatabaseManager.GameProfile.UpdateCommanderData(accountId, commanders);

            Console.WriteLine($"Added All Chars to id {args[0]}");

        }

        public Dictionary<string, UserInformationResponse.Commander> GetAllCommandersWithDefaultValue(Dictionary<string, UserInformationResponse.Commander> commanderDataDict)
        {
            foreach (var item in RemoteObjectManager.instance.regulation.commanderCostumeDtbl)
            {
                int cid = item.cid;

                // Check if the cid already exists in the dictionary to avoid duplicates
                if (!commanderDataDict[cid.ToString()].haveCostume.Contains(item.ctid))
                {
                    commanderDataDict[cid.ToString()].haveCostume.Add(item.ctid);
                } 

            }

            return commanderDataDict;
        }

    }
}
