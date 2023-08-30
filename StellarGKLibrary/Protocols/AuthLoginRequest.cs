using Newtonsoft.Json;
using StellarGKLibrary.Enums;

namespace StellarGKLibrary.Protocols
{

    public class AuthLoginRequest
    {
        [JsonProperty("mIdx")]
        public int memberId { get; set; }

        [JsonProperty("tokn")]
        public string token { get; set; }

        [JsonProperty("wld")]
        public int world { get; set; }

        [JsonProperty("unm")]
        public string userName { get; set; }

        [JsonProperty("plfm")]
        public Platform platform { get; set; }

        [JsonProperty("devc")]
        public string deviceName { get; set; }

        [JsonProperty("dvid")]
        public string deviceId { get; set; }

        [JsonProperty("ptype")]
        public int patchType { get; set; }

        [JsonProperty("oscd")]
        public OSCode osCode { get; set; }

        [JsonProperty("osvr")]
        public string osVersion { get; set; }

        [JsonProperty("gmvr")]
        public string gameVersion { get; set; }

        [JsonProperty("apk")]
        public string apkFileName { get; set; }

        [JsonProperty("psId")]
        public string pushRegistrationId { get; set; }

        [JsonProperty("lang")]
        public string languageCode { get; set; }

        [JsonProperty("ctry")]
        public string countryCode { get; set; }

        [JsonProperty("gpid")]
        public string largoId { get; set; }

        [JsonProperty("ch")]
        public int channel { get; set; }
    }
}
