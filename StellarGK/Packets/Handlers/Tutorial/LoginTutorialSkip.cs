using System.Text.Json.Serialization;
using StellarGK.Database;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Tutorial
{
    [Command(Id = CommandId.LoginTutorialSkip)]
    public class LoginTutorialSkip : BaseCommandHandler<LoginTutorialSkipRequest>
    {

        public override object Handle(LoginTutorialSkipRequest @params)
        {
            ResponsePacket response = new();

            UserInformationResponse.TutorialData TData = RequestTutorialData(GetSession(), Convert.ToBoolean(@params.skip));

            TutorialStep lts = new()
            {
                ttrl = TData,
            };

            response.id = BasePacket.Id;
            response.result = lts;

            return response;
        }

        private static UserInformationResponse.TutorialData RequestTutorialData(string session, bool skipTutorial)
        {
            UserInformationResponse.TutorialData tutorialData = new() { skip = skipTutorial , step = 0};

            if (skipTutorial)
            {
                tutorialData.step = 12;
                return DatabaseManager.GameProfile.UpdateStepAndSkip(session, tutorialData);
            }
            else
            {
                return DatabaseManager.GameProfile.UpdateStepAndSkip(session, tutorialData);

            }
        }

        private class TutorialStep
        {
            [JsonPropertyName("ttrl")]
            public UserInformationResponse.TutorialData ttrl { get; set; }
        }
    }

    public class LoginTutorialSkipRequest
    {
        [JsonPropertyName("skip")]
        public int skip { get; set; }
    }
}