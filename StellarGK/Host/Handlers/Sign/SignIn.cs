using System.Text.Json.Serialization;
using StellarGK.Database;
using StellarGK.Database.Models;
using StellarGK.Utils;

namespace StellarGK.Host.Handlers.Sign
{
    [Command(Id = CommandId.SignIn)]
    public class SignIn : BaseCommandHandler<SignInRequest>
    {
        public override object Handle(SignInRequest @params)
        {
            ResponsePacket response = new();

            ErrorCode code = RequestSignIn(@params.uid, @params.pwd, out SignInP SignInP);

            switch (code)
            {

                case ErrorCode.IdNotFound or ErrorCode.PasswordInvalid:

                    response.id = BasePacket.Id;
                    response.error = new() { code = code };

                    return response;

                default:

                    response.id = BasePacket.Id;
                    response.result = SignInP;

                    return response;

            }

        }
        private static ErrorCode RequestSignIn(string AccountName, string password, out SignInP signInP)
        {
            signInP = new();
            if (!DatabaseManager.Account.AccountExists(AccountName))
            {
                return ErrorCode.IdNotFound;
            }
            else
            {
                AccountScheme user = DatabaseManager.Account.FindByName(AccountName);
                if (user.password == Crypto.ComputeSha256Hash(password))
                {

                    DatabaseManager.Account.UpdateLoginTime(user.Id);

                    signInP.mIdx = user.Id;
                    signInP.tokn = user.token;
                    signInP.srv = user.server;

                    return ErrorCode.Success;
                }
                else
                {
                    return ErrorCode.PasswordInvalid;
                }
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