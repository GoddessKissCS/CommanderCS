using Newtonsoft.Json;

namespace StellarGK.Host
{
    public class ResponsePacket
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("result", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public object result { get; set; }
        [JsonProperty("error", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ErrorMessageId error { get; set; }
    }
    public class ErrorMessageId
    {
        public ErrorCode code { get; set; }

    }
    public enum ErrorCode : int
    {
        Failure = 0,
        Success = 1,
        UnableToJoin = 10015,
        IdAlreadyExists = 10014,
        IdNotFound = 10016,
        PasswordInvalid = 10018,
        BannedOrSuspended = 19999,
        AlreadyInUse = 20005,
        InappropriateWords = 20014,
        InvalidDeviceCode = 10024,
        NotEnoughResources = 20001,
        CommanderCantLevelHigherThanUser = 20003
    }
}
