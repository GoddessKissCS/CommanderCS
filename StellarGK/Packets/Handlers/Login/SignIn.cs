﻿using System.Text.Json.Serialization;
using StellarGK.Database;
using StellarGK.Database.Schemes;
using StellarGK.Tools;

namespace StellarGK.Host.Handlers.Sign
{
    [Command(Id = CommandId.SignIn)]
    public class SignIn : BaseCommandHandler<SignInRequest>
    {
        public override object Handle(SignInRequest @params)
        {
            ResponsePacket response = new();

            ErrorCode code = RequestSignIn(@params.uid, @params.pwd, out SignInP SignInP);

            if (code == ErrorCode.IdNotFound || code == ErrorCode.PasswordInvalid)
            {
                response.id = BasePacket.Id;
                response.error = new() { code = code };

                return response;
            }

            response.id = BasePacket.Id;
            response.result = SignInP;


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
            else
            {
                AccountScheme user = DatabaseManager.Account.FindByName(AccountName);
                if (user.password == password_hash)
                {
                    DatabaseManager.Account.UpdateLoginTime(user.memberId);
                    signInP.mIdx = user.memberId;
                    signInP.tokn = user.token;
                    signInP.srv = user.lastServerLoggedIn;
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