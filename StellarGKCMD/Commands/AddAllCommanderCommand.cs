﻿using StellarGK.Logic.ExcelReader;

namespace StellarGK.Commands
{
    [CommandHandler("AddAllCommanders", "[id]", CommandType.Console)]
    public class AddAllCommandersCommand : Command
    {
        public override void Run(string[] args)
        {
            var commanders = CommanderCostumeData.GetInstance().GetAllCommandersWithDefaultValue();

            int accountId = int.Parse(args[0]);


            // TODO UPDATE

            //DatabaseManager.GameData.UpdateCommanderData(accountId, commanders);

            Console.WriteLine($"Added All Chars to id {args[0]}");

        }
    }
}