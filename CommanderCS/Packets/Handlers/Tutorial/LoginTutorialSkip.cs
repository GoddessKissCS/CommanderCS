using CommanderCS.Database;
using CommanderCS.ExcelReader;
using CommanderCS.Host.Handlers.Commander;
using CommanderCS.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Tutorial
{
    [Packet(Id = Method.LoginTutorialSkip)]
    public class LoginTutorialSkip : BaseMethodHandler<LoginTutorialSkipRequest>
    {
        public override object Handle(LoginTutorialSkipRequest @params)
        {
            var session = GetSession();

            UserInformationResponse.TutorialData TData = RequestTutorialData(session, Convert.ToBoolean(@params.skip));

            TutorialStep lts = new()
            {
                ttrl = TData,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = lts
            };

            return response;
        }

        private static UserInformationResponse.TutorialData RequestTutorialData(string session, bool skipTutorial)
        {
            UserInformationResponse.TutorialData tutorialData = new() { skip = skipTutorial, step = 12 };

            DatabaseManager.GameProfile.UpdateTutorialData(session, tutorialData);

            return tutorialData;
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