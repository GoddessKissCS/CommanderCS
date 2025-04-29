using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Sign
{
    [Packet(Id = Method.GuestSignIn)]
    public class GuestSignIn : BaseMethodHandler<GuestSignInRequest>
    {
        public override object Handle(GuestSignInRequest @params)
        {
            var user = DatabaseManager.Account.FindByName(@params.uid);

            SignInP Sign = new();

            if (user is null)
            {
                return Sign;
            }

            DatabaseManager.Account.UpdateLoginTime(user.MemberId);

            Sign.tokn = user.Token;
            Sign.srv = user.LastServerLoggedIn;
            Sign.mIdx = user.MemberId;

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = Sign
            };

            return response;
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