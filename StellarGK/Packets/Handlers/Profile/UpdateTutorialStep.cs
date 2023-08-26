using StellarGK.Database;
using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.Profile
{
    [Packet(Id = MethodId.UpdateTutorialStep)]
    public class UpdateTutorialStep : BaseMethodHandler<UpdateTutorialStepRequest>
    {
        public override object Handle(UpdateTutorialStepRequest @params)
        {
            UpdateTutorialStepInfo utsi = new();

            DatabaseManager.GameProfile.UpdateStep(GetSession(), @params.step);

            utsi.step = @params.step;

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = utsi,
            };

            return response;

        }


        public class UpdateTutorialStepInfo
        {
            [JsonPropertyName("step")]
            public int step { get; set; }
        }

    }

    public class UpdateTutorialStepRequest
    {
        [JsonPropertyName("mIdx")]
        public int mIdx { get; set; }

        [JsonPropertyName("step")]
        public int step { get; set; }
    }
}
