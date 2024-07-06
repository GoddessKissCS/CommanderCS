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

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
            };

            if (User.TutorialData.skip)
            {
                //var information = GetUserInformationResponse(User);

                //string result = JsonConvert.SerializeObject(information);

                //string xx = File.ReadAllText("C:\\Users\\Zen\\Desktop\\test.txt");

                //response.Result = xx;

                //return response;

            }
            else
            {

            }

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