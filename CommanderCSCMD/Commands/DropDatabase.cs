using CommanderCS.MongoDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderCSCMD.Commands
{

    [CommandHandler("dropdatabase", "just drops the database", CommandType.Console)]
    public class DropDatabase : Command
    {
        public override void Run(string[] args)
        {

            MongoClient MongoClient = new("mongodb://127.0.0.1:27017/GoddessKiss");

            MongoClient.DropDatabase("GoddessKiss");

        }
    }
}
