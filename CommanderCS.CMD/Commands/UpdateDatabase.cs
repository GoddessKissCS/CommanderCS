using CommanderCS.MongoDB;
using CommanderCS.Library.Protocols;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderCSCMD.Commands
{

    [CommandHandler("updatedatabase", "[id], updates the given memberid to the lastet addition", CommandType.Console)]
    public class UpdateDatabase : Command
    {
        public override void Run(string[] args)
        {
            // will be changed in future 

            DatabaseManager.GameProfile.AddCommanderScenario(int.Parse(args[0]), []);
        }
    }
}
