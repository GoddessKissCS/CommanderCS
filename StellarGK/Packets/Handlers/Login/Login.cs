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

            string session = Constants.Session;

            ErrorCode code = RequestLogin(@params.memberId, @params.deviceName, @params.deviceId, @params.patchType, (int)@params.osCode, @params.osVersion, @params.gameVersion, @params.apkFileName, @params.pushRegistrationId, @params.languageCode, @params.countryCode, @params.largoId, @params.channel, session);

            if (code == ErrorCode.BannedOrSuspended || code == ErrorCode.UnableToJoin)
            {
                response.error = new() { code = code };

                return response;
            }

            var account = GetAccount();

            var gamedata = GetGameData();

            UserInformationResponse userInformationResponse = new()
            {
                goodsInfo = DatabaseManager.Resources.RequestResources(@params.memberId),
                battleStatisticsInfo = DatabaseManager.BattleStatistics.RequestBattleStatistics(@params.memberId),
                uno = account.uno,
                stage = account.lastStage,
                notification = account.notifaction,

                foodData = gamedata.foodData,
                eventResourceData = gamedata.eventResourceData,
                groupItemData = gamedata.groupItemData,
                itemData = gamedata.ItemData,
                medalData = gamedata.medalData,
                partData = gamedata.partData,

                resetRemain = 1, // should be set?

                equipItem = gamedata.equipItem,

                donHaveCommCostumeData = gamedata.donHaveCommCostumeData,
                completeRewardGroupIdx = gamedata.completeRewardGroupIdx,
                guildInfo = DatabaseManager.Guild.RequestGuild(account.guildId),
                sweepClearData = gamedata.sweepClearData,
                preDeck = gamedata.preDeck,
                weaponList = gamedata.weaponList,
                __commanderInfo = JObject.FromObject(gamedata.commanderData),
            };


            LoginPacket Login = new()
            {
                info = userInformationResponse,
                sess = session
            };

            response.result = Login;

            return response;


        }


        private static ErrorCode RequestLogin(int mIdx, string devc, string dvid, int ptype, int oscd, string osvr, string gmvr, string apk, string psId, string lang, string ctry, string gpid, int ch, string session)
        {
            var user = DatabaseManager.Account.FindByUid(mIdx);
            if (user.isBanned == true)
            {
                return ErrorCode.BannedOrSuspended;
            }
            else
            {
                DatabaseManager.Account.UpdateUponLogin(mIdx, devc, dvid, ptype, oscd, osvr, gmvr, apk, psId, lang, gpid, ctry, ch, session);
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