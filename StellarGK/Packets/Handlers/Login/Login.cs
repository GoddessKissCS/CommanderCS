using Newtonsoft.Json.Linq;
using StellarGK.Database;
using StellarGK.Logic.Enums;
using StellarGK.Logic.Protocols;
using StellarGK.Tools;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.Login
{
    [Packet(Id = Method.Login)]
    public class Login : BaseMethodHandler<LoginRequest>
    {
        public override object Handle(LoginRequest @params)
        {
#warning TODO ADD UNABLE TO JOIN 
            ResponsePacket response = new()
            {
                Id = BasePacket.Id
            };

            //@params.world
            // first we need to check if the world has a profile if not create a new one

            string session = Guid.NewGuid().ToString();

            var user = DatabaseManager.GameProfile.GetOrCreate(@params.memberId, @params.world);

            var code = DatabaseManager.Account.RequestLogin(@params, session);

            if (code == ErrorCode.BannedOrSuspended || code == ErrorCode.UnableToJoin)
            {
                response.Error = new() { code = code };

                return response;
            }

            var goods = DatabaseManager.GameProfile.UserResourcesFromSession(session);
            var battlestats = DatabaseManager.GameProfile.UserStatisticsFromSession(session);
            var guild = DatabaseManager.Guild.RequestGuild(user.GuildId);



            string jsonCommanderData = JsonSerializer.Serialize(user.CommanderData);

            UserInformationResponse userInformationResponse = new()
            {
                goodsInfo = goods,
                battleStatisticsInfo = battlestats,
                uno = user.Uno,
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
                __commanderInfo = JsonObject.Parse(jsonCommanderData),            
            };


            LoginPacket Login = new()
            {
                info = userInformationResponse,
                sess = session
            };

            response.Result = Login;

            return response;
        }

        private class LoginPacket
        {
            [JsonPropertyName("sess")]
            public string sess { get; set; }
            [JsonPropertyName("info")]
            public UserInformationResponse info { get; set; }
        }
    }

    public class LoginRequest
    {
        [JsonPropertyName("mIdx")]
        public int memberId { get; set; }

        [JsonPropertyName("tokn")]
        public string token { get; set; }

        [JsonPropertyName("wld")]
        public int world { get; set; }

        [JsonPropertyName("unm")]
        public string userName { get; set; }

        [JsonPropertyName("plfm")]
        public Platform platform { get; set; }

        [JsonPropertyName("devc")]
        public string deviceName { get; set; }

        [JsonPropertyName("dvid")]
        public string deviceId { get; set; }
        [JsonPropertyName("ptype")]
        public int patchType { get; set; }

        [JsonPropertyName("oscd")]
        public OSCode osCode { get; set; }

        [JsonPropertyName("osvr")]
        public string osVersion { get; set; }

        [JsonPropertyName("gmvr")]
        public string gameVersion { get; set; }
        [JsonPropertyName("apk")]
        public string apkFileName { get; set; }

        [JsonPropertyName("psId")]
        public string pushRegistrationId { get; set; }

        [JsonPropertyName("lang")]
        public string languageCode { get; set; }

        [JsonPropertyName("ctry")]
        public string countryCode { get; set; }

        [JsonPropertyName("gpid")]
        public string largoId { get; set; }

        [JsonPropertyName("ch")]
        public int channel { get; set; }
    }
}