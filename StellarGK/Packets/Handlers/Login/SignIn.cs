using StellarGK.Database;
using StellarGK.Database.Schemes;
using StellarGK.Tools;
using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.Sign
{
    [Packet(Id = Method.SignIn)]
    public class SignIn : BaseMethodHandler<SignInRequest>
    {
        public override object Handle(SignInRequest @params)
        {
            ResponsePacket response = new();

            ErrorCode code = RequestSignIn(@params.uid, @params.pwd, out SignInP SignInP);

            if (code == ErrorCode.IdNotFound || code == ErrorCode.PasswordInvalid)
            {
                response.Id = BasePacket.Id;
                response.Error = new() { code = code };

                return response;
            }

            response.Id = BasePacket.Id;
            response.Result = SignInP;

            DatabaseManager.Account.UpdateLoginTime(@params.uid);

            return response;

        }
        private static ErrorCode RequestSignIn(string AccountName, string password, out SignInP signInP)
        {
            var password_hash = Crypto.ComputeSha256Hash(password);

            signInP = new();
            if (!DatabaseManager.Account.AccountExists(AccountName))
            {
                return ErrorCode.IdNotFound;
            }

            AccountScheme user = DatabaseManager.Account.FindByName(AccountName);
            if (user.Password_Hash == password_hash)
            {
                DatabaseManager.Account.UpdateLoginTime(user.MemberId);
                signInP.mIdx = user.MemberId;
                signInP.tokn = user.Token;
                signInP.srv = user.LastServerLoggedIn;
                return ErrorCode.Success;
            }
            else
            {
                return ErrorCode.PasswordInvalid;
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

    public class SignInRequest
    {
        [JsonPropertyName("uid")]
        public string uid { get; set; }

        [JsonPropertyName("pwd")]
        public string pwd { get; set; }
    }
}