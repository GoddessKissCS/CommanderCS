using System.Text.Json.Serialization;
using Newtonsoft.Json;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.Sign
{
    [Command(Id = CommandId.GuestSignIn)]
    public class GuestSign : BaseCommandHandler<GuestSignRequest>
    {
        public override string Handle(GuestSignRequest @params)
        {

            SignInP SignInP = RequestSignIn(@params.uid);

            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = SignInP
            };

            return JsonConvert.SerializeObject(response);

        }

        private static SignInP RequestSignIn(string uid)
        {
            SignInP Sign = new();
            var user = DatabaseManager.Account.FindByName(uid);

            if (user == null)
            {
                return Sign;
            }
            else
            {
                DatabaseManager.Account.UpdateLoginTime(user.Id);

                Sign.tokn = user.token;
                Sign.srv = user.server;
                Sign.mIdx = user.Id;

                return Sign;
            }
        }

        private class SignInP
        {
            public int mIdx { get; set; }
            public string tokn { get; set; }

            public int srv { get; set; }
        }
    }

    public class GuestSignRequest
    {
        [JsonPropertyName("uid")]
        public string uid { get; set; }
    }
}