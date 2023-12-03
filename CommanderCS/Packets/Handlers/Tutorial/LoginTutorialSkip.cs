using Newtonsoft.Json;
using CommanderCS.Database;
using CommanderCS.Protocols;

namespace CommanderCS.Host.Handlers.Tutorial
{
    [Packet(Id = Method.LoginTutorialSkip)]
    public class LoginTutorialSkip : BaseMethodHandler<LoginTutorialSkipRequest>
    {
        public override object Handle(LoginTutorialSkipRequest @params)
        {
            ResponsePacket response = new();

            UserInformationResponse.TutorialData TData = RequestTutorialData(GetSession(), Convert.ToBoolean(@params.skip));

            TutorialStep lts = new()
            {
                ttrl = TData,
            };

            response.Id = BasePacket.Id;
            response.Result = lts;

            return response;
        }

        private static UserInformationResponse.TutorialData RequestTutorialData(string session, bool skipTutorial)
        {
            UserInformationResponse.TutorialData tutorialData = new() { skip = skipTutorial, step = 0 };

            if (skipTutorial)
            {
                tutorialData.step = 12;
                return DatabaseManager.GameProfile.UpdateTutorialData(session, tutorialData);
            }
            else
            {
                return DatabaseManager.GameProfile.UpdateTutorialData(session, tutorialData);
            }
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