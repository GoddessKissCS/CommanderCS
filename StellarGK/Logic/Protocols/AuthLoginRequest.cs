using StellarGK.Logic.Enums;
using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class AuthLoginRequest
    {
        [JsonPropertyName("mIdx")]
        public int memberId { get; set; }

        [JsonPropertyName("tokn")]
        public string token { get; set; }

        [JsonPropertyName("wld")]
        public int world { get; set; }

        [JsonPropertyName("unm")]
        public string userName { get; set; }

        [JsonPropertyName("plfm")]
        public Platform platform { get; set; }

        [JsonPropertyName("devc")]
        public string deviceName { get; set; }

        [JsonPropertyName("dvid")]
        public string deviceId { get; set; }

        [JsonPropertyName("ptype")]
        public int patchType { get; set; }

        [JsonPropertyName("oscd")]
        public OSCode osCode { get; set; }

        [JsonPropertyName("osvr")]
        public string osVersion { get; set; }

        [JsonPropertyName("gmvr")]
        public string gameVersion { get; set; }

        [JsonPropertyName("apk")]
        public string apkFileName { get; set; }

        [JsonPropertyName("psId")]
        public string pushRegistrationId { get; set; }

        [JsonPropertyName("lang")]
        public string languageCode { get; set; }

        [JsonPropertyName("ctry")]
        public string countryCode { get; set; }

        [JsonPropertyName("gpid")]
        public string largoId { get; set; }

        [JsonPropertyName("ch")]
        public int channel { get; set; }
    }
}
