using Newtonsoft.Json;

namespace CommanderCS.Host
{
    /// <summary>
    /// Represents the basic template for an error packet.
    /// </summary>
    public class ErrorPacket
    {
        /// <summary>
        /// Gets or sets the identifier of the error packet.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the error message ID of the error packet, see <see cref="ErrorMessageId"/>.
        /// </summary>
        [JsonProperty("error")]
        public ErrorMessageId Error { get; set; }
    }

    /// <summary>
    /// Represents the error message ID.
    /// </summary>
    public class ErrorMessageId
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        [JsonProperty("code")]
        public ErrorCode code { get; set; }
    }

    /// <summary>
    /// Enumeration of error codes.
    /// </summary>
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
        NotEnoughResources_1 = 30003,
        EnteredInappropriateWords = 53010, // SOMEHOW IN BANKROULLETSTART
        FederationSettingsChanged = 71301,
        FederationGuildSettingsChanged = 71302,
        CannotSentMoreThanOneFederationJoinRequest = 71303,
        CannotSentMoreThanTwoFederationRequestsOrBeAccepted = 71110,
        CannotSentTheSameFederationAnRequestAfterBeingDeclientWithin48Hours = 71111,
        CannotSentAnotherFederationAnJoinRequestAfterLeavingForOneHour = 71112,
        CannotPurchauseSinceBuyLimitIsReached = 10128,
        UnknownErrorCode_2 = 10129,
        InsufficientEnergy = 21006,
        InsufficientParticipationEntries = 21007, // Those might be swapped
        FederationNameAlreadyExists = 71005,
        FederationNameContainsBadwordsOrIsInvalid = 71009,
        CannotProceedWithConquestBattleAtThisTime = 71501,
        InappropriateWordsInGuildBoardMessage = 71131,
        FederationSettingsChangedRecently = 71007,
        FederationSettingsChangedRecently_2 = 71018,
        FederationSettingsChangedOnGuildApply = 71301,
        FederationTypeChangedRecently = 71302,
        CannotJoinOrApplyMoreThan1Federation = 71303,
        FederationIsFull = 71305,
        RequestDataHasBeenChanged = 71306,
        FederationSettingsChangedWhileGettingGuildBoard = 71001,
        YouCanOnlyAppointUpTo2SubMaster = 71019,
        YouAlreadyLeftTheFederation = 71001,
        HigherFederationLevelRequired = 71014,
        CantCancelFederationJoinIfYouAlreadyInAFederation = 71304,
        CanOnlyKickUpTo5MemberWithinADayAndNotOnTheJoinDay = 71307,

        ErrorCommanderLevelCannotBeHigher = 90000,
    }
}