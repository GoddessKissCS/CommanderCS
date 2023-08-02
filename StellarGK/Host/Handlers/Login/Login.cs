using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StellarGK.Database;
using StellarGK.Logic.Enums;
using StellarGK.Logic.Protocols;
using StellarGK.Utils;

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

            switch (code)
            {
                case ErrorCode.BannedOrSuspended or ErrorCode.UnableToJoin:

                    response.error = new() { code = code };

                    return response;

                default:

                    var account = DatabaseManager.Account.FindByUid(@params.memberId);

                    var gamedata = DatabaseManager.GameData.FindByUid(@params.memberId);

                    UserInformationResponse userInformationResponse = new()
                    {
                        goodsInfo = DatabaseManager.Resources.RequestResourcesScheme(@params.memberId),
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

                        resetRemain = 1,

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
            public string sess { get; set; }

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