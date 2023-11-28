using Newtonsoft.Json;
using CommanderCS.Database;
using CommanderCS.Protocols;
using CommanderCS.Utils;

namespace CommanderCS.Host.Handlers.Nickname
{
    [Packet(Id = Method.ChangeNickname)]
    public class ChangeNickname : BaseMethodHandler<ChangeNicknameRequest>
    {
        public override object Handle(ChangeNicknameRequest @params)
        {
            ResponsePacket response = new()
            {
                Id = BasePacket.Id
            };

            ErrorCode code = RequestNickNameChange(@params.nickname, GetSession());

            if (code == ErrorCode.AlreadyInUse || code == ErrorCode.InappropriateWords)
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = code },
                };

                return error;
            }

            ChangeNicknameResponse data = new()
            {
                rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(GetSession()),
            };

            response.Result = data;

            return response;
        }

        internal static ErrorCode RequestNickNameChange(string AccountName, string sess)
        {
            if (Misc.NameCheck(AccountName))
            {
                return ErrorCode.InappropriateWords;
            }

            var user = DatabaseManager.GameProfile.FindByNick(AccountName);
            if (user == null)
            {
                int cash = user.UserResources.cash - 100;

                DatabaseManager.GameProfile.UpdateCash(sess, cash, false);

                return ErrorCode.Success;
            }
            else if (user.UserResources.nickname == AccountName)
            {
                return ErrorCode.AlreadyInUse;
            }

            return ErrorCode.Success;
        }

        internal class ChangeNicknameResponse
        {
            [JsonProperty("rsoc")]
            public UserInformationResponse.Resource rsoc { get; set; }
        }
    }

    public class ChangeNicknameRequest
    {
        [JsonProperty("unm")]
        public string nickname { get; set; }
    }
}