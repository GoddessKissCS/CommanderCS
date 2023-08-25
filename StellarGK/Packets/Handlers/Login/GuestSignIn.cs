using StellarGK.Database;
using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.Sign
{
    [Packet(MethodId.GuestSignIn)]
    public class GuestSignIn : BaseMethodHandler<GuestSignInRequest>
    {
        public override object Handle(GuestSignInRequest @params)
        {

            SignInP SignInP = RequestSignIn(@params.uid);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = SignInP
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
                DatabaseManager.Account.UpdateLoginTime(user.MemberId);

                Sign.tokn = user.Token;
                Sign.srv = user.LastServerLoggedIn;
                Sign.mIdx = user.MemberId;

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