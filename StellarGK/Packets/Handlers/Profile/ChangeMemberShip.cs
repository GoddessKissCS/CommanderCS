using System.Text.Json.Serialization;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.Profile
{
    [Command(Id = CommandId.ChangeMembership)]
    public class ChangeMemberShip : BaseCommandHandler<ChangeMemberShipRequest>
    {
        public override object Handle(ChangeMemberShipRequest @params)
        {
            ResponsePacket response = new();

            // TODO - ??? i dont know

            // SHOULD BE FINISHED?

            ErrorCode code = DatabaseManager.Account.ChangeMemberShip(@params.uid, @params.pwd, @params.plfm, @params.puid, @params.ch);


            if (code == ErrorCode.IdAlreadyExists || code == ErrorCode.InappropriateWords)
            {
                response.error = new() { code = code };
                response.id = BasePacket.Id;

                return response;
            }


            response.id = BasePacket.Id;
            response.result = "{}";
            return response;


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

