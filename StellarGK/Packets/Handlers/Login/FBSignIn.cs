using StellarGK.Host;
using System.Text.Json.Serialization;

namespace StellarGK.Packets.Handlers.Login
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
        [JsonPropertyName("tokn")]
        public string tokn { get; set; }

        [JsonPropertyName("plfm")]
        public int plfm { get; set; }

        [JsonPropertyName("ch")]
        public int ch { get; set; }
    }
}
