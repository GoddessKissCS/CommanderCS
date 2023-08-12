using System.Text.Json.Serialization;
using StellarGK.Host;

namespace StellarGK.Packets.Handlers.Login
{
    [Command(Id = CommandId.FBSignIn)]
    public class FBSignIn : BaseCommandHandler<FBSignInRequest>
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
