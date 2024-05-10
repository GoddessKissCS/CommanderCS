using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Profile
{
    [Packet(Id = Method.UpdateTutorialStep)]
    public class UpdateTutorialStep : BaseMethodHandler<UpdateTutorialStepRequest>
    {
        public override object Handle(UpdateTutorialStepRequest @params)
        {
            DatabaseManager.GameProfile.UpdateTutorialStep(Session, @params.step);

            UpdateTutorialStepInfo utsi = new()
            {
                step = @params.step
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