using CommanderCSLibrary.Shared.Battle;
using CommanderCSLibrary.Shared.Ro;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCSLibrary.Shared
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Troop
    {
        [JsonObject]
        public class Slot
        {
            [JsonObject]
            public class Skill
            {
                [JsonProperty("id")]
                public string id;

                [JsonProperty("lv")]
                public int lv;

                [JsonProperty("sp")]
                public int sp;

                [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
                public Dictionary<int, Status> status;

                [JsonProperty("turn", NullValueHandling = NullValueHandling.Ignore)]
                public string turn;

                public static Skill Copy(Skill src)
                {
                    Skill skill = new()
                    {
                        id = src.id,
                        lv = src.lv,
                        sp = src.sp
                    };
                    return skill;
                }

                public static explicit operator JToken(Skill value)
                {
                    JArray jArray = [value.id, value.lv, value.sp];
                    return jArray;
                }

                public static explicit operator Skill(JToken value)
                {
                    Skill skill = new()
                    {
                        id = (string)value[0],
                        lv = (int)value[1],
                        sp = (int)value[2]
                    };
                    return skill;
                }
            }

            [JsonObject]
            public class Item
            {
                [JsonProperty("id")]
                public string id;

                [JsonProperty("lv")]
                public int lv;

                public static Item Create(RoItem roItem)
                {
                    Item item = new()
                    {
                        id = roItem.id,
                        lv = roItem.level
                    };
                    return item;
                }

                public static Item Copy(Item src)
                {
                    Item item = new()
                    {
                        id = src.id,
                        lv = src.lv
                    };
                    return item;
                }

                public static explicit operator JToken(Item value)
                {
                    JArray jArray = [value.id, value.lv];
                    return jArray;
                }

                public static explicit operator Item(JToken value)
                {
                    Item item = new()
                    {
                        id = (string)value[0],
                        lv = (int)value[1]
                    };
                    return item;
                }
            }

            [JsonProperty("id")]
            public string id;

            [JsonProperty("cid")]
            public string cid;

            [JsonProperty("ctyp")]
            public int charType;

            [JsonProperty("midx")]
            public int mainIdx;

            [JsonProperty("pidx")]
            public int partIdx;

            [JsonProperty("rnk")]
            public int rank;

            [JsonProperty("cls")]
            public int cls;

            [JsonProperty("lv")]
            public int level;

            [JsonProperty("cos")]
            public int costume;

            [JsonProperty("rsf")]
            public int favorRewardStep;

            [JsonProperty("mry")]
            public int marry;

            [JsonProperty("exp")]
            public int exp;

            [JsonProperty("pos")]
            public int pos;

            [JsonProperty("hp")]
            public int health;

            [JsonProperty("dmghp")]
            public int damagedHealth;

            [JsonProperty("dict")]
            public int dropItemCnt;

            [JsonProperty("skills")]
            public List<Skill> skills;

            [JsonProperty("itms")]
            public Dictionary<int, Item> equipItem;

            [JsonProperty("wepns")]
            public Dictionary<int, Item> weaponItem;

            [JsonProperty("tsdc")]
            public List<int> transcendence;

            [JsonIgnore]
            public float scale;

            [JsonIgnore]
            public long statsAttack;

            [JsonIgnore]
            public long statsHealing;

            [JsonIgnore]
            public long statsDefense;

            [JsonIgnore]
            public bool isEmpty => string.IsNullOrEmpty(id);

            public Slot()
            {
                id = string.Empty;
                cid = string.Empty;
                charType = 0;
                rank = 1;
                cls = 1;
                level = 1;
                costume = 0;
                favorRewardStep = 0;
                marry = 0;
                exp = 0;
                pos = 0;
                health = 0;
                damagedHealth = 0;
                dropItemCnt = 0;
                scale = 1f;
                mainIdx = 0;
                partIdx = 0;
                statsAttack = 0L;
                statsHealing = 0L;
                statsDefense = 0L;
                skills = [];
                equipItem = [];
                weaponItem = [];
                transcendence = [];
            }

            public static Slot Copy(Slot src)
            {
                Slot slot = new()
                {
                    id = src.id,
                    health = src.health,
                    level = src.level,
                    rank = src.rank,
                    cid = src.cid,
                    cls = src.cls,
                    costume = src.costume,
                    favorRewardStep = src.favorRewardStep,
                    marry = src.marry,
                    dropItemCnt = src.dropItemCnt,
                    scale = src.scale,
                    charType = src.charType,
                    mainIdx = src.mainIdx,
                    partIdx = src.partIdx,
                    statsAttack = src.statsAttack,
                    statsDefense = src.statsDefense,
                    statsHealing = src.statsHealing,
                };
                if (src.skills != null)
                {
                    for (int i = 0; i < src.skills.Count; i++)
                    {
                        slot.skills.Add(Skill.Copy(src.skills[i]));
                    }
                }
                if (src.equipItem != null)
                {
                    Dictionary<int, Item>.Enumerator enumerator = src.equipItem.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        slot.equipItem.Add(enumerator.Current.Key, Item.Copy(enumerator.Current.Value));
                    }
                }
                if (src.weaponItem != null)
                {
                    Dictionary<int, Item>.Enumerator enumerator2 = src.weaponItem.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        slot.weaponItem.Add(enumerator2.Current.Key, Item.Copy(enumerator2.Current.Value));
                    }
                }
                if (src.transcendence != null)
                {
                    slot.transcendence.AddRange(src.transcendence);
                }
                return slot;
            }

            public static explicit operator JToken(Slot value)
            {
                if (value == null)
                {
                    return string.Empty;
                }
                JArray jArray =
                [
                    value.id,
                    value.cid,
                    value.rank,
                    value.cls,
                    value.level,
                    value.costume,
                    value.exp,
                    value.pos,
                    value.health,
                    value.damagedHealth,
                    value.dropItemCnt,
                ];
                if (value.skills.Count > 0)
                {
                    JArray jArray2 = [];
                    for (int i = 0; i < value.skills.Count; i++)
                    {
                        jArray2.Add((JToken)value.skills[i]);
                    }
                    jArray.Add(jArray2);
                }
                else
                {
                    jArray.Add(string.Empty);
                }
                jArray.Add(value.charType);
                jArray.Add(value.favorRewardStep);
                jArray.Add(value.mainIdx);
                jArray.Add(value.partIdx);
                if (value.equipItem.Count > 0)
                {
                    JArray jArray3 = [];
                    Dictionary<int, Item>.Enumerator enumerator = value.equipItem.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        jArray3.Add(enumerator.Current.Key);
                        jArray3.Add((JToken)enumerator.Current.Value);
                    }
                    jArray.Add(jArray3);
                }
                else
                {
                    jArray.Add(string.Empty);
                }
                jArray.Add(value.marry);
                if (value.weaponItem.Count > 0)
                {
                    JArray jArray4 = [];
                    Dictionary<int, Item>.Enumerator enumerator2 = value.weaponItem.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        jArray4.Add(enumerator2.Current.Key);
                        jArray4.Add((JToken)enumerator2.Current.Value);
                    }
                    jArray.Add(jArray4);
                }
                else
                {
                    jArray.Add(string.Empty);
                }
                if (value.transcendence.Count > 0)
                {
                    JArray jArray5 = [];
                    for (int j = 0; j < value.transcendence.Count; j++)
                    {
                        jArray5.Add(value.transcendence[j]);
                    }
                    jArray.Add(jArray5);
                }
                else
                {
                    jArray.Add(string.Empty);
                }
                return jArray;
            }

            public static explicit operator Slot(JToken value)
            {
                if (value.Type != JTokenType.Array)
                {
                    return null;
                }
                Slot slot = new()
                {
                    id = (string)value[0],
                    cid = (string)value[1],
                    rank = (int)value[2],
                    cls = (int)value[3],
                    level = (int)value[4],
                    costume = (int)value[5],
                    exp = (int)value[6],
                    pos = (int)value[7],
                    health = (int)value[8],
                    damagedHealth = (int)value[9],
                    dropItemCnt = (int)value[10]
                };
                if (value[11].Type == JTokenType.Array)
                {
                    JArray jArray = (JArray)value[11];
                    for (int i = 0; i < jArray.Count; i++)
                    {
                        slot.skills.Add((Skill)jArray[i]);
                    }
                }
                slot.charType = (int)value[12];
                slot.favorRewardStep = (int)value[13];
                slot.mainIdx = (int)value[14];
                slot.partIdx = (int)value[15];
                if (value[16].Type == JTokenType.Array)
                {
                    JArray jArray2 = (JArray)value[16];
                    for (int j = 0; j < jArray2.Count; j++)
                    {
                        int key = (int)jArray2[j++];
                        slot.equipItem.Add(key, (Item)jArray2[j]);
                    }
                }
                slot.marry = (int)value[17];
                if (value[18].Type == JTokenType.Array)
                {
                    JArray jArray3 = (JArray)value[18];
                    for (int k = 0; k < jArray3.Count; k++)
                    {
                        int key2 = (int)jArray3[k++];
                        slot.weaponItem.Add(key2, (Item)jArray3[k]);
                    }
                }
                if (value[19].Type == JTokenType.Array)
                {
                    JArray jArray4 = (JArray)value[19];
                    for (int l = 0; l < jArray4.Count; l++)
                    {
                        slot.transcendence.Add((int)jArray4[l]);
                    }
                }
                return slot;
            }

            public static bool IsSame(Slot f1, Slot f2)
            {
                if (f1.id != f2.id)
                {
                    return false;
                }
                if (f1.health != f2.health)
                {
                    return false;
                }
                if (f1.level != f2.level)
                {
                    return false;
                }
                if (f1.rank != f2.rank)
                {
                    return false;
                }
                return true;
            }
        }

        public const int RowCount = 3;

        public const int ColCount = 3;

        public const int SlotCount = 9;

        public const int CenterIndex = 4;

        public const int DefaultCommanderIndex = 7;

        public const int OpartsSlotCount = 4;

        public const int WeaponSlotCount = 5;

        [JsonIgnore]
        internal string _id;

        [JsonIgnore]
        internal int _speed;

        [JsonIgnore]
        internal int _activeSlotCount;

        [JsonIgnore]
        internal long _statsAttack;

        [JsonIgnore]
        internal long _statsHealing;

        [JsonIgnore]
        internal long _statsDefense;

        [JsonProperty("slots")]
        internal List<Slot> _slots;

        public string id => _id;

        public IList<Slot> slots => _slots.AsReadOnly();

        public bool isAnnihilated
        {
            get
            {
                foreach (Slot slot in slots)
                {
                    if (slot.health > 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public static Troop Copy(Troop src)
        {
            Troop troop = new()
            {
                _id = src._id,
                _speed = src._speed,
                _statsAttack = src._statsAttack,
                _statsHealing = src._statsHealing,
                _statsDefense = src._statsDefense,
                _slots = []
            };
            for (int i = 0; i < src._slots.Count; i++)
            {
                Slot slot = src._slots[i];
                if (slot == null)
                {
                    troop._slots.Add(null);
                }
                else
                {
                    troop._slots.Add(Slot.Copy(slot));
                }
            }
            return troop;
        }

        public static explicit operator JToken(Troop value)
        {
            JArray jArray = [];
            JArray jArray2 = [];
            for (int i = 0; i < value._slots.Count; i++)
            {
                jArray2.Add((JToken)value._slots[i]);
            }
            jArray.Add(jArray2);
            return jArray;
        }

        public static explicit operator Troop(JToken value)
        {
            Troop troop = new()
            {
                _slots = []
            };
            JArray jArray = (JArray)value[0];
            for (int i = 0; i < jArray.Count; i++)
            {
                troop._slots.Add((Slot)jArray[i]);
            }
            return troop;
        }

        public static bool IsSame(Troop f1, Troop f2)
        {
            if (f1 == f2)
            {
                return true;
            }
            if (f1 == null || f2 == null)
            {
                return false;
            }
            if (f1.id != f2.id)
            {
                return false;
            }
            if (f1.slots.Count != f2.slots.Count)
            {
                return false;
            }
            for (int i = 0; i < f1.slots.Count; i++)
            {
                if (!Slot.IsSame(f1.slots[i], f2.slots[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}