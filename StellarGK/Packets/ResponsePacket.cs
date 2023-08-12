using System.Text.Json.Serialization;

namespace StellarGK.Host
{
    public class ResponsePacket
    {
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("result")]
        public object result { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("error")]
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
        CommanderCantLevelHigherThanUser = 20003,
        TimedOut = 70003,
        UnknownErrorCode_1 = 30003,
    }
}
