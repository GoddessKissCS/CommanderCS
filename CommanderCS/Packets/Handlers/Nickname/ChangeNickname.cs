using CommanderCS.MongoDB;
using CommanderCS.Library.Shared.Enum;
using CommanderCS.Library.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Nickname
{
    [Packet(Id = Method.ChangeNickname)]
    public class ChangeNickname : BaseMethodHandler<ChangeNicknameRequest>
    {
        public override object Handle(ChangeNicknameRequest @params)
        {
            ErrorCode code = DatabaseManager.GameProfile.RequestNickNameChange(@params.nickname, SessionId);

            if (code != ErrorCode.Success)
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = code },
                };

                return error;
            }

            var rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(SessionId);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = new ChangeNicknameResponse()
                {
                    rsoc = rsoc,
                }
            };

            return response;
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