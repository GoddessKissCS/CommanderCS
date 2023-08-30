using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Battle
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Projectile
    {
        internal Projectile()
        {
        }

        public int id
        {
            get
            {
                return _id;
            }
        }

        public bool isCritical
        {
            get
            {
                return _isCritical;
            }
        }

        public bool isSplash
        {
            get
            {
                return _isSplash;
            }
        }

        public int targetIndex
        {
            get
            {
                return _targetIndex;
            }
        }

        public int fireEventIndex
        {
            get
            {
                return _fireEventIndex;
            }
        }

        public int createdTurn
        {
            get
            {
                return _createdTurn;
            }
        }

        public int elapsedTime
        {
            get
            {
                return _elapsedTime;
            }
        }

        public string fireKey
        {
            get
            {
                return _fireKey;
            }
        }

        public string hitKey
        {
            get
            {
                return _hitKey;
            }
        }

        public string beHitKey
        {
            get
            {
                return _beHitKey;
            }
        }

        internal static Projectile _Create(int id, int targetIndex, int fireEventIndex, int createdTurn)
        {
            return new Projectile
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
        }

        internal static Projectile _Copy(Projectile src)
        {
            return new Projectile
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
        }

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
    }
}
