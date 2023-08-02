using System.Text.Json.Serialization;
using StellarGK.Database;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.DormitoryInfo
{
    [Command(Id = CommandId.GetDormitoryInfo)]
    public class GetDormitoryInfo : BaseCommandHandler<GetDormitoryInfoRequest>
    {

        public override object Handle(GetDormitoryInfoRequest @params)
        {
            var dormitoryInfo = DatabaseManager.Dormitory.FindBySession(BasePacket.Session);

            Dormitory.Info DormitoryInfo = new()
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