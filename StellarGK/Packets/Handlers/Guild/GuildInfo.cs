using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StellarGK.Database;
using StellarGKLibrary.Protocols;
using System.Numerics;

namespace StellarGK.Host.Handlers.Guild
{
    [Packet(Id = Method.GuildInfo)]
    public class GuildInfo : BaseMethodHandler<GuildInfoRequest>
    {
        public override object Handle(GuildInfoRequest @params)
        {
            var session = GetSession();

            var user = GetUserGameProfile();

            var goods = DatabaseManager.GameProfile.UserResourcesFromSession(session);
            var battlestats = DatabaseManager.GameProfile.UserStatisticsFromSession(session);
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

                equipItem = user.UserInventory.equipItem,

                donHaveCommCostumeData = user.UserInventory.donHaveCommCostumeData,
                completeRewardGroupIdx = user.CompleteRewardGroupIdx,
                guildInfo = guild,
                sweepClearData = user.SweepClearData,
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

    public class GuildInfoRequest
    {
        [JsonProperty("type")]
        public List<string> Type { get; set; }
    }
}
