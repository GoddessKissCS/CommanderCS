using Newtonsoft.Json;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.Sign
{
    [Packet(Id = Method.GuestSignUp)]
    public class GuestSignUp : BaseMethodHandler<GuestSignUpRequest>
    {
        public override object Handle(GuestSignUpRequest @params)
        {

            GuestSignUpPacket SignUp = new()
            {
                uid = RequestSignUp(@params.plfm, @params.ch),
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = SignUp
            };

            return response;
        }

        private static string RequestSignUp(int platformid, int channel)
        {
            return DatabaseManager.Account.Create("", "", platformid, channel).Name;
        }

        public class GuestSignUpPacket
        {
            [JsonProperty("uid")]
            public string uid { get; set; }
        }
    }
    public class GuestSignUpRequest
    {
        [JsonProperty("ch")]
        public int ch { get; set; }

        [JsonProperty("plfm")]
        public int plfm { get; set; }
    }
}