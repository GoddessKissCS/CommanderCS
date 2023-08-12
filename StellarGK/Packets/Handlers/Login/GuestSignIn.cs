using System.Text.Json.Serialization;
using StellarGK.Database;

namespace StellarGK.Host.Handlers.Sign
{
    [Command(Id = CommandId.GuestSignIn)]
    public class GuestSignIn : BaseCommandHandler<GuestSignInRequest>
    {
        public override object Handle(GuestSignInRequest @params)
        {

            SignInP SignInP = RequestSignIn(@params.uid);

            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = SignInP
            };

            return response;

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
                DatabaseManager.Account.UpdateLoginTime(user.memberId);

                Sign.tokn = user.token;
                Sign.srv = user.lastServerLoggedIn;
                Sign.mIdx = user.memberId;

                return Sign;
            }
        }

        private class SignInP
        {
            [JsonPropertyName("mIdx")]
            public int mIdx { get; set; }
            [JsonPropertyName("tokn")]
            public string tokn { get; set; }
            [JsonPropertyName("srv")]
            public int srv { get; set; }
        }
    }

    public class GuestSignInRequest
    {
        [JsonPropertyName("uid")]
        public string uid { get; set; }
    }
}