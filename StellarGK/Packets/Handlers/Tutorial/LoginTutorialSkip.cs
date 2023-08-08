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

        private static UserInformationResponse.TutorialData RequestTutorialData(string sess, bool skipTutorial)
        {
            var user = DatabaseManager.Account.FindBySession(sess);

            if (skipTutorial)
            {
                DatabaseManager.Account.UpdateStepAndSkip(user.Id, 12, skipTutorial);
                return new UserInformationResponse.TutorialData() { skip = true, step = 12 };
            }
            else
            {
                DatabaseManager.Account.UpdateStepAndSkip(user.Id, 0, skipTutorial);
                return new UserInformationResponse.TutorialData() { skip = false, step = 0 };

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