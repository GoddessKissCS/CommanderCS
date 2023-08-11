using StellarGK.Database;
using StellarGK.Logic.ExcelReader;

namespace StellarGK.Commands
{
    [CommandHandler("AddAllGoods", "[id]", CommandType.Console)]
    internal class AddAllGoodsCommandCommand : Command
    {
        public override void Run(string[] args)
        {
            var itemData = GoodsData.GetInstance().GetAllGoods();

            int accountId = int.Parse(args[0]);

            // TODO UPDATE
            //DatabaseManager.GameData.UpdateItemData(accountId, itemData);

            Console.WriteLine($"Added All Goods to id {args[0]}");

        }
    }
}
