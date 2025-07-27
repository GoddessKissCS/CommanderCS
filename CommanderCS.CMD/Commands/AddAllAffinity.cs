using CommanderCS.MongoDB;
using CommanderCSCMD.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderCS.CMD.Commands
{

    [CommandHandler("addallaffinity", "[id], updates the given memberid to the lastet addition", CommandType.Console)]
    public class AddAllAffinityDatabase : Command
    {
        public override void Run(string[] args)
        {
            // will be changed in future 

            var user = DatabaseManager.GameProfile.GetOrCreate(int.Parse(args[0]), 1);

            foreach(var commander in user.CommanderData)
            {
                user.CommanderData[commander.Key].favr = 1000000;
                user.CommanderData[commander.Key].fvrd = 1000000;
                user.CommanderData[commander.Key].favorPoint = 1000000;
                user.CommanderData[commander.Key].favorStep = 15;
                user.CommanderData[commander.Key].__level = "140";
                user.CommanderData[commander.Key].__rank = "6";
                user.CommanderData[commander.Key].__cls = "23";
            }

            DatabaseManager.GameProfile.UpdateCommanderData(int.Parse(args[0]), user.CommanderData);

        }
    }
}
