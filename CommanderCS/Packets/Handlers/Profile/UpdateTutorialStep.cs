using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Profile
{
    [Packet(Id = Method.UpdateTutorialStep)]
    public class UpdateTutorialStep : BaseMethodHandler<UpdateTutorialStepRequest>
    {
        public override object Handle(UpdateTutorialStepRequest request)
        {
            DatabaseManager.GameProfile.UpdateTutorialStep(SessionId, request.step);

            UpdateTutorialStepInfo utsi = new()
            {
                step = request.step
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = utsi,
            };

            return response;
        }

        public class UpdateTutorialStepInfo
        {
            [JsonProperty("step")]
            public int step { get; set; }
        }
    }

    public class UpdateTutorialStepRequest
    {
        [JsonProperty("mIdx")]
        public int mIdx { get; set; }

        [JsonProperty("step")]
        public int step { get; set; }
    }
}