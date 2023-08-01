using System.Text.Json.Serialization;
using Newtonsoft.Json;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.Profile
{
    [Command(Id = CommandId.UpdateTutorialStep)]
    public class UpdateTutorialStep : BaseCommandHandler<UpdateTutorialStepRequest>
    {
        public override string Handle(UpdateTutorialStepRequest @params)
        {

            UpdateTutorialStepInfo utsi = new();

            DatabaseManager.Account.UpdateStep(@params.mIdx, @params.step);

            utsi.step = @params.step;

            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = utsi,
            };

            return JsonConvert.SerializeObject(response);

        }


        public class UpdateTutorialStepInfo
        {
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
