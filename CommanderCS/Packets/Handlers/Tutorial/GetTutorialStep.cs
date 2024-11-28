using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Tutorial
{
    [Packet(Id = Method.GetTutorialStep)]
    public class GetTutorialStep : BaseMethodHandler<GetTutorialStepRequest>
    {
        public override object Handle(GetTutorialStepRequest @params)
        {
            TutorialStep tutorialStep = new()
            {
                ttrl = User.TutorialData,
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