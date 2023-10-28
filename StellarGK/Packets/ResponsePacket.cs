using Newtonsoft.Json;

namespace StellarGK.Host
{
    public class ResponsePacket
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty(propertyName: "result", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public object Result { get; set; }

        [JsonProperty(propertyName: "error", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ErrorMessageId Error { get; set; }
    }

    public class ErrorMessageId
    {
        [JsonProperty("code")]
        public ErrorCode code { get; set; }
    }

    public enum ErrorCode : int
    {
        UserNotFound = -1,
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
        EnteredInappropriateWords = 53010, // SOMEHOW IN BANKROULLETSTART
        FederationSettingsChanged = 71301,
        FederationGuildSettingsChanged = 71302,
        CannotSentMoreThanOneFederationJoinRequest = 71303,
        CannotSentMoreThanTwoFederationRequestsOrBeAccepted = 71110,
        CannotSentTheSameFederationAnRequestAfterBeingDeclientWithin48Hours = 71111,
        CannotSentAnotherFederationAnJoinRequestAfterLeavingForOneHour = 71112,
    }
}