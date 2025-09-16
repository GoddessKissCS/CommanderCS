using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Tutorial
{
    [Packet(Id = Method.GetTutorialStep)]
    public class GetTutorialStep : BaseMethodHandler<GetTutorialStepRequest>
    {
        public override object Handle(GetTutorialStepRequest @params)
        {
            GameProfileScheme User = GetUserGameProfile();

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