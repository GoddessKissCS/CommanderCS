using CommanderCS.Database;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;
using CommanderCSLibrary.Shared.Enum;

namespace CommanderCS.Host.Handlers.Tutorial
{
    [Packet(Id = Method.LoginTutorialSkip)]
    public class LoginTutorialSkip : BaseMethodHandler<LoginTutorialSkipRequest>
    {
        public override object Handle(LoginTutorialSkipRequest @params)
        {
            var session = GetSession();

            UserInformationResponse.TutorialData tutorialData = new() { skip = Convert.ToBoolean(@params.skip), step = 12 };

            DatabaseManager.GameProfile.UpdateTutorialData(session, tutorialData);

            TutorialStep lts = new()
            {
                ttrl = tutorialData,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = lts
            };

            return response;
        }

        private class TutorialStep
        {
            [JsonProperty("ttrl")]
            public UserInformationResponse.TutorialData ttrl { get; set; }
        }
    }

    public class LoginTutorialSkipRequest
    {
        [JsonProperty("skip")]
        public int skip { get; set; }
    }
}