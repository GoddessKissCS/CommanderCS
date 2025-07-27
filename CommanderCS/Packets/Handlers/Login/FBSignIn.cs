using CommanderCS.Library.Enums;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Login
{
    [Packet(Id = Method.FBSignIn)]
    public class FBSignIn : BaseMethodHandler<FBSignInRequest>
    {
        public override object Handle(FBSignInRequest @params)
        {
            // WILL NOT SUPPORT PROBABLY

            return "{}";
        }
    }

    public class FBSignInRequest
    {
        [JsonProperty("tokn")]
        public string tokn { get; set; }

        [JsonProperty("plfm")]
        public int plfm { get; set; }

        [JsonProperty("ch")]
        public int ch { get; set; }
    }
}