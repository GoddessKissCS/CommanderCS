using System.Text.Json.Serialization;
using StellarGK.Database;
using StellarGK.Logic.Protocols;
using StellarGK.Utils;

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

            ErrorCode code = RequestNickNameChange(@params.nickname, BasePacket.Session);

            switch (code)
            {
                case ErrorCode.AlreadyInUse or ErrorCode.InappropriateWords:
                    ;

                    response.error = new() { code = code };

                    return response;


                default:
                    Data data = new()
                    {
                        rsoc = DatabaseManager.Resources.RequestResourcesScheme(BasePacket.Session),
                    };

                    response.result = data;

                    return response;

            }
        }

        private static ErrorCode RequestNickNameChange(string AccountName, string sess)
        {
            if (Misc.NameCheck(AccountName))
            {
                return ErrorCode.InappropriateWords;
            }

            var user = DatabaseManager.Resources.FindByNickname(AccountName);
            if (user == null)
            {
                int cash = Convert.ToInt32(user.cash) - 100;

                DatabaseManager.Resources.UpdateCash(user.Id, cash, false);

                return ErrorCode.Success;

            }
            else if (user.nickname == AccountName)
            {
                return ErrorCode.AlreadyInUse;
            }

            return ErrorCode.Success;
        }

        public class Data
        {
            public UserInformationResponse.Resource rsoc { get; set; }
        }

    }

    public class ChangeNicknameRequest
    {
        [JsonPropertyName("unm")]
        public string nickname { get; set; }

    }
}