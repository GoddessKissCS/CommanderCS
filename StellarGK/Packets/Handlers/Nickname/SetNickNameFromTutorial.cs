using System.Text.Json.Serialization;
using StellarGK.Database;
using StellarGK.Tools;

namespace StellarGK.Host.Handlers.Nickname
{
    [Command(Id = CommandId.SetNickNameFromTutorial)]
    public class SetNickNameFromTutorial : BaseCommandHandler<SetNickNameFromTutorialRequest>
    {
        public override object Handle(SetNickNameFromTutorialRequest @params)
        {
            ErrorCode code = RequestNicknameAfterTutorial(GetSession(), @params.Unm);

            ResponsePacket response = new()
            {
                id = BasePacket.Id,
            };


            if (code == ErrorCode.InappropriateWords || code == ErrorCode.AlreadyInUse)
            {
                response.error = new() { code = code };

                return response;
            }

            SetNickNameF SetNickNameF1 = new()
            {
                step = @params.Step,
            };

            response.result = SetNickNameF1;

            return response;
        }

        private static ErrorCode RequestNicknameAfterTutorial(string sess, string nickname)
        {

            if (Misc.NameCheck(nickname))
            {
                return ErrorCode.InappropriateWords;
            }

            var user = DatabaseManager.GameProfile.FindByNick(nickname);

            if (user == null)
            {
                var profile = DatabaseManager.GameProfile.FindBySession(sess);

                if (profile.tutorialData.skip == true)
                {
                    DatabaseManager.GameProfile.UpdateStep(sess, 12);
                }
                else
                {
                    DatabaseManager.GameProfile.UpdateStep(sess, 2);
                }

                DatabaseManager.GameProfile.UpdateNickName(sess, nickname);

                return ErrorCode.Success;
            }
            else if (user.userResources.nickname == nickname)
            {
                return ErrorCode.AlreadyInUse;
            }

            return 0;
        }

        public class SetNickNameF
        {
            [JsonPropertyName("step")]
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