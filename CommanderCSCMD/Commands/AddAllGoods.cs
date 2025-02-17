
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared;

namespace CommanderCSCMD.Commands
{
    [CommandHandler("addallgoods", "[id]", CommandType.Console)]
    internal class AddAllGoodsCommand : Command
    {
        public override void Run(string[] args)
        {
            var itemData = GetAllGoods(999);

            int accountId = int.Parse(args[0]);

#warning TODO UPDATE
            DatabaseManager.GameProfile.UpdateItemData(accountId, itemData);

            Console.WriteLine($"Added All Goods to id {args[0]}");

        }


        public Dictionary<string, int> GetAllGoods(int count)
        {
            Dictionary<string, int> allGoods = new();

            foreach (var item in RemoteObjectManager.instance.regulation.goodsDtbl)
            {
                allGoods.Add(item.type.ToString(), count);
            }

            return allGoods;
        }
    }
}
