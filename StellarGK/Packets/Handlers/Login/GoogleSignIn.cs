using System.Text.Json.Serialization;
using StellarGK.Host;

namespace StellarGK.Packets.Handlers.Login
{
    [Command(Id = CommandId.GoogleSignIn)]
    public class GoogleSignIn : BaseCommandHandler<GoogleSignInRequest>
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
