using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Nickname
{
    [Packet(Id = Method.SetNickNameFromTutorial)]
    public class SetNickNameFromTutorial : BaseMethodHandler<SetNickNameFromTutorialRequest>
    {
        public override object Handle(SetNickNameFromTutorialRequest @params)
        {

            ErrorCode code = DatabaseManager.GameProfile.RequestNicknameAfterTutorial(Session, @params.Unm);

            if (code != ErrorCode.Success)
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = code },
                };

                return error;
            }

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
            };

            var user = GetUserGameProfile();

            //if (user.TutorialData.skip)
            //{
            //    var information = GetUserInformationResponse(user);

            //    string result = JsonConvert.SerializeObject(information);

            //    response.Result = result;
            //    response.Step = @params.Step;

            //    return response;
            //}

            SetNickNameResponse SetNickNameF1 = new()
            {
                step = @params.Step,
            };

            response.Result = SetNickNameF1;

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