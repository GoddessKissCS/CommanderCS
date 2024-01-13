using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using CommanderCSLibrary.Cryptography;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Sign
{
    [Packet(Id = Method.SignIn)]
    public class SignIn : BaseMethodHandler<SignInRequest>
    {
        public override object Handle(SignInRequest @params)
        {
            ErrorCode code = RequestSignIn(@params.uid, @params.pwd, out SignInP SignInP);

            if (code != ErrorCode.Success)
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = code },
                };

                return error;
            }

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = SignInP
            };

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
            [JsonProperty("mIdx")]
            public int mIdx { get; set; }

            [JsonProperty("tokn")]
            public string tokn { get; set; }

            [JsonProperty("srv")]
            public int srv { get; set; }
        }
    }

    public class SignInRequest
    {
        [JsonProperty("uid")]
        public string uid { get; set; }

        [JsonProperty("pwd")]
        public string pwd { get; set; }
    }
}