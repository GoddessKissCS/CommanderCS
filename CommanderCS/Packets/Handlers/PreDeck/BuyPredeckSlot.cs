using CommanderCS.Database;
using CommanderCS.Host;
using CommanderCS.Protocols;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.PreDeck
{
    [Packet(Id = Method.BuyPredeckSlot)]
    public class BuyPredeckSlot : BaseMethodHandler<BuyPredeckSlotRequest>
    {
        private readonly int openCost = 1200;
        private readonly int addOpenCost = 200;
        private readonly int basePredeckCount = 5;

        public override object Handle(BuyPredeckSlotRequest @params)
        {
            var session = GetSession();
            var user = GetUserGameProfile();

            if(user.UserStatistics.PredeckCount >= 20)
            {
                ErrorPacket errorPacket = new()
                {
                    Error = new() { code = ErrorCode.TimedOut },
                    Id = BasePacket.Id,
                };

                return errorPacket;
            }

            int cashCost = openCost + addOpenCost * (user.UserStatistics.PredeckCount - basePredeckCount);

            user = DatabaseManager.GameProfile.UpdateCash(session, cashCost, false);

            DatabaseManager.GameProfile.AddEmptyPreDeckSlot(session, user.UserStatistics.PredeckCount);

            var goods = DatabaseManager.GameProfile.UserResources2Resource(user.UserResources);
            var battlestats = DatabaseManager.GameProfile.UserStatistics2BattleStatistics(user.UserStatistics);
            var guild = DatabaseManager.Guild.RequestGuild(user.GuildId, user.Uno);

            UserInformationResponse userInformationResponse = new()
            {
                goodsInfo = goods,
                battleStatisticsInfo = battlestats,
                uno = user.Uno.ToString(),
                stage = user.LastStage,
                notification = user.Notifaction,

                foodData = user.UserInventory.foodData,
                eventResourceData = user.UserInventory.eventResourceData,
                groupItemData = user.UserInventory.groupItemData,
                itemData = user.UserInventory.itemData,
                medalData = user.UserInventory.medalData,
                partData = user.UserInventory.partData,

                resetRemain = user.ResetDateTime, // should be set?
                /// probably set it globally?

                equipItem = user.UserInventory.equipItem,

                donHaveCommCostumeData = user.UserInventory.donHaveCommCostumeData,
                completeRewardGroupIdx = user.CompleteRewardGroupIdx,
                guildInfo = guild,
                sweepClearData = user.BattleData.SweepClearData,
                preDeck = user.PreDeck,
                weaponList = user.UserInventory.weaponList,
                __commanderInfo = JObject.FromObject(user.CommanderData),
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = userInformationResponse,
            };

            return response;
        }
    }

    public class BuyPredeckSlotRequest
    {
    }
}