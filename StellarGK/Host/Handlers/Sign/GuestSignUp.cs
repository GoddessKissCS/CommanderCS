using System.Security.Principal;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.Sign
{
    [Command(Id = CommandId.GuestSignUp)]
    public class GuestSignUp : BaseCommandHandler<GuestSignUpRequest>
    {
        public override string Handle(GuestSignUpRequest @params)
        {

            GuestSignUpPacket SignUp = new()
            {
                uid = RequestSignUp(@params.plfm, @params.ch),
            };

            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = SignUp
            };

            return JsonConvert.SerializeObject(response);
        }


        private static string RequestSignUp(int platformid, int channel)
        {

            var user = DatabaseManager.Account.CreateGuest(platformid, channel);

            DatabaseManager.CreateUser(user.Id);

            return user.name;
        }

        public class GuestSignUpPacket
        {
            public string uid { get; set; }
        }
    }
    public class GuestSignUpRequest
    {
        [JsonPropertyName("ch")]
        public int ch { get; set; }

        [JsonPropertyName("plfm")]
        public int plfm { get; set; }
    }
}