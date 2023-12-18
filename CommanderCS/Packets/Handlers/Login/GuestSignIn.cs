using CommanderCS.Database;
using Newtonsoft.Json;
using CommanderCSLibrary.Shared.Enum;

namespace CommanderCS.Host.Handlers.Sign
{
    [Packet(Id = Method.GuestSignIn)]
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

            DatabaseManager.Account.UpdateLoginTime(user.MemberId);

            Sign.tokn = user.Token;
            Sign.srv = user.LastServerLoggedIn;
            Sign.mIdx = user.MemberId;

            return Sign;
        }

        private class SignInP
        {
            [JsonProperty("mIdx")]
            public int mIdx { get; set; }

            [JsonProperty("tokn")]
            public string tokn { get; set; }

            [JsonProperty("srv")]
            public int srv { get; set; }
        }
    }

    public class GuestSignInRequest
    {
        [JsonProperty("uid")]
        public string uid { get; set; }
    }
}