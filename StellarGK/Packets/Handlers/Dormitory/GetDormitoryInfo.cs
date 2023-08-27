using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.Dormitory
{
    [Packet(Id = Method.GetDormitoryInfo)]
    public class GetDormitoryInfo : BaseMethodHandler<GetDormitoryInfoRequest>
    {
        public override object Handle(GetDormitoryInfoRequest @params)
        {
            var dormitoryInfo = GetUserDormitory();

            Logic.Protocols.Dormitory.Info DormitoryInfo = new()
            {
                costumeBody = dormitoryInfo.CostumeBody,
                itemNormal = dormitoryInfo.ItemNormal,
                itemAdvanced = dormitoryInfo.ItemAdvanced,
                itemWallpaper = dormitoryInfo.ItemWallpaper,
                costumeHead = dormitoryInfo.CostumeHead,
                resource = dormitoryInfo.DormitoryResource,
                info = dormitoryInfo.DormitoryInfo
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = DormitoryInfo
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