using StellarGK.Database;
using StellarGK.Logic.Protocols;
using StellarGK.Tools;
using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.Nickname
{
    [Packet(MethodId.ChangeNickname)]
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
                response.Error = new() { code = code };

                return response;
            }

            Data data = new()
            {
                rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(GetSession()),
            };

            response.Result = data;

            return response;

        }

        private static ErrorCode RequestNickNameChange(string AccountName, string sess)
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

        public class Data
        {
            [JsonPropertyName("rsoc")]
            public UserInformationResponse.Resource rsoc { get; set; }
        }

    }

    public class ChangeNicknameRequest
    {
        [JsonPropertyName("unm")]
        public string nickname { get; set; }

    }
}