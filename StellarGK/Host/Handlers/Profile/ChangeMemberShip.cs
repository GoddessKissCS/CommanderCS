using System.Text.Json.Serialization;
using Newtonsoft.Json;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.Profile
{
    [Command(Id = CommandId.ChangeMembership)]
    public class ChangeMemberShip : BaseCommandHandler<ChangeMemberShipRequest>
    {
        public override string Handle(ChangeMemberShipRequest @params)
        {
            ResponsePacket response = new();

            // TODO - ??? i dont know
            ErrorCode code = DatabaseManager.Account.ChangeMemberShip(@params.uid, @params.pwd, @params.plfm, @params.puid, @params.ch);

            switch (code)
            {

                case ErrorCode.IdAlreadyExists or ErrorCode.InappropriateWords:

                    response.error = new() { code = code };
                    response.id = BasePacket.Id;

                    return JsonConvert.SerializeObject(response);

                default:
                    response.id = BasePacket.Id;
                    response.result = "{}";
                    return JsonConvert.SerializeObject(response);
            }


        }
    }

    public class ChangeMemberShipRequest
    {
        [JsonPropertyName("uid")]
        public string uid { get; set; }

        [JsonPropertyName("pwd")]
        public string pwd { get; set; }

        [JsonPropertyName("plfm")]
        public int plfm { get; set; }

        [JsonPropertyName("ch")]
        public int ch { get; set; }

        [JsonPropertyName("puid")]
        public string puid { get; set; }
    }
}

