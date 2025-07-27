using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Sign
{
    [Packet(Id = Method.GuestSignUp)]
    public class GuestSignUp : BaseMethodHandler<GuestSignUpRequest>
    {
        public override object Handle(GuestSignUpRequest @params)
        {
            var name = DatabaseManager.Account.CreateGuestAccount(@params.plfm, @params.ch).Name;

            GuestSignUpPacket SignUp = new()
            {
                uid = name,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = SignUp
            };

            return response;
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