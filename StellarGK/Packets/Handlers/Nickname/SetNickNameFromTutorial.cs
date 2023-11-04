using Newtonsoft.Json;
using StellarGK.Database;
using StellarGKLibrary.Utils;

namespace StellarGK.Host.Handlers.Nickname
{
    [Packet(Id = Method.SetNickNameFromTutorial)]
    public class SetNickNameFromTutorial : BaseMethodHandler<SetNickNameFromTutorialRequest>
    {
        public override object Handle(SetNickNameFromTutorialRequest @params)
        {
            ErrorCode code = RequestNicknameAfterTutorial(GetSession(), @params.Unm);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
            };

            if (code == ErrorCode.InappropriateWords || code == ErrorCode.AlreadyInUse)
            {
                response.Error = new() { code = code };

                return response;
            }

            SetNickNameResponse SetNickNameF1 = new()
            {
                step = @params.Step,
            };

            response.Result = SetNickNameF1;

            return response;
        }

        internal static ErrorCode RequestNicknameAfterTutorial(string sess, string nickname)
        {
            if (Misc.NameCheck(nickname))
            {
                return ErrorCode.InappropriateWords;
            }

            var user = DatabaseManager.GameProfile.FindByNick(nickname);

            if (user == null)
            {
                var userGameProfile = DatabaseManager.GameProfile.FindBySession(sess);

                if (userGameProfile.TutorialData.skip = true)
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
            else if (user.UserResources.nickname == nickname)
            {
                return ErrorCode.AlreadyInUse;
            }

            return 0;
        }

        internal class SetNickNameResponse
        {
            [JsonProperty("step")]
            public int step { get; set; }
        }
    }

    public class SetNickNameFromTutorialRequest
    {
        [JsonProperty("unm")]
        public string Unm { get; set; }

        [JsonProperty("step")]
        public int Step { get; set; }
    }
}