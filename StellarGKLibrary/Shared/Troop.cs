using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StellarGKLibrary.Shared.Battle;

namespace StellarGKLibrary.Shared
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Troop
    {
        public string id
        {
            get
            {
                return this._id;
            }
        }

        public IList<Troop.Slot> slots
        {
            get
            {
                return this._slots.AsReadOnly();
            }
        }

        public bool isAnnihilated
        {
            get
            {
                foreach (Troop.Slot slot in this.slots)
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
            Troop troop = new Troop();
            troop._id = src._id;
            troop._speed = src._speed;
            troop._statsAttack = src._statsAttack;
            troop._statsHealing = src._statsHealing;
            troop._statsDefense = src._statsDefense;
            troop._slots = new List<Troop.Slot>();
            for (int i = 0; i < src._slots.Count; i++)
            {
                Troop.Slot slot = src._slots[i];
                if (slot == null)
                {
                    troop._slots.Add(null);
                }
                else
                {
                    troop._slots.Add(Troop.Slot.Copy(slot));
                }
            }
            return troop;
        }

        public static explicit operator JToken(Troop value)
        {
            JArray jarray = new JArray();
            JArray jarray2 = new JArray();
            for (int i = 0; i < value._slots.Count; i++)
            {
                jarray2.Add((JToken)value._slots[i]);
            }
            jarray.Add(jarray2);
            return jarray;
        }

        public static explicit operator Troop(JToken value)
        {
            Troop troop = new Troop();
            troop._slots = new List<Troop.Slot>();
            JArray jarray = (JArray)value[0];
            for (int i = 0; i < jarray.Count; i++)
            {
                troop._slots.Add((Troop.Slot)jarray[i]);
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
                if (!Troop.Slot.IsSame(f1.slots[i], f2.slots[i]))
                {
                    return false;
                }
            }
            return true;
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
        internal List<Troop.Slot> _slots;

        [JsonObject]
        public class Slot
        {
            public Slot()
            {
                this.id = string.Empty;
                this.cid = string.Empty;
                this.charType = 0;
                this.rank = 1;
                this.cls = 1;
                this.level = 1;
                this.costume = 0;
                this.favorRewardStep = 0;
                this.marry = 0;
                this.exp = 0;
                this.pos = 0;
                this.health = 0;
                this.damagedHealth = 0;
                this.dropItemCnt = 0;
                this.scale = 1f;
                this.mainIdx = 0;
                this.partIdx = 0;
                this.statsAttack = 0L;
                this.statsHealing = 0L;
                this.statsDefense = 0L;
                this.skills = new List<Troop.Slot.Skill>();
                this.equipItem = new Dictionary<int, Troop.Slot.Item>();
                this.weaponItem = new Dictionary<int, Troop.Slot.Item>();
                this.transcendence = new List<int>();
            }

            [JsonIgnore]
            public bool isEmpty
            {
                get
                {
                    return string.IsNullOrEmpty(this.id);
                }
            }

            public static Troop.Slot Copy(Troop.Slot src)
            {
                Troop.Slot slot = new Troop.Slot();
                slot.id = src.id;
                slot.health = src.health;
                slot.level = src.level;
                slot.rank = src.rank;
                slot.cid = src.cid;
                slot.cls = src.cls;
                slot.costume = src.costume;
                slot.favorRewardStep = src.favorRewardStep;
                slot.marry = src.marry;
                slot.dropItemCnt = src.dropItemCnt;
                slot.scale = src.scale;
                slot.charType = src.charType;
                slot.favorRewardStep = src.favorRewardStep;
                slot.mainIdx = src.mainIdx;
                slot.partIdx = src.partIdx;
                slot.statsAttack = src.statsAttack;
                slot.statsHealing = src.statsHealing;
                slot.statsDefense = src.statsDefense;
                if (src.skills != null)
                {
                    for (int i = 0; i < src.skills.Count; i++)
                    {
                        slot.skills.Add(Troop.Slot.Skill.Copy(src.skills[i]));
                    }
                }
                if (src.equipItem != null)
                {
                    Dictionary<int, Troop.Slot.Item>.Enumerator enumerator = src.equipItem.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        Dictionary<int, Troop.Slot.Item> dictionary = slot.equipItem;
                        KeyValuePair<int, Troop.Slot.Item> keyValuePair = enumerator.Current;
                        int key = keyValuePair.Key;
                        KeyValuePair<int, Troop.Slot.Item> keyValuePair2 = enumerator.Current;
                        dictionary.Add(key, Troop.Slot.Item.Copy(keyValuePair2.Value));
                    }
                }
                if (src.weaponItem != null)
                {
                    Dictionary<int, Troop.Slot.Item>.Enumerator enumerator2 = src.weaponItem.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        Dictionary<int, Troop.Slot.Item> dictionary2 = slot.weaponItem;
                        KeyValuePair<int, Troop.Slot.Item> keyValuePair3 = enumerator2.Current;
                        int key2 = keyValuePair3.Key;
                        KeyValuePair<int, Troop.Slot.Item> keyValuePair4 = enumerator2.Current;
                        dictionary2.Add(key2, Troop.Slot.Item.Copy(keyValuePair4.Value));
                    }
                }
                if (src.transcendence != null)
                {
                    slot.transcendence.AddRange(src.transcendence);
                }
                return slot;
            }

            public static explicit operator JToken(Troop.Slot value)
            {
                if (value == null)
                {
                    return string.Empty;
                }
                JArray jarray = new JArray();
                jarray.Add(value.id);
                jarray.Add(value.cid);
                jarray.Add(value.rank);
                jarray.Add(value.cls);
                jarray.Add(value.level);
                jarray.Add(value.costume);
                jarray.Add(value.exp);
                jarray.Add(value.pos);
                jarray.Add(value.health);
                jarray.Add(value.damagedHealth);
                jarray.Add(value.dropItemCnt);
                if (value.skills.Count > 0)
                {
                    JArray jarray2 = new JArray();
                    for (int i = 0; i < value.skills.Count; i++)
                    {
                        jarray2.Add((JToken)value.skills[i]);
                    }
                    jarray.Add(jarray2);
                }
                else
                {
                    jarray.Add(string.Empty);
                }
                jarray.Add(value.charType);
                jarray.Add(value.favorRewardStep);
                jarray.Add(value.mainIdx);
                jarray.Add(value.partIdx);
                if (value.equipItem.Count > 0)
                {
                    JArray jarray3 = new JArray();
                    Dictionary<int, Troop.Slot.Item>.Enumerator enumerator = value.equipItem.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        JArray jarray4 = jarray3;
                        KeyValuePair<int, Troop.Slot.Item> keyValuePair = enumerator.Current;
                        jarray4.Add(keyValuePair.Key);
                        JArray jarray5 = jarray3;
                        KeyValuePair<int, Troop.Slot.Item> keyValuePair2 = enumerator.Current;
                        jarray5.Add((JToken)keyValuePair2.Value);
                    }
                    jarray.Add(jarray3);
                }
                else
                {
                    jarray.Add(string.Empty);
                }
                jarray.Add(value.marry);
                if (value.weaponItem.Count > 0)
                {
                    JArray jarray6 = new JArray();
                    Dictionary<int, Troop.Slot.Item>.Enumerator enumerator2 = value.weaponItem.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        JArray jarray7 = jarray6;
                        KeyValuePair<int, Troop.Slot.Item> keyValuePair3 = enumerator2.Current;
                        jarray7.Add(keyValuePair3.Key);
                        JArray jarray8 = jarray6;
                        KeyValuePair<int, Troop.Slot.Item> keyValuePair4 = enumerator2.Current;
                        jarray8.Add((JToken)keyValuePair4.Value);
                    }
                    jarray.Add(jarray6);
                }
                else
                {
                    jarray.Add(string.Empty);
                }
                if (value.transcendence.Count > 0)
                {
                    JArray jarray9 = new JArray();
                    for (int j = 0; j < value.transcendence.Count; j++)
                    {
                        jarray9.Add(value.transcendence[j]);
                    }
                    jarray.Add(jarray9);
                }
                else
                {
                    jarray.Add(string.Empty);
                }
                return jarray;
            }

            public static explicit operator Troop.Slot(JToken value)
            {
                if (value.Type != JTokenType.Array)
                {
                    return null;
                }
                Troop.Slot slot = new Troop.Slot();
                slot.id = (string)value[0];
                slot.cid = (string)value[1];
                slot.rank = (int)value[2];
                slot.cls = (int)value[3];
                slot.level = (int)value[4];
                slot.costume = (int)value[5];
                slot.exp = (int)value[6];
                slot.pos = (int)value[7];
                slot.health = (int)value[8];
                slot.damagedHealth = (int)value[9];
                slot.dropItemCnt = (int)value[10];
                if (value[11].Type == JTokenType.Array)
                {
                    JArray jarray = (JArray)value[11];
                    for (int i = 0; i < jarray.Count; i++)
                    {
                        slot.skills.Add((Troop.Slot.Skill)jarray[i]);
                    }
                }
                slot.charType = (int)value[12];
                slot.favorRewardStep = (int)value[13];
                slot.mainIdx = (int)value[14];
                slot.partIdx = (int)value[15];
                if (value[16].Type == JTokenType.Array)
                {
                    JArray jarray2 = (JArray)value[16];
                    for (int j = 0; j < jarray2.Count; j++)
                    {
                        int num = (int)jarray2[j++];
                        slot.equipItem.Add(num, (Troop.Slot.Item)jarray2[j]);
                    }
                }
                slot.marry = (int)value[17];
                if (value[18].Type == JTokenType.Array)
                {
                    JArray jarray3 = (JArray)value[18];
                    for (int k = 0; k < jarray3.Count; k++)
                    {
                        int num2 = (int)jarray3[k++];
                        slot.weaponItem.Add(num2, (Troop.Slot.Item)jarray3[k]);
                    }
                }
                if (value[19].Type == JTokenType.Array)
                {
                    JArray jarray4 = (JArray)value[19];
                    for (int l = 0; l < jarray4.Count; l++)
                    {
                        slot.transcendence.Add((int)jarray4[l]);
                    }
                }
                return slot;
            }

            public static bool IsSame(Troop.Slot f1, Troop.Slot f2)
            {
                return !(f1.id != f2.id) && f1.health == f2.health && f1.level == f2.level && f1.rank == f2.rank;
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
            public List<Troop.Slot.Skill> skills;

            [JsonProperty("itms")]
            public Dictionary<int, Troop.Slot.Item> equipItem;

            [JsonProperty("wepns")]
            public Dictionary<int, Troop.Slot.Item> weaponItem;

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

            [JsonObject]
            public class Skill
            {
                public static Troop.Slot.Skill Copy(Troop.Slot.Skill src)
                {
                    return new Troop.Slot.Skill
                    {
                        id = src.id,
                        lv = src.lv,
                        sp = src.sp
                    };
                }

                public static explicit operator JToken(Troop.Slot.Skill value)
                {
                    return new JArray { value.id, value.lv, value.sp };
                }

                public static explicit operator Troop.Slot.Skill(JToken value)
                {
                    return new Troop.Slot.Skill
                    {
                        id = (string)value[0],
                        lv = (int)value[1],
                        sp = (int)value[2]
                    };
                }

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
            }

            [JsonObject]
            public class Item
            {
                public static Troop.Slot.Item Create(RoItem roItem)
                {
                    return new Troop.Slot.Item
                    {
                        id = roItem.id,
                        lv = roItem.level
                    };
                }

                public static Troop.Slot.Item Copy(Troop.Slot.Item src)
                {
                    return new Troop.Slot.Item
                    {
                        id = src.id,
                        lv = src.lv
                    };
                }

                public static explicit operator JToken(Troop.Slot.Item value)
                {
                    return new JArray { value.id, value.lv };
                }

                public static explicit operator Troop.Slot.Item(JToken value)
                {
                    return new Troop.Slot.Item
                    {
                        id = (string)value[0],
                        lv = (int)value[1]
                    };
                }

                [JsonProperty("id")]
                public string id;

                [JsonProperty("lv")]
                public int lv;
            }
        }
    }
}
