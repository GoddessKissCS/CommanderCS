using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Host.Handlers.Login
{
    [Packet(Id = Method.Login)]
    public class Login : BaseMethodHandler<LoginRequest>
    {
        public override object Handle(LoginRequest @params)
        {
            string session = GenerateUniqueSessionToken();

            var rg = GetRegulation();

            var user = DatabaseManager.GameProfile.GetOrCreate(@params.memberId, @params.world);

            ErrorCode code = DatabaseManager.Account.RequestLogin(@params, session);

            if (code != ErrorCode.Success)
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = code },
                };

                return error;
            }


            var goods = DatabaseManager.GameProfile.UserResources2Resource(user.UserResources);
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
                /// pronabably set it globally?
                equipItem = user.UserInventory.equipItem,

                donHaveCommCostumeData = user.UserInventory.donHaveCommCostumeData,
                completeRewardGroupIdx = user.CompleteRewardGroupIdx,
                guildInfo = guild,
                sweepClearData = user.BattleData.SweepClearData,
                preDeck = user.PreDeck,
                weaponList = user.UserInventory.weaponList,
                __commanderInfo = JObject.FromObject(user.CommanderData),
            };

            LoginPacket Login = new()
            {
                info = userInformationResponse,
                sess = session
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = Login
            };

            return response;
        }

        public string GenerateUniqueSessionToken()
        {
            string session;

            do
            {
                session = Guid.NewGuid().ToString();
            } while (DatabaseManager.GameProfile.SessionTokenExists(session));

            return session;
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