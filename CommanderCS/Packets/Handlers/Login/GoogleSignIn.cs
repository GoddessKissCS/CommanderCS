using Newtonsoft.Json;
using CommanderCS.Host;

namespace CommanderCS.Packets.Handlers.Login
{
    [Packet(Id = Method.GoogleSignIn)]
    public class GoogleSignIn : BaseMethodHandler<GoogleSignInRequest>
    {
        public override object Handle(GoogleSignInRequest @params)
        {
            // WILL NOT SUPPORT PROBABLY

            return "{}";
        }
    }

    public class GoogleSignInRequest
    {
        [JsonProperty("tokn")]
        public string tokn { get; set; }

        [JsonProperty("plfm")]
        public int plfm { get; set; }

        [JsonProperty("ch")]
        public int ch { get; set; }
    }
}