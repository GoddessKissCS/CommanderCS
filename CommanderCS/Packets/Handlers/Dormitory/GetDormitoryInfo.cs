using CommanderCS.Library.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Dormitory
{
    [Packet(Id = Method.GetDormitoryInfo)]
    public class GetDormitoryInfo : BaseMethodHandler<GetDormitoryInfoRequest>
    {
        public override object Handle(GetDormitoryInfoRequest @params)
        {
            CommanderCS.Library.Shared.Protocols.Dormitory.Info DormitoryInfo = new()
            {
                costumeBody = Dormitory.CostumeBody,
                itemNormal = Dormitory.ItemNormal,
                itemAdvanced = Dormitory.ItemAdvanced,
                itemWallpaper = Dormitory.ItemWallpaper,
                costumeHead = Dormitory.CostumeHead,
                resource = Dormitory.DormitoryResource,
                info = Dormitory.DormitoryInfo
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
        [JsonProperty("type")]
        public List<string> type { get; set; }
    }
}