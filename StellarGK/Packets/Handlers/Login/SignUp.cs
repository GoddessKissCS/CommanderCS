using Newtonsoft.Json;
using StellarGK.Database;
using StellarGKLibrary.Utils;

namespace StellarGK.Host.Handlers.Sign
{
    [Packet(Id = Method.SignUp)]
    public class SignUp : BaseMethodHandler<SignUpRequest>
    {
        public override object Handle(SignUpRequest @params)
        {
            ResponsePacket response = new()
            {
                Id = BasePacket.Id
            };

            ErrorCode code = RequestSignUp(@params.uid, @params.pwd, @params.plfm, @params.ch);

            if (code == ErrorCode.IdAlreadyExists || code == ErrorCode.InappropriateWords)
            {
                response.Error = new() { code = code };

                return response;
            }

            SignUpPacket SignUp = new()
            {
                uid = @params.uid,
            };

            response.Result = SignUp;

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