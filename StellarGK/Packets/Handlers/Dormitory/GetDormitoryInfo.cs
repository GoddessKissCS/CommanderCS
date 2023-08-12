using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.Dormitory
{
    [Command(Id = CommandId.GetDormitoryInfo)]
    public class GetDormitoryInfo : BaseCommandHandler<GetDormitoryInfoRequest>
    {
        public override object Handle(GetDormitoryInfoRequest @params)
        {
            var dormitoryInfo = GetDormitory();

            Logic.Protocols.Dormitory.Info DormitoryInfo = new()
            {
                costumeBody = dormitoryInfo.costumeBody,
                itemNormal = dormitoryInfo.itemNormal,
                itemAdvanced = dormitoryInfo.itemAdvanced,
                itemWallpaper = dormitoryInfo.itemWallpaper,
                costumeHead = dormitoryInfo.costumeHead,

                resource = dormitoryInfo.dormitoryResource,
                info = dormitoryInfo.dormitoryInfo
            };

            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = DormitoryInfo
            };

            return response;
        }
    }

    public class GetDormitoryInfoRequest
    {
        [JsonPropertyName("type")]
        public List<string> type { get; set; }
    }
}