using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Bank
{
    [Packet(Id = Method.BankRoulletStart)]
    public class BankRoulletStart : BaseMethodHandler<BankRoulletStartRequest>
    {
        // Valid spin counts the client can request, matched to their cash cost.
        private static readonly Dictionary<int, int> SpinCostByCashPerCount = new()
        {
            { 1,  10  },
            { 10, 100 },
        };

        public override object Handle(BankRoulletStartRequest request)
        {
            if (!SpinCostByCashPerCount.TryGetValue(request.count, out int cashCost))
            {
                throw new InvalidOperationException($"Invalid spin count: {request.count}");
            }

            GameProfileScheme userProfile = DatabaseManager.GameProfile.FindBySession(SessionId)
                ?? throw new InvalidOperationException($"No profile found for session {SessionId}");

            int resourceIndex = request.vidx;

            int currentSpinStock = DatabaseManager.GameProfile.GetVipRechargeCount(SessionId, resourceIndex);

            int remainingSpins = currentSpinStock - request.count;
            if (remainingSpins < 0)
            {
                throw new InvalidOperationException(
                    $"Insufficient spin stock. Has {currentSpinStock}, requested {request.count}.");
            }

            SpinOutcome luck = ComputeSpinResults(request.count, userProfile.Resources.level);

            DatabaseManager.GameProfile.UpdateVipRechargeCount(SessionId, resourceIndex, remainingSpins);
            DatabaseManager.GameProfile.UpdateOnlyCash(SessionId, cashCost, false);
            DatabaseManager.GameProfile.UpdateGold(SessionId, luck.GoldReward, true);

            UserInformationResponse.Resource rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(SessionId);

            return new ResponsePacket
            {
                Id = BasePacket.Id,
                Result = new BankRoulletResponse
                {
                    Resources = rsoc,
                    LuckResults = luck.SpinValues,
                    Count = remainingSpins,
                }
            };
        }
        private static SpinOutcome ComputeSpinResults(int spinCount, int userLevel)
        {
            var spinValues = RandomGenerator.BankRoulletLuck(spinCount);

            var levelEntry = RemoteObjectManager.instance.regulation.userLevelDtbl
                .FirstOrDefault(x => x.level == userLevel);

            if (levelEntry is null)
            {
                throw new InvalidOperationException(
                    $"No bank gold entry found for user level {userLevel}.");
            }

            int totalGold = spinValues.Sum() * levelEntry.bankGold;

            return new SpinOutcome(spinValues, totalGold);
        }

        private sealed record SpinOutcome(List<int> SpinValues, int GoldReward);
        public class BankRoulletResponse
        {
            [JsonProperty("rsoc")]
            public UserInformationResponse.Resource Resources { get; set; }

            [JsonProperty("cnt")]
            public int Count { get; set; }

            [JsonProperty("luck")]
            public List<int> LuckResults { get; set; }
        }
    }

    public class BankRoulletStartRequest
    {
        [JsonProperty("cnt")]
        public int count { get; set; }

        [JsonProperty("vidx")]
        public int vidx { get; set; }

        [JsonProperty("vcnt")]
        public int vcnt { get; set; }
    }
}
