using CommanderCS.Database;
using CommanderCS.Utils;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Sign
{
    [Packet(Id = Method.SignUp)]
    public class SignUp : BaseMethodHandler<SignUpRequest>
    {
        public override object Handle(SignUpRequest @params)
        {
            ErrorCode code = RequestSignUp(@params.uid, @params.pwd, @params.plfm, @params.ch);

            if (code != ErrorCode.Success)
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = code },
                };

                return error;
            }

            SignUpPacket SignUp = new()
            {
                uid = @params.uid,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = SignUp
            };

            return response;
        }

        private static ErrorCode RequestSignUp(string accountname, string password, int platformid, int channel)
        {
            if (Misc.NameCheck(accountname))
            {
                return ErrorCode.InappropriateWords;
            }

            var user = DatabaseManager.Account.FindByName(accountname);

            if (user == null)
            {
                DatabaseManager.Account.Create(accountname, password, platformid, channel);

                return ErrorCode.Success;
            }
            else
            {
                return ErrorCode.IdAlreadyExists;
            }
        }

        private class SignUpPacket
        {
            [JsonProperty("uid")]
            public string uid { get; set; }
        }
    }

    public class SignUpRequest
    {
        [JsonProperty("uid")]
        public string uid { get; set; }

        [JsonProperty("pwd")]
        public string pwd { get; set; }

        [JsonProperty("plfm")]
        public int plfm { get; set; }

        [JsonProperty("ch")]
        public int ch { get; set; }
    }
}