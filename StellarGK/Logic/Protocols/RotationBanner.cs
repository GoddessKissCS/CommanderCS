using StellarGK.Logic.Enums;
using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class RotationBanner
    {
        [JsonPropertyName("rt")]
        public int roataionTime { get; set; }

        [JsonPropertyName("list")]
        public List<BannerList> bannerList { get; set; }

        public class BannerList
        {
            [JsonPropertyName("imgUrl")]
            public string ImgUrl { get; set; }

            [JsonPropertyName("linkType")]
            public BannerListType linkType { get; set; }

            [JsonPropertyName("linkIdx")]
            public int linkIdx { get; set; }

            [JsonPropertyName("eidx")]
            public int eventIdx { get; set; }

            [JsonPropertyName("sdate")]
            public string startDate { get; set; }

            [JsonPropertyName("edate")]
            public string endDate { get; set; }
        }
    }
}
