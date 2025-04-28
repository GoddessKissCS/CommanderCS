using CommanderCS.MongoDB;
using CommanderCS.Library.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.UserTerm
{
    [Packet(Id = Method.CheckChangeDeviceCode)]
    public class CheckChangeDeviceCode : BaseMethodHandler<CheckChangeDeviceCodeRequest>
    {
        public override object Handle(CheckChangeDeviceCodeRequest @params)
        {
            var result = DatabaseManager.DeviceCode.FindByDeviceCode(@params.dac);

            if (result is null)
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = ErrorCode.InvalidDeviceCode },
                };

                return error;
            }

            var user = DatabaseManager.Account.FindByUid(result.MemberId);

            CheckChangeDeviceCodeResponse CheckChangeDeviceCodeResponse = new()
            {
                plfm = user.Platform,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = CheckChangeDeviceCodeResponse
            };

            return response;
        }

        private class CheckChangeDeviceCodeResponse
        {
            [JsonProperty("plfm")]
            public Platform plfm { get; set; }
        }
    }

    public class CheckChangeDeviceCodeRequest
    {
        [JsonProperty("dac")]
        public string dac { get; set; }

        [JsonProperty("ch")]
        public int ch { get; set; }
    }
}