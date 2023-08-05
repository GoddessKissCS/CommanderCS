using System.Text.Json.Serialization;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.Profile
{
    [Command(Id = CommandId.UpdateTutorialStep)]
    public class UpdateTutorialStep : BaseCommandHandler<UpdateTutorialStepRequest>
    {
        public override object Handle(UpdateTutorialStepRequest @params)
        {

            UpdateTutorialStepInfo utsi = new();

            DatabaseManager.Account.UpdateStep(@params.mIdx, @params.step);

            utsi.step = @params.step;

            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = utsi,
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
