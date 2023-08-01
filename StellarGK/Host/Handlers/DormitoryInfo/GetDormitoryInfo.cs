using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Org.BouncyCastle.Bcpg;
using StellarGK.Database;
using StellarGK.Host.Handlers.Nickname;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.DormitoryInfo
{
    [Command(Id = CommandId.GetDormitoryInfo)]
    public class GetDormitoryInfo : BaseCommandHandler<GetDormitoryInfoRequest>
    {

        public override string Handle(GetDormitoryInfoRequest @params)
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

            return JsonConvert.SerializeObject(response);
        }
    }

    public class GetDormitoryInfoRequest
    {
        [JsonPropertyName("type")]
        public List<string> type {  get; set; }
    }
}