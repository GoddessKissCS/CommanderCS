using Newtonsoft.Json;
using StellarGK.Database;
using StellarGKLibrary.Protocols;

namespace StellarGK.Host.Handlers.Tutorial
{
    [Packet(Id = Method.GetTutorialStep)]
    public class GetTutorialStep : BaseMethodHandler<GetTutorialStepRequest>
    {
        public override object Handle(GetTutorialStepRequest @params)
        {
            UserInformationResponse.TutorialData tutorialData = RequestTutorialData(GetSession());

            TutorialStep tutorialStep = new()
            {
                ttrl = tutorialData
            };

            ResponsePacket response = new()
            {
                Result = tutorialStep,
                Id = BasePacket.Id
            };

            return response;
        }

        private static UserInformationResponse.TutorialData RequestTutorialData(string sess)
        {
            var user = DatabaseManager.GameProfile.FindBySession(sess).TutorialData;

            return user;
        }

        public class TutorialStep
        {
            [JsonProperty("ttrl")]
            public UserInformationResponse.TutorialData ttrl { get; set; }
        }
    }

    public class GetTutorialStepRequest
    {
    }
}