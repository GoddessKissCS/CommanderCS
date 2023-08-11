using System.Text.Json.Serialization;
using StellarGK.Database;
using StellarGK.Logic.Protocols;
using StellarGK.Tools;

namespace StellarGK.Host.Handlers.Nickname
{
    [Command(Id = CommandId.ChangeNickname)]
    public class ChangeNickname : BaseCommandHandler<ChangeNicknameRequest>
    {
        public override object Handle(ChangeNicknameRequest @params)
        {

            ResponsePacket response = new()
            {
                id = BasePacket.Id
            };

            ErrorCode code = RequestNickNameChange(@params.nickname, GetSession());


            if (code == ErrorCode.AlreadyInUse || code == ErrorCode.InappropriateWords)
            {
                response.error = new() { code = code };

                return response;
            }

            Data data = new()
            {
                rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(GetSession()),
            };

            response.result = data;

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
                int cash = user.userResources.cash - 100;

                DatabaseManager.GameProfile.UpdateCash(sess, cash, false);

                return ErrorCode.Success;

            }
            else if (user.userResources.nickname == AccountName)
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