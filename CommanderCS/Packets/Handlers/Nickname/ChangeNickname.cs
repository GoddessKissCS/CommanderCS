using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Nickname
{
    [Packet(Id = Method.ChangeNickname)]
    public class ChangeNickname : BaseMethodHandler<ChangeNicknameRequest>
    {
        public override object Handle(ChangeNicknameRequest @params)
        {
            var session = GetSession();

            ErrorCode code = DatabaseManager.GameProfile.RequestNickNameChange(@params.nickname, BasePacket.SessionId);

            if (code != ErrorCode.Success)
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = code },
                };

                return error;
            }

            var rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(session);

            ChangeNicknameResponse data = new()
            {
                rsoc = rsoc,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = data
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