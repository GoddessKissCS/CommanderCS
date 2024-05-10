using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Tutorial
{
    [Packet(Id = Method.LoginTutorialSkip)]
    public class LoginTutorialSkip : BaseMethodHandler<LoginTutorialSkipRequest>
    {
        public override object Handle(LoginTutorialSkipRequest @params)
        {

            UserInformationResponse.TutorialData tutorialData = new() { skip = Convert.ToBoolean(@params.skip), step = 12 };

            DatabaseManager.GameProfile.UpdateTutorialData(Session, tutorialData);

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