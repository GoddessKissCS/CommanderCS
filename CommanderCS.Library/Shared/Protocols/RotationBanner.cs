using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
    public class RotationBanner
    {
        [JsonProperty("rt")]
        public int roataionTime { get; set; }

        [JsonProperty("list")]
        public List<BannerList> bannerList { get; set; }

        public class BannerList
        {
            [JsonProperty("imgUrl")]
            public string ImgUrl { get; set; }

            [JsonProperty("linkType")]
            public BannerListType linkType { get; set; }

            [JsonProperty("linkIdx")]
            public int linkIdx { get; set; }

            [JsonProperty("eidx")]
            public int eventIdx { get; set; }

            [JsonProperty("sdate")]
            public string startDate { get; set; }

            [JsonProperty("edate")]
            public string endDate { get; set; }
        }
    }
}