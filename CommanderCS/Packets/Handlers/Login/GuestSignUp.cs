using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Sign
{
    [Packet(Id = Method.GuestSignUp)]
    public class GuestSignUp : BaseMethodHandler<GuestSignUpRequest>
    {
        public override object Handle(GuestSignUpRequest @params)
        {
            var name = RequestSignUp(@params.plfm, @params.ch);

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

        private static string RequestSignUp(int platformid, int channel)
        {
            return DatabaseManager.Account.GetOrCreate("", "", platformid, channel).Name;
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