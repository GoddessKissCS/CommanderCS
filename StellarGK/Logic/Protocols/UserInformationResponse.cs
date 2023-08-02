using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class UserInformationResponse
    {
        [JsonProperty("rsoc")]
        public Resource goodsInfo { get; set; }

        [JsonProperty("uifo")]
        public BattleStatistics battleStatisticsInfo { get; set; }

        [JsonProperty("comm")]
        public object __commanderInfo { get; set; }

        [JsonProperty("uno")]
        public string uno { get; set; }

        [JsonProperty("stage")]
        public int stage { get; set; }

        [JsonProperty("part")]
        public Dictionary<string, int> partData { get; set; }

        [JsonProperty("medl")]
        public Dictionary<string, int> medalData { get; set; }

        [JsonProperty("ersoc")]
        public Dictionary<string, int> eventResourceData { get; set; }

        [JsonProperty("food")]
        public Dictionary<string, int> foodData { get; set; }

        [JsonProperty("item")]
        public Dictionary<string, int> itemData { get; set; }

        [JsonProperty("gld")]
        public UserGuild guildInfo { get; set; }

        [JsonProperty("cc")]
        public Dictionary<string, List<int>> sweepClearData { get; set; }

        [JsonProperty("deck")]
        public List<PreDeck> preDeck { get; set; }

        [JsonProperty("nhcc")]
        public Dictionary<string, List<int>> donHaveCommCostumeData { get; set; }

        [JsonProperty("grp")]
        public List<int> completeRewardGroupIdx { get; set; }

        [JsonProperty("rstm")]
        public int resetRemain { get; set; }

        [JsonProperty("onoff")]
        public bool notification { get; set; }

        [JsonProperty("equip")]
        public Dictionary<string, Dictionary<int, EquipItemInfo>> equipItem { get; set; }

        [JsonProperty("guit")]
        public Dictionary<string, int> groupItemData { get; set; }

        [JsonProperty("weapon")]
        public Dictionary<string, WeaponData> weaponList { get; set; }

        [JsonObject(MemberSerialization.OptIn)]
        public class Resource
        {
            [JsonProperty("unm")]
            public string __nickname { get; set; }

            [JsonProperty("thmb")]
            public string __thumbnailId { get; set; }

            [JsonProperty("exp")]
            public string __exp { get; set; }

            [JsonProperty("lv")]
            public string __level { get; set; }

            [JsonProperty("vlv")]
            public string __vipLevel { get; set; }

            [JsonProperty("vexp")]
            public string __vipExp { get; set; }

            [JsonProperty("gold")]
            public string __gold { get; set; }

            [JsonProperty("cash")]
            public string __cash { get; set; }

            [JsonProperty("honr")]
            public string __honor { get; set; }

            [JsonProperty("sply")]
            public string __explorationTicket { get; set; }

            [JsonProperty("swp")]
            public string __sweepTicket { get; set; }

            [JsonProperty("keys")]
            public string __opener { get; set; }

            [JsonProperty("chlg")]
            public string __challenge { get; set; }

            [JsonProperty("blcg")]
            public string __blackChallenge { get; set; }

            [JsonProperty("opcn")]
            public string __opcon { get; set; }

            [JsonProperty("acon")]
            public string __challengeCoin { get; set; }

            [JsonProperty("wbt")]
            public string __waveDuelTicket { get; set; }

            [JsonProperty("wbc")]
            public string __waveDuelCoin { get; set; }

            [JsonProperty("gcon")]
            public string __guildCoin { get; set; }

            [JsonProperty("rcon")]
            public string __raidCoin { get; set; }

            [JsonProperty("ncon")]
            public string __annCoin { get; set; }

            [JsonProperty("bult")]
            public string __bullet { get; set; }

            [JsonProperty("chip")]
            public string __chip { get; set; }

            [JsonProperty("abp")]
            public string __blueprintArmy { get; set; }

            [JsonProperty("nbp")]
            public string __blueprintNavy { get; set; }

            [JsonProperty("cmtr")]
            public string __commanderPromotionPoint { get; set; }

            [JsonProperty("ebac")]
            public string __eventRaidTicket { get; set; }

            [JsonProperty("oil")]
            public string __oil { get; set; }

            [JsonProperty("wmat1")]
            public string __weaponMaterial1 { get; set; }

            [JsonProperty("wmat2")]
            public string __weaponMaterial2 { get; set; }

            [JsonProperty("wmat3")]
            public string __weaponMaterial3 { get; set; }

            [JsonProperty("wmat4")]
            public string __weaponMaterial4 { get; set; }

            [JsonProperty("wimt")]
            public string __weaponImmediateTicket { get; set; }

            [JsonProperty("wmt")]
            public string __weaponMakeTicket { get; set; }

            [JsonProperty("ring")]
            public string __ring { get; set; }

            [JsonProperty("cgft")]
            public string __commanderGift { get; set; }

            [JsonProperty("sbtk")]
            public string __worldDuelTicket { get; set; }

            [JsonProperty("sbc1")]
            public string __worldDuelCoin { get; set; }

            [JsonProperty("sbc2")]
            public string __worldDuelUpgradeCoin { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class BattleResult
        {
            [JsonProperty("save")]
            public bool save { get; set; }

            [JsonProperty("rsoc")]
            public Resource __resource { get; set; }

            [JsonProperty("reward")]
            public List<RewardInfo.RewardData> rewardList { get; set; }

            [JsonProperty("comm")]
            public Dictionary<string, Commander> commanderData { get; set; }

            [JsonProperty("part")]
            public Dictionary<string, int> partData { get; set; }

            [JsonProperty("medl")]
            public Dictionary<string, int> medalData { get; set; }

            [JsonProperty("ersoc")]
            public Dictionary<string, int> eventResourceData { get; set; }

            [JsonProperty("item")]
            public Dictionary<string, int> itemData { get; set; }

            [JsonProperty("food")]
            public Dictionary<string, int> foodData { get; set; }

            [JsonProperty("favr")]
            public List<FavorUpData.CommanderFavor> commanderFavor { get; set; }

            [JsonProperty("vshp")]
            public int VipShopOpen { get; set; }

            [JsonProperty("vrtm")]
            public int VipShopResetTime { get; set; }

            [JsonProperty("guit")]
            public Dictionary<string, int> groupItemData { get; set; }

            [JsonProperty("tinfo")]
            public InfinityTowerData infinityData { get; set; }

            [JsonProperty("user")]
            public UserData user;

            [JsonObject(MemberSerialization.OptIn)]
            public class UserData
            {
                [JsonProperty("prnk")]
                public int prevRank { get; set; }

                [JsonProperty("rank")]
                public int rank { get; set; }

                [JsonProperty("prct")]
                public float rankPercent { get; set; }

                [JsonProperty("score")]
                public int curScore { get; set; }

                [JsonProperty("pscr")]
                public int prevScore { get; set; }

                [JsonProperty("ascr")]
                public int getScore { get; set; }

                [JsonProperty("wscr")]
                public int winScore { get; set; }

                [JsonProperty("wst")]
                public int winCount { get; set; }

                [JsonProperty("pwst")]
                public int prevWinCount { get; set; }

                [JsonProperty("dpnt")]
                public int duelPoint { get; set; }
            }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class BattleStatistics
        {
            [JsonProperty("egld")]
            public long totalGold { get; set; }

            [JsonProperty("pvew")]
            public int pveWinCount { get; set; }

            [JsonProperty("pvel")]
            public int pveLoseCount { get; set; }

            [JsonProperty("pvpw")]
            public int pvpWinCount { get; set; }

            [JsonProperty("pvpl")]
            public int pvpLoseCount { get; set; }

            [JsonProperty("acdc")]
            public int armyCommanderDestroyCount { get; set; }

            [JsonProperty("audc")]
            public int armyUnitDestroyCount { get; set; }

            [JsonProperty("ncdc")]
            public int navyCommanderDestroyCount { get; set; }

            [JsonProperty("nudc")]
            public int navyUnitDestroyCount { get; set; }

            [JsonProperty("pdgd")]
            public int totalPlunderGold { get; set; }

            [JsonProperty("wst")]
            public int winStreak { get; set; }

            [JsonProperty("wmst")]
            public int winMostStreak { get; set; }

            [JsonProperty("pwst")]
            public int preWinStreak { get; set; }

            [JsonProperty("atr")]
            public int arenaHighRank { get; set; }

            [JsonProperty("rtr")]
            public int raidHighRank { get; set; }

            [JsonProperty("rts")]
            public int raidHighScore { get; set; }

            [JsonProperty("ggc")]
            public int normalGachaCount { get; set; }

            [JsonProperty("cgc")]
            public int premiumGachaCount { get; set; }

            [JsonProperty("stcc")]
            public int stageClearCount { get; set; }

            [JsonProperty("swcc")]
            public int sweepClearCount { get; set; }

            [JsonProperty("edc")]
            public int unitDestroyCount { get; set; }

            [JsonProperty("pdc")]
            public int commanderDestroyCount { get; set; }

            [JsonProperty("vshp")]
            public int vipShop { get; set; }

            [JsonProperty("vrtm")]
            public int vipShopResetTime { get; set; }

            [JsonProperty("prdc")]
            public int predeckCount { get; set; }

            [JsonProperty("fpur")]
            public int firstPayment { get; set; }

            [JsonProperty("wmsc")]
            public int weaponMakeSlotCount { get; set; }

            [JsonProperty("wic")]
            public int weaponInventoryCount { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class Unit
        {
            [JsonProperty("sp")]
            public List<int> spList { get; set; }

            [JsonProperty("uid")]
            public string id;

            [JsonProperty("lv")]
            public int level;

            [JsonProperty("hp")]
            public int Hp;
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class Building
        {
            [JsonProperty("bid")]
            public int id { get; set; }

            [JsonProperty("stus")]
            public int state { get; set; }

            [JsonProperty("lv")]
            public int level { get; set; }

            [JsonProperty("remain")]
            public int remainTime { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class Commander
        {
            [JsonProperty("cid")]
            public string id { get; set; }

            [JsonProperty("lv")]
            public string __level { get; set; }

            [JsonProperty("grd")]
            public string __rank { get; set; }

            [JsonProperty("cls")]
            public string __cls { get; set; }

            [JsonProperty("exp")]
            public string __exp { get; set; }

            [JsonProperty("medl")]
            public int medl { get; set; }

            [JsonProperty("skv1")]
            public string __skv1 { get; set; }

            [JsonProperty("skv2")]
            public string __skv2 { get; set; }

            [JsonProperty("skv3")]
            public string __skv3 { get; set; }

            [JsonProperty("skv4")]
            public string __skv4 { get; set; }

            [JsonProperty("role")]
            public string role { get; set; }

            [JsonProperty("stus")]
            public string state { get; set; }

            [JsonProperty("cos")]
            public int currentCostume { get; set; }

            [JsonProperty("clst")]
            public List<int> haveCostume { get; set; }

            [JsonProperty("evt")]
            public Dictionary<int, int> eventCostume { get; set; }

            [JsonProperty("fs")]
            public int favorStep { get; set; }

            [JsonProperty("fp")]
            public int favorPoint { get; set; }

            [JsonProperty("rsf")]
            public int favorRewardStep { get; set; }

            [JsonProperty("favr")]
            public int favr { get; set; }

            [JsonProperty("fvrd")]
            public int fvrd { get; set; }

            [JsonProperty("eq")]
            public Dictionary<string, int> equipItemInfo { get; set; }

            [JsonProperty("mry")]
            public int marry { get; set; }

            [JsonProperty("tsdc")]
            public List<int> transcendence { get; set; }

            [JsonProperty("wp")]
            public Dictionary<string, WeaponData> equipWeaponInfo { get; set; }

        }

        [JsonObject(MemberSerialization.OptIn)]
        public class DailyCheckPoint
        {
            [JsonProperty("swbc")]
            public int sweepTicketBuyCount { get; set; }

            [JsonProperty("spbc")]
            public int explorationTicketBuyCount { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class PartData
        {
            [JsonProperty("pidx")]
            public string idx { get; set; }

            [JsonProperty("cnt")]
            public int count { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class UserGuild
        {
            [JsonProperty("gidx")]
            public int idx { get; set; }

            [JsonProperty("gnm")]
            public string name { get; set; }

            [JsonProperty("lev")]
            public int level { get; set; }

            [JsonProperty("pnt")]
            public int point { get; set; }

            [JsonProperty("apnt")]
            public int aPoint { get; set; }

            [JsonProperty("mstr")]
            public int memberGrade { get; set; }

            [JsonProperty("emb")]
            public int emblem { get; set; }

            [JsonProperty("gtyp")]
            public int guildType { get; set; }

            [JsonProperty("lvlm")]
            public int limitLevel { get; set; }

            [JsonProperty("ntc")]
            public string notice { get; set; }

            [JsonProperty("stat")]
            public int state { get; set; }

            [JsonProperty("ctime")]
            public double closeTime { get; set; }

            [JsonProperty("reg")]
            public double createTime { get; set; }

            [JsonProperty("mxCnt")]
            public int maxCount { get; set; }

            [JsonProperty("cnt")]
            public int count { get; set; }

            [JsonProperty("skill")]
            public List<GuildSkill> skillDada { get; set; }

            [JsonProperty("occupy")]
            public int occupy { get; set; }

            [JsonProperty("world")]
            public int world { get; set; }

            [JsonObject(MemberSerialization.OptIn)]
            public class GuildSkill
            {
                [JsonProperty("gsid")]
                public int idx { get; set; }

                [JsonProperty("gslv")]
                public int level { get; set; }
            }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class VipRechargeData
        {
            [JsonProperty("vidx")]
            public int idx = 101;

            [JsonProperty("mid")]
            public int mid = 1;

            [JsonProperty("cnt")]
            public int count = 1;
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class TutorialData
        {
            [JsonProperty("step")]
            public int step { get; set; }

            [JsonProperty("skip")]
            public bool skip { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class PreDeck
        {
            [JsonProperty("dpid")]
            public int idx { get; set; }

            [JsonProperty("dpnm")]
            public string name { get; set; }

            [JsonProperty("deck")]
            public Dictionary<string, int> deckData { get; set; }
        }
    }
}
