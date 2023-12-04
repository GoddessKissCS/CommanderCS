using CommanderCS.Database;
using CommanderCS.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Tutorial
{
    [Packet(Id = Method.GetTutorialStep)]
    public class GetTutorialStep : BaseMethodHandler<GetTutorialStepRequest>
    {
        public override object Handle(GetTutorialStepRequest @params)
        {
            var user = GetUserGameProfile();

            TutorialStep tutorialStep = new()
            {
                ttrl = user.TutorialData,
            };

            ResponsePacket response = new()
            {
                Result = tutorialStep,
                Id = BasePacket.Id
            };

            return response;
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