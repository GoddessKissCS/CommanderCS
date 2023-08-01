using Newtonsoft.Json;
using StellarGK.Logic.Enums;

namespace StellarGK.Logic.Protocols
{
    public class Dormitory
    {
        [JsonObject(MemberSerialization.OptIn)]
        public class Resource
        {
            [JsonProperty("drpt")]
            public string __dormitoryPoint { get; set; }

            [JsonProperty("wood")]
            public string __wood { get; set; }

            [JsonProperty("ston")]
            public string __ston { get; set; }

            [JsonProperty("elec")]
            public string __elec { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class InventoryData
        {
            [JsonProperty("deco")]
            public Dictionary<string, int> itemNormal { get; set; }

            [JsonProperty("sdeco")]
            public Dictionary<string, int> itemAdvanced { get; set; }

            [JsonProperty("wall")]
            public Dictionary<string, int> itemWallpaper { get; set; }

            [JsonProperty("bcos")]
            public Dictionary<string, int> costumeBody { get; set; }

            [JsonProperty("hcos")]
            public Dictionary<string, List<string>> costumeHead { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class Info : InventoryData
        {
            [JsonProperty("drsoc")]
            public Resource resource { get; set; }

            [JsonProperty("duifo")]
            public Dictionary<string, int> info { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class FloorCommanderInfo
        {
            [JsonProperty("cid")]
            public string id { get; set; }

            [JsonProperty("lv")]
            public int level { get; set; }

            [JsonProperty("grd")]
            public int grade { get; set; }

            [JsonProperty("cls")]
            public int cls { get; set; }

            [JsonProperty("cos")]
            public int costume { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class RoomInfo
        {
            [JsonProperty("fno")]
            public string fno { get; set; }

            [JsonProperty("fnm")]
            public string name { get; set; }

            [JsonProperty("fst")]
            public string state { get; set; }

            [JsonProperty("cids")]
            public List<string> commanders { get; set; }

            [JsonProperty("rtm")]
            public double remain { get; set; }

            [JsonProperty("fcom")]
            public List<FloorCommanderInfo> commanderInfos { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class FloorInfo
        {
            [JsonProperty("ptst")]
            public bool pointState { get; set; }

            [JsonProperty("fInfo")]
            public Dictionary<string, RoomInfo> floors { get; set; }

            [JsonIgnore]
            public bool isMasterUser { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class GetUserFloorInfoResponse : FloorInfo
        {
            [JsonProperty("tuno")]
            public string uno { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class ConstructFloorResponse
        {
            [JsonProperty("drsoc")]
            public Resource resource { get; set; }

            [JsonProperty("fInfo")]
            public Dictionary<string, RoomInfo> floors { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class FinishConstructFloorResponse
        {
            [JsonProperty("rsoc")]
            public UserInformationResponse.Resource resource { get; set; }

            [JsonProperty("fInfo")]
            public Dictionary<string, RoomInfo> floors { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class FloorDecoInfo
        {
            [JsonProperty("idx")]
            public string id { get; set; }

            [JsonProperty("px")]
            public int px { get; set; }

            [JsonProperty("py")]
            public int py { get; set; }

            [JsonProperty("rt")]
            public int rotation { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class FloorCharacterInfo
        {
            [JsonProperty("cid")]
            public string id { get; set; }

            [JsonProperty("fno")]
            public string fno { get; set; }

            [JsonProperty("bcos")]
            public string bodyId { get; set; }

            [JsonProperty("hcos")]
            public string headId { get; set; }

            [JsonProperty("rtm")]
            public double remain { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class FloorDetailInfo
        {
            [JsonProperty("fno")]
            public string fno { get; set; }

            [JsonProperty("fnm")]
            public string name { get; set; }

            [JsonProperty("fwp")]
            public string wallpaperId { get; set; }

            [JsonProperty("fdc")]
            public List<FloorDecoInfo> decos { get; set; }

            [JsonProperty("fcm")]
            public Dictionary<string, FloorCharacterInfo> characters { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class GetUserFloorDetailInfoResponse : FloorDetailInfo
        {
            [JsonProperty("tuno")]
            public string uno { get; set; }

            [JsonProperty("favor")]
            public bool favorState { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class ChangeDormitoryFloorNameResponse
        {
            [JsonProperty("rsoc")]
            public UserInformationResponse.Resource resource { get; set; }

            [JsonProperty("fnm")]
            public string name { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class ShopProductItemInfo
        {
            [JsonProperty("sidx")]
            public string id { get; set; }

            [JsonProperty("amnt")]
            public int amount { get; set; }

            [JsonProperty("sort")]
            public int sort { get; set; }

            [JsonProperty("gidx")]
            public string goodsId { get; set; }

            [JsonProperty("prc")]
            public int cost { get; set; }

            [JsonProperty("stm")]
            public double startRemain { get; set; }

            [JsonProperty("etm")]
            public double endRemain { get; set; }

            [JsonProperty("pcnt")]
            public int buyCount { get; set; }

            [JsonProperty("lcnt")]
            public int buyLimit { get; set; }

        }

        [JsonObject(MemberSerialization.OptIn)]
        public class ShopInfo
        {
            [JsonProperty("dshop")]
            public Dictionary<EDormitoryItemType, List<ShopProductItemInfo>> items;
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class BuyShopProductResponse : RewardInfo
        {
            [JsonProperty("dshop")]
            public Dictionary<EDormitoryItemType, ShopProductItemInfo> items { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class ChangeWallpaperResponse
        {
            [JsonProperty("fwp")]
            public string id { get; set; }

            [JsonProperty("wall")]
            public Dictionary<string, int> invenWallpaper { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class ArrangeDecorationResponse
        {
            [JsonProperty("deco")]
            public Dictionary<string, int> invenNormal { get; set; }

            [JsonProperty("sdeco")]
            public Dictionary<string, int> invenAdvanced { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class GetDormitoryCommanderInfoResponse
        {
            [JsonProperty("dcom")]
            public Dictionary<string, CommanderInfo> commanderData { get; set; }

            [JsonProperty("hcos")]
            public Dictionary<string, List<string>> headData { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class CommanderInfo
        {
            [JsonProperty("cid")]
            public string id { get; set; }

            [JsonProperty("fno")]
            public string fno { get; set; }

            [JsonProperty("rtm")]
            public double reamin { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class CommanderHeadData
        {
            [JsonProperty("hcos")]
            public string headId { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class CommanderBodyData
        {
            [JsonProperty("bcos")]
            public string bodyId { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class CommanderRaminData
        {
            [JsonProperty("rtm")]
            public double remain { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class ChangeCommanderHeadResponse
        {
            [JsonProperty("fcm")]
            public Dictionary<string, CommanderHeadData> headData { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class ChangeCommanderBodyResponse
        {
            [JsonProperty("bcos")]
            public Dictionary<string, int> invenBody { get; set; }

            [JsonProperty("fcm")]
            public Dictionary<string, CommanderBodyData> bodyData { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class GetPointResponse
        {
            [JsonProperty("reward")]
            public List<RewardInfo.RewardData> reward { get; set; }

            [JsonProperty("drsoc")]
            public Resource resource { get; set; }

            [JsonProperty("fcm")]
            public Dictionary<string, CommanderRaminData> reaminData { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class GetPointAllResponse : GetPointResponse
        {
            [JsonProperty("ptst")]
            public bool pointState { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class SearchUserInfo
        {
            [JsonProperty("uno")]
            public string uno { get; set; }

            [JsonProperty("wld")]
            public int world { get; set; }

            [JsonProperty("unm")]
            public string name { get; set; }

            [JsonProperty("thumb")]
            public string thumbnail { get; set; }

            [JsonProperty("lv")]
            public int level { get; set; }

            [JsonProperty("time")]
            public double lastTime { get; set; }
        }
    }
}
