using System.Text.Json.Serialization;
using StellarGK.Database;
using StellarGK.Utils;

namespace StellarGK.Host.Handlers.Nickname
{
    [Command(Id = CommandId.SetNickNameFromTutorial)]
    public class SetNickNameFromTutorial : BaseCommandHandler<SetNickNameFromTutorialRequest>
    {
        public override object Handle(SetNickNameFromTutorialRequest @params)
        {
            ErrorCode code = RequestNicknameAfterTutorial(BasePacket.Session, @params.Unm);

            ResponsePacket response = new()
            {
                id = BasePacket.Id,
            };


            switch (code)
            {
                case ErrorCode.AlreadyInUse or ErrorCode.InappropriateWords:

                    response.error = new() { code = code };

                    return response;

                default:
                    SetNickNameF SetNickNameF1 = new()
                    {
                        step = @params.Step,
                    };


                    return response;
            }
        }

        private static ErrorCode RequestNicknameAfterTutorial(string sess, string AccountName)
        {

            if (Misc.NameCheck(AccountName))
            {
                return ErrorCode.InappropriateWords;
            }

            var user = DatabaseManager.Resources.FindByNickname(AccountName);

            if (user == null)
            {
                var requestUser = DatabaseManager.Resources.FindBySession(sess);

                var account = DatabaseManager.Account.FindBySession(sess);

                if (account.skip == true)
                {
                    DatabaseManager.Account.UpdateStep(requestUser.Id, 12);
                }
                else
                {
                    DatabaseManager.Account.UpdateStep(requestUser.Id, 2);
                }

                DatabaseManager.Resources.UpdateNickName(AccountName, sess);

                return ErrorCode.Success;
            }
            else if (user.nickname == AccountName)
            {
                return ErrorCode.AlreadyInUse;
            }
            return 0;
        }

        public class SetNickNameF
        {
            public int step { get; set; }
        }
    }


    public class SetNickNameFromTutorialRequest
    {
        [JsonPropertyName("unm")]
        public string Unm { get; set; }

        [JsonPropertyName("step")]
        public int Step { get; set; }
    }
}