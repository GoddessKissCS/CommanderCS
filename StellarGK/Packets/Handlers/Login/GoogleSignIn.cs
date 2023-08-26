using StellarGK.Host;
using System.Text.Json.Serialization;

namespace StellarGK.Packets.Handlers.Login
{
    [Packet(Id = MethodId.GoogleSignIn)]
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
        [JsonPropertyName("tokn")]
        public string tokn { get; set; }

        [JsonPropertyName("plfm")]
        public int plfm { get; set; }

        [JsonPropertyName("ch")]
        public int ch { get; set; }
    }
}
