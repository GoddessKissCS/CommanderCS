using CommanderCS.Database;
using Newtonsoft.Json;
using CommanderCSLibrary.Shared.Enum;

namespace CommanderCS.Host.Handlers.Nickname
{
    [Packet(Id = Method.SetNickNameFromTutorial)]
    public class SetNickNameFromTutorial : BaseMethodHandler<SetNickNameFromTutorialRequest>
    {
        public override object Handle(SetNickNameFromTutorialRequest @params)
        {
            var session = GetSession();

            ErrorCode code = DatabaseManager.GameProfile.RequestNicknameAfterTutorial(session, @params.Unm);

            if (code != ErrorCode.Success)
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = code },
                };

                return error;
            }

            //var user = getusergameprofile();

            //var goods = databasemanager.gameprofile.userresources2resource(user.userresources);
            //var battlestats = databasemanager.gameprofile.userstatisticsfromsession(session);
            //var guild = databasemanager.guild.requestguild(user.guildid, user.uno);

            //userinformationresponse userinformationresponse = new()
            //{
            //    goodsinfo = goods,
            //    battlestatisticsinfo = battlestats,
            //    uno = user.uno.tostring(),
            //    stage = user.laststage,
            //    notification = user.notifaction,

            //    fooddata = user.userinventory.fooddata,
            //    eventresourcedata = user.userinventory.eventresourcedata,
            //    groupitemdata = user.userinventory.groupitemdata,
            //    itemdata = user.userinventory.itemdata,
            //    medaldata = user.userinventory.medaldata,
            //    partdata = user.userinventory.partdata,

            //    resetremain = user.resetdatetime, // should be set?
            //    / pronabably set it globally ?

            //    equipitem = user.userinventory.equipitem,

            //    donhavecommcostumedata = user.userinventory.donhavecommcostumedata,
            //    completerewardgroupidx = user.completerewardgroupidx,
            //    guildinfo = guild,
            //    sweepcleardata = user.battledata.sweepcleardata,
            //    predeck = user.predeck,
            //    weaponlist = user.userinventory.weaponlist,
            //    __commanderinfo = jobject.fromobject(user.commanderdata),
            //};


            //string result = JsonConvert.SerializeObject(userInformationResponse);


            SetNickNameResponse SetNickNameF1 = new()
            {
                step = @params.Step,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = SetNickNameF1,
            };

            return response;
        }


        internal class SetNickNameResponse
        {
            [JsonProperty("step")]
            public int step { get; set; }
        }
    }

    public class SetNickNameFromTutorialRequest
    {
        [JsonProperty("unm")]
        public string Unm { get; set; }

        [JsonProperty("step")]
        public int Step { get; set; }
    }
}