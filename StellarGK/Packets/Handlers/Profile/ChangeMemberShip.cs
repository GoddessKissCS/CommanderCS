using StellarGK.Database;
using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.Profile
{
    [Packet(MethodId.ChangeMembership)]
    public class ChangeMemberShip : BaseMethodHandler<ChangeMemberShipRequest>
    {
        public override object Handle(ChangeMemberShipRequest @params)
        {
            ResponsePacket response = new();

            // TODO - ??? i dont know

            // SHOULD BE FINISHED?

            ErrorCode code = DatabaseManager.Account.ChangeMemberShip(@params.uid, @params.pwd, @params.plfm, @params.puid, @params.ch);


            if (code == ErrorCode.IdAlreadyExists || code == ErrorCode.InappropriateWords)
            {
                response.Error = new() { code = code };
                response.Id = BasePacket.Id;

                return response;
            }


            response.Id = BasePacket.Id;
            response.Result = "{}";
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

