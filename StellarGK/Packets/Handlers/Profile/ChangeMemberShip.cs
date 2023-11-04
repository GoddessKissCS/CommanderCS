using Newtonsoft.Json;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.Profile
{
    [Packet(Id = Method.ChangeMembership)]
    public class ChangeMemberShip : BaseMethodHandler<ChangeMemberShipRequest>
    {
        public override object Handle(ChangeMemberShipRequest @params)
        {
            ResponsePacket response = new();

            // SHOULD BE FINISHED?

            ErrorCode code = DatabaseManager.Account.ChangeMemberShip(@params.uid, @params.pwd, @params.plfm, @params.puid, @params.ch);

            if (code == ErrorCode.IdAlreadyExists || code == ErrorCode.InappropriateWords)
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = code },
                };

                return error;
            }

            response.Id = BasePacket.Id;
            response.Result = "{}";
            return response;
        }
    }

    public class ChangeMemberShipRequest
    {
        [JsonProperty("uid")]
        public string uid { get; set; }

        [JsonProperty("pwd")]
        public string pwd { get; set; }

        [JsonProperty("plfm")]
        public int plfm { get; set; }

        [JsonProperty("ch")]
        public int ch { get; set; }

        [JsonProperty("puid")]
        public string puid { get; set; }
    }
}