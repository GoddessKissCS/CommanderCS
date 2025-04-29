using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.Nickname
{
    [Packet(Id = Method.SetNickNameFromTutorial)]
    public class SetNickNameFromTutorial : BaseMethodHandler<SetNickNameFromTutorialRequest>
    {
        public override object Handle(SetNickNameFromTutorialRequest @params)
        {
            ErrorCode code = DatabaseManager.GameProfile.RequestNicknameAfterTutorial(SessionId, @params.Unm);

            if (code != ErrorCode.Success)
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = code },
                };

                return error;
            }

            if (User.TutorialData.skip)
            {
                var information = GetUserInformationResponse(User);

                JObject tutorialResponse = new()
                {
                    ["id"] = BasePacket.Id,
                    ["result"] = new JObject
                    {
                        ["step"] = @params.Step,
                        ["rsoc"] = JObject.FromObject(information.goodsInfo),
                        ["uifo"] = JObject.FromObject(information.battleStatisticsInfo),
                        ["comm"] = JObject.FromObject(information.__commanderInfo),
                        ["uno"] = information.uno,
                        ["stage"] = information.stage,
                        ["part"] = JObject.FromObject(information.partData),
                        ["medl"] = JObject.FromObject(information.medalData),
                        ["ersoc"] = JObject.FromObject(information.eventResourceData),
                        ["food"] = JObject.FromObject(information.foodData),
                        ["item"] = JObject.FromObject(information.itemData),
                        ["gld"] = null,
                        ["cc"] = JObject.FromObject(information.sweepClearData),
                        ["deck"] = JArray.FromObject(information.preDeck),
                        ["nhcc"] = JObject.FromObject(information.donHaveCommCostumeData),
                        ["grp"] = JArray.FromObject(information.completeRewardGroupIdx),
                        ["rstm"] = information.resetRemain,
                        ["onoff"] = information.notification,
                        ["equip"] = JObject.FromObject(information.equipItem),
                        ["guit"] = JObject.FromObject(information.groupItemData),
                        ["weapon"] = JObject.FromObject(information.weaponList)
                    }
                };

                return tutorialResponse;
            }
            else
            {
                ResponsePacket response = new()
                {
                    Id = BasePacket.Id,
                    Result = new SetNickNameResponse()
                    {
                        step = @params.Step,
                    }
                };

                return response;
            }
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