using StellarGK.Logic.Enums;
using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{
    public class Dormitory
    {

        public class Resource
        {
            [JsonPropertyName("drpt")]
            public string __dormitoryPoint { get; set; }

            [JsonPropertyName("wood")]
            public string __wood { get; set; }

            [JsonPropertyName("ston")]
            public string __ston { get; set; }

            [JsonPropertyName("elec")]
            public string __elec { get; set; }
        }


        public class InventoryData
        {
            [JsonPropertyName("deco")]
            public Dictionary<string, int> itemNormal { get; set; }

            [JsonPropertyName("sdeco")]
            public Dictionary<string, int> itemAdvanced { get; set; }

            [JsonPropertyName("wall")]
            public Dictionary<string, int> itemWallpaper { get; set; }

            [JsonPropertyName("bcos")]
            public Dictionary<string, int> costumeBody { get; set; }

            [JsonPropertyName("hcos")]
            public Dictionary<string, List<string>> costumeHead { get; set; }
        }


        public class Info : InventoryData
        {
            [JsonPropertyName("drsoc")]
            public Resource resource { get; set; }

            [JsonPropertyName("duifo")]
            public Dictionary<string, int> info { get; set; }
        }


        public class FloorCommanderInfo
        {
            [JsonPropertyName("cid")]
            public string id { get; set; }

            [JsonPropertyName("lv")]
            public int level { get; set; }

            [JsonPropertyName("grd")]
            public int grade { get; set; }

            [JsonPropertyName("cls")]
            public int cls { get; set; }

            [JsonPropertyName("cos")]
            public int costume { get; set; }
        }


        public class RoomInfo
        {
            [JsonPropertyName("fno")]
            public string fno { get; set; }

            [JsonPropertyName("fnm")]
            public string name { get; set; }

            [JsonPropertyName("fst")]
            public string state { get; set; }

            [JsonPropertyName("cids")]
            public List<string> commanders { get; set; }

            [JsonPropertyName("rtm")]
            public double remain { get; set; }

            [JsonPropertyName("fcom")]
            public List<FloorCommanderInfo> commanderInfos { get; set; }
        }


        public class FloorInfo
        {
            [JsonPropertyName("ptst")]
            public bool pointState { get; set; }

            [JsonPropertyName("fInfo")]
            public Dictionary<string, RoomInfo> floors { get; set; }

            [JsonIgnore]
            public bool isMasterUser { get; set; }
        }


        public class GetUserFloorInfoResponse : FloorInfo
        {
            [JsonPropertyName("tuno")]
            public string uno { get; set; }
        }


        public class ConstructFloorResponse
        {
            [JsonPropertyName("drsoc")]
            public Resource resource { get; set; }

            [JsonPropertyName("fInfo")]
            public Dictionary<string, RoomInfo> floors { get; set; }
        }


        public class FinishConstructFloorResponse
        {
            [JsonPropertyName("rsoc")]
            public UserInformationResponse.Resource resource { get; set; }

            [JsonPropertyName("fInfo")]
            public Dictionary<string, RoomInfo> floors { get; set; }
        }


        public class FloorDecoInfo
        {
            [JsonPropertyName("idx")]
            public string id { get; set; }

            [JsonPropertyName("px")]
            public int px { get; set; }

            [JsonPropertyName("py")]
            public int py { get; set; }

            [JsonPropertyName("rt")]
            public int rotation { get; set; }
        }


        public class FloorCharacterInfo
        {
            [JsonPropertyName("cid")]
            public string id { get; set; }

            [JsonPropertyName("fno")]
            public string fno { get; set; }

            [JsonPropertyName("bcos")]
            public string bodyId { get; set; }

            [JsonPropertyName("hcos")]
            public string headId { get; set; }

            [JsonPropertyName("rtm")]
            public double remain { get; set; }
        }


        public class FloorDetailInfo
        {
            [JsonPropertyName("fno")]
            public string fno { get; set; }

            [JsonPropertyName("fnm")]
            public string name { get; set; }

            [JsonPropertyName("fwp")]
            public string wallpaperId { get; set; }

            [JsonPropertyName("fdc")]
            public List<FloorDecoInfo> decos { get; set; }

            [JsonPropertyName("fcm")]
            public Dictionary<string, FloorCharacterInfo> characters { get; set; }
        }


        public class GetUserFloorDetailInfoResponse : FloorDetailInfo
        {
            [JsonPropertyName("tuno")]
            public string uno { get; set; }

            [JsonPropertyName("favor")]
            public bool favorState { get; set; }
        }


        public class ChangeDormitoryFloorNameResponse
        {
            [JsonPropertyName("rsoc")]
            public UserInformationResponse.Resource resource { get; set; }

            [JsonPropertyName("fnm")]
            public string name { get; set; }
        }


        public class ShopProductItemInfo
        {
            [JsonPropertyName("sidx")]
            public string id { get; set; }

            [JsonPropertyName("amnt")]
            public int amount { get; set; }

            [JsonPropertyName("sort")]
            public int sort { get; set; }

            [JsonPropertyName("gidx")]
            public string goodsId { get; set; }

            [JsonPropertyName("prc")]
            public int cost { get; set; }

            [JsonPropertyName("stm")]
            public double startRemain { get; set; }

            [JsonPropertyName("etm")]
            public double endRemain { get; set; }

            [JsonPropertyName("pcnt")]
            public int buyCount { get; set; }

            [JsonPropertyName("lcnt")]
            public int buyLimit { get; set; }

        }


        public class ShopInfo
        {
            [JsonPropertyName("dshop")]
            public Dictionary<EDormitoryItemType, List<ShopProductItemInfo>> items;
        }


        public class BuyShopProductResponse : RewardInfo
        {
            [JsonPropertyName("dshop")]
            public Dictionary<EDormitoryItemType, ShopProductItemInfo> items { get; set; }
        }


        public class ChangeWallpaperResponse
        {
            [JsonPropertyName("fwp")]
            public string id { get; set; }

            [JsonPropertyName("wall")]
            public Dictionary<string, int> invenWallpaper { get; set; }
        }


        public class ArrangeDecorationResponse
        {
            [JsonPropertyName("deco")]
            public Dictionary<string, int> invenNormal { get; set; }

            [JsonPropertyName("sdeco")]
            public Dictionary<string, int> invenAdvanced { get; set; }
        }


        public class GetDormitoryCommanderInfoResponse
        {
            [JsonPropertyName("dcom")]
            public Dictionary<string, CommanderInfo> commanderData { get; set; }

            [JsonPropertyName("hcos")]
            public Dictionary<string, List<string>> headData { get; set; }
        }


        public class CommanderInfo
        {
            [JsonPropertyName("cid")]
            public string id { get; set; }

            [JsonPropertyName("fno")]
            public string fno { get; set; }

            [JsonPropertyName("rtm")]
            public double reamin { get; set; }
        }


        public class CommanderHeadData
        {
            [JsonPropertyName("hcos")]
            public string headId { get; set; }
        }


        public class CommanderBodyData
        {
            [JsonPropertyName("bcos")]
            public string bodyId { get; set; }
        }


        public class CommanderRaminData
        {
            [JsonPropertyName("rtm")]
            public double remain { get; set; }
        }


        public class ChangeCommanderHeadResponse
        {
            [JsonPropertyName("fcm")]
            public Dictionary<string, CommanderHeadData> headData { get; set; }
        }


        public class ChangeCommanderBodyResponse
        {
            [JsonPropertyName("bcos")]
            public Dictionary<string, int> invenBody { get; set; }

            [JsonPropertyName("fcm")]
            public Dictionary<string, CommanderBodyData> bodyData { get; set; }
        }


        public class GetPointResponse
        {
            [JsonPropertyName("reward")]
            public List<RewardInfo.RewardData> reward { get; set; }

            [JsonPropertyName("drsoc")]
            public Resource resource { get; set; }

            [JsonPropertyName("fcm")]
            public Dictionary<string, CommanderRaminData> reaminData { get; set; }
        }


        public class GetPointAllResponse : GetPointResponse
        {
            [JsonPropertyName("ptst")]
            public bool pointState { get; set; }
        }


        public class SearchUserInfo
        {
            [JsonPropertyName("uno")]
            public string uno { get; set; }

            [JsonPropertyName("wld")]
            public int world { get; set; }

            [JsonPropertyName("unm")]
            public string name { get; set; }

            [JsonPropertyName("thumb")]
            public string thumbnail { get; set; }

            [JsonPropertyName("lv")]
            public int level { get; set; }

            [JsonPropertyName("time")]
            public double lastTime { get; set; }
        }
    }
}
