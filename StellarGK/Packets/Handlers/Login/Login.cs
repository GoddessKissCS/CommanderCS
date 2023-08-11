using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using StellarGK.Database;
using StellarGK.Logic.Enums;
using StellarGK.Logic.Protocols;
using StellarGK.Tools;

namespace StellarGK.Host.Handlers.Login
{
    [Command(Id = CommandId.Login)]
    public class Login : BaseCommandHandler<LoginRequest>
    {
        public override object Handle(LoginRequest @params)
        {
            // TODO ADD UNABLE TO JOIN 
            ResponsePacket response = new()
            {
                id = BasePacket.Id
            };

            //@params.world
            // first we need to check if the world has a profile if not create a new one
            
            string session = Constants.Session;

            var user = DatabaseManager.GameProfile.GetOrCreate(@params.memberId, @params.world);

            ErrorCode code = RequestLogin(@params, session);

            if (code == ErrorCode.BannedOrSuspended || code == ErrorCode.UnableToJoin)
            {
                response.error = new() { code = code };

                return response;
            }

            var goods = DatabaseManager.GameProfile.UserResourcesFromSession(session);
            var battlestats = DatabaseManager.GameProfile.UserStatisticsFromSession(session);
            var guild = DatabaseManager.Guild.RequestGuild(user.guildId);

            UserInformationResponse userInformationResponse = new()
            {
                goodsInfo = goods,
                battleStatisticsInfo = battlestats,
                uno = user.uno,
                stage = user.lastStage,
                notification = user.notifaction,

                foodData = user.userInventory.foodData,
                eventResourceData = user.userInventory.eventResourceData,
                groupItemData = user.userInventory.groupItemData,
                itemData = user.userInventory.itemData,
                medalData = user.userInventory.medalData,
                partData = user.userInventory.partData,

                resetRemain = user.resetDateTime, // should be set?

                equipItem = user.userInventory.equipItem,            

                donHaveCommCostumeData = user.userInventory.donHaveCommCostumeData,
                completeRewardGroupIdx = user.completeRewardGroupIdx,
                guildInfo = guild,
                sweepClearData = user.sweepClearData,
                preDeck = user.preDeck,
                weaponList = user.userInventory.weaponList,
                __commanderInfo = JObject.FromObject(user.commanderData),
            };


            LoginPacket Login = new()
            {
                info = userInformationResponse,
                sess = session
            };

            response.result = Login;

            return response;


        }

        private static ErrorCode RequestLogin(LoginRequest @params, string session)
        {
            var user = DatabaseManager.Account.FindByUid(@params.memberId);
            if (user.isBanned == true && user.isBanned != null)
            {
                return ErrorCode.BannedOrSuspended;
            }
            else
            {
                DatabaseManager.GameProfile.UpdateOnLogin(@params, session);
                return ErrorCode.Success;
            }
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