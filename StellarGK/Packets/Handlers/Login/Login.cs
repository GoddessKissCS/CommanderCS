using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StellarGK.Database;
using StellarGKLibrary.Enum;
using StellarGKLibrary.Protocols;

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
                __commanderInfo = JObject.FromObject(user.CommanderData),
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
            [JsonProperty("sess")]
            public string sess { get; set; }

            [JsonProperty("info")]
            public UserInformationResponse info { get; set; }
        }
    }

    public class LoginRequest
    {
        [JsonProperty("mIdx")]
        public int memberId { get; set; }

        [JsonProperty("tokn")]
        public string token { get; set; }

        [JsonProperty("wld")]
        public int world { get; set; }

        [JsonProperty("unm")]
        public string userName { get; set; }

        [JsonProperty("plfm")]
        public Platform platform { get; set; }

        [JsonProperty("devc")]
        public string deviceName { get; set; }

        [JsonProperty("dvid")]
        public string deviceId { get; set; }

        [JsonProperty("ptype")]
        public int patchType { get; set; }

        [JsonProperty("oscd")]
        public OSCode osCode { get; set; }

        [JsonProperty("osvr")]
        public string osVersion { get; set; }

        [JsonProperty("gmvr")]
        public string gameVersion { get; set; }

        [JsonProperty("apk")]
        public string apkFileName { get; set; }

        [JsonProperty("psId")]
        public string pushRegistrationId { get; set; }

        [JsonProperty("lang")]
        public string languageCode { get; set; }

        [JsonProperty("ctry")]
        public string countryCode { get; set; }

        [JsonProperty("gpid")]
        public string largoId { get; set; }

        [JsonProperty("ch")]
        public int channel { get; set; }
    }
}