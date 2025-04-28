using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Battle
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Projectile
    {
        [JsonProperty]
        internal int _id;

        [JsonProperty]
        internal bool _isCritical;

        [JsonProperty]
        internal bool _isSplash;

        [JsonProperty]
        internal int _targetIndex;

        [JsonProperty]
        internal int _fireEventIndex;

        [JsonProperty]
        internal int _createdTurn;

        [JsonProperty]
        internal int _elapsedTime;

        [JsonProperty]
        internal int _beHitId;

        [JsonProperty]
        internal string _fireKey;

        [JsonProperty]
        internal string _hitKey;

        [JsonProperty]
        internal string _beHitKey;

        public int id => _id;

        public bool isCritical => _isCritical;

        public bool isSplash => _isSplash;

        public int targetIndex => _targetIndex;

        public int fireEventIndex => _fireEventIndex;

        public int createdTurn => _createdTurn;

        public int elapsedTime => _elapsedTime;

        public string fireKey => _fireKey;

        public string hitKey => _hitKey;

        public string beHitKey => _beHitKey;

        internal Projectile()
        {
        }

        internal static Projectile _Create(int id, int targetIndex, int fireEventIndex, int createdTurn)
        {
            Projectile projectile = new()
            {
                _id = id,
                _isCritical = false,
                _isSplash = false,
                _targetIndex = targetIndex,
                _elapsedTime = -66,
                _fireEventIndex = fireEventIndex,
                _createdTurn = createdTurn,
                _beHitId = -1,
                _fireKey = string.Empty,
                _hitKey = string.Empty,
                _beHitKey = string.Empty
            };

            return projectile;
        }

        internal static Projectile _Copy(Projectile src)
        {
            Projectile projectile = new()
            {
                _id = src._id,
                _isCritical = src._isCritical,
                _isSplash = src._isSplash,
                _targetIndex = src._targetIndex,
                _elapsedTime = src._elapsedTime,
                _fireEventIndex = src._fireEventIndex,
                _createdTurn = src._createdTurn,
                _beHitId = src._beHitId,
                _fireKey = src._fireKey,
                _hitKey = src._hitKey,
                _beHitKey = src._beHitKey
            };

            return projectile;
        }
    }
}