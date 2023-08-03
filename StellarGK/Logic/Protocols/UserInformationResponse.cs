using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class UserInformationResponse
    {
        [JsonPropertyName("rsoc")]
        public Resource goodsInfo { get; set; }

        [JsonPropertyName("uifo")]
        public BattleStatistics battleStatisticsInfo { get; set; }

        [JsonPropertyName("comm")]
        public object __commanderInfo { get; set; }

        [JsonPropertyName("uno")]
        public string uno { get; set; }

        [JsonPropertyName("stage")]
        public int stage { get; set; }

        [JsonPropertyName("part")]
        public Dictionary<string, int> partData { get; set; }

        [JsonPropertyName("medl")]
        public Dictionary<string, int> medalData { get; set; }

        [JsonPropertyName("ersoc")]
        public Dictionary<string, int> eventResourceData { get; set; }

        [JsonPropertyName("food")]
        public Dictionary<string, int> foodData { get; set; }

        [JsonPropertyName("item")]
        public Dictionary<string, int> itemData { get; set; }

        [JsonPropertyName("gld")]
        public UserGuild guildInfo { get; set; }

        [JsonPropertyName("cc")]
        public Dictionary<string, List<int>> sweepClearData { get; set; }

        [JsonPropertyName("deck")]
        public List<PreDeck> preDeck { get; set; }

        [JsonPropertyName("nhcc")]
        public Dictionary<string, List<int>> donHaveCommCostumeData { get; set; }

        [JsonPropertyName("grp")]
        public List<int> completeRewardGroupIdx { get; set; }

        [JsonPropertyName("rstm")]
        public int resetRemain { get; set; }

        [JsonPropertyName("onoff")]
        public bool notification { get; set; }

        [JsonPropertyName("equip")]
        public Dictionary<string, Dictionary<int, EquipItemInfo>> equipItem { get; set; }

        [JsonPropertyName("guit")]
        public Dictionary<string, int> groupItemData { get; set; }

        [JsonPropertyName("weapon")]
        public Dictionary<string, WeaponData> weaponList { get; set; }


        public class Resource
        {
            [JsonPropertyName("unm")]
            public string __nickname { get; set; }

            [JsonPropertyName("thmb")]
            public string __thumbnailId { get; set; }

            [JsonPropertyName("exp")]
            public string __exp { get; set; }

            [JsonPropertyName("lv")]
            public string __level { get; set; }

            [JsonPropertyName("vlv")]
            public string __vipLevel { get; set; }

            [JsonPropertyName("vexp")]
            public string __vipExp { get; set; }

            [JsonPropertyName("gold")]
            public string __gold { get; set; }

            [JsonPropertyName("cash")]
            public string __cash { get; set; }

            [JsonPropertyName("honr")]
            public string __honor { get; set; }

            [JsonPropertyName("sply")]
            public string __explorationTicket { get; set; }

            [JsonPropertyName("swp")]
            public string __sweepTicket { get; set; }

            [JsonPropertyName("keys")]
            public string __opener { get; set; }

            [JsonPropertyName("chlg")]
            public string __challenge { get; set; }

            [JsonPropertyName("blcg")]
            public string __blackChallenge { get; set; }

            [JsonPropertyName("opcn")]
            public string __opcon { get; set; }

            [JsonPropertyName("acon")]
            public string __challengeCoin { get; set; }

            [JsonPropertyName("wbt")]
            public string __waveDuelTicket { get; set; }

            [JsonPropertyName("wbc")]
            public string __waveDuelCoin { get; set; }

            [JsonPropertyName("gcon")]
            public string __guildCoin { get; set; }

            [JsonPropertyName("rcon")]
            public string __raidCoin { get; set; }

            [JsonPropertyName("ncon")]
            public string __annCoin { get; set; }

            [JsonPropertyName("bult")]
            public string __bullet { get; set; }

            [JsonPropertyName("chip")]
            public string __chip { get; set; }

            [JsonPropertyName("abp")]
            public string __blueprintArmy { get; set; }

            [JsonPropertyName("nbp")]
            public string __blueprintNavy { get; set; }

            [JsonPropertyName("cmtr")]
            public string __commanderPromotionPoint { get; set; }

            [JsonPropertyName("ebac")]
            public string __eventRaidTicket { get; set; }

            [JsonPropertyName("oil")]
            public string __oil { get; set; }

            [JsonPropertyName("wmat1")]
            public string __weaponMaterial1 { get; set; }

            [JsonPropertyName("wmat2")]
            public string __weaponMaterial2 { get; set; }

            [JsonPropertyName("wmat3")]
            public string __weaponMaterial3 { get; set; }

            [JsonPropertyName("wmat4")]
            public string __weaponMaterial4 { get; set; }

            [JsonPropertyName("wimt")]
            public string __weaponImmediateTicket { get; set; }

            [JsonPropertyName("wmt")]
            public string __weaponMakeTicket { get; set; }

            [JsonPropertyName("ring")]
            public string __ring { get; set; }

            [JsonPropertyName("cgft")]
            public string __commanderGift { get; set; }

            [JsonPropertyName("sbtk")]
            public string __worldDuelTicket { get; set; }

            [JsonPropertyName("sbc1")]
            public string __worldDuelCoin { get; set; }

            [JsonPropertyName("sbc2")]
            public string __worldDuelUpgradeCoin { get; set; }
        }


        public class BattleResult
        {
            [JsonPropertyName("save")]
            public bool save { get; set; }

            [JsonPropertyName("rsoc")]
            public Resource __resource { get; set; }

            [JsonPropertyName("reward")]
            public List<RewardInfo.RewardData> rewardList { get; set; }

            [JsonPropertyName("comm")]
            public Dictionary<string, Commander> commanderData { get; set; }

            [JsonPropertyName("part")]
            public Dictionary<string, int> partData { get; set; }

            [JsonPropertyName("medl")]
            public Dictionary<string, int> medalData { get; set; }

            [JsonPropertyName("ersoc")]
            public Dictionary<string, int> eventResourceData { get; set; }

            [JsonPropertyName("item")]
            public Dictionary<string, int> itemData { get; set; }

            [JsonPropertyName("food")]
            public Dictionary<string, int> foodData { get; set; }

            [JsonPropertyName("favr")]
            public List<FavorUpData.CommanderFavor> commanderFavor { get; set; }

            [JsonPropertyName("vshp")]
            public int VipShopOpen { get; set; }

            [JsonPropertyName("vrtm")]
            public int VipShopResetTime { get; set; }

            [JsonPropertyName("guit")]
            public Dictionary<string, int> groupItemData { get; set; }

            [JsonPropertyName("tinfo")]
            public InfinityTowerData infinityData { get; set; }

            [JsonPropertyName("user")]
            public UserData user;


            public class UserData
            {
                [JsonPropertyName("prnk")]
                public int prevRank { get; set; }

                [JsonPropertyName("rank")]
                public int rank { get; set; }

                [JsonPropertyName("prct")]
                public float rankPercent { get; set; }

                [JsonPropertyName("score")]
                public int curScore { get; set; }

                [JsonPropertyName("pscr")]
                public int prevScore { get; set; }

                [JsonPropertyName("ascr")]
                public int getScore { get; set; }

                [JsonPropertyName("wscr")]
                public int winScore { get; set; }

                [JsonPropertyName("wst")]
                public int winCount { get; set; }

                [JsonPropertyName("pwst")]
                public int prevWinCount { get; set; }

                [JsonPropertyName("dpnt")]
                public int duelPoint { get; set; }
            }
        }


        public class BattleStatistics
        {
            [JsonPropertyName("egld")]
            public long totalGold { get; set; }

            [JsonPropertyName("pvew")]
            public int pveWinCount { get; set; }

            [JsonPropertyName("pvel")]
            public int pveLoseCount { get; set; }

            [JsonPropertyName("pvpw")]
            public int pvpWinCount { get; set; }

            [JsonPropertyName("pvpl")]
            public int pvpLoseCount { get; set; }

            [JsonPropertyName("acdc")]
            public int armyCommanderDestroyCount { get; set; }

            [JsonPropertyName("audc")]
            public int armyUnitDestroyCount { get; set; }

            [JsonPropertyName("ncdc")]
            public int navyCommanderDestroyCount { get; set; }

            [JsonPropertyName("nudc")]
            public int navyUnitDestroyCount { get; set; }

            [JsonPropertyName("pdgd")]
            public int totalPlunderGold { get; set; }

            [JsonPropertyName("wst")]
            public int winStreak { get; set; }

            [JsonPropertyName("wmst")]
            public int winMostStreak { get; set; }

            [JsonPropertyName("pwst")]
            public int preWinStreak { get; set; }

            [JsonPropertyName("atr")]
            public int arenaHighRank { get; set; }

            [JsonPropertyName("rtr")]
            public int raidHighRank { get; set; }

            [JsonPropertyName("rts")]
            public int raidHighScore { get; set; }

            [JsonPropertyName("ggc")]
            public int normalGachaCount { get; set; }

            [JsonPropertyName("cgc")]
            public int premiumGachaCount { get; set; }

            [JsonPropertyName("stcc")]
            public int stageClearCount { get; set; }

            [JsonPropertyName("swcc")]
            public int sweepClearCount { get; set; }

            [JsonPropertyName("edc")]
            public int unitDestroyCount { get; set; }

            [JsonPropertyName("pdc")]
            public int commanderDestroyCount { get; set; }

            [JsonPropertyName("vshp")]
            public int vipShop { get; set; }

            [JsonPropertyName("vrtm")]
            public int vipShopResetTime { get; set; }

            [JsonPropertyName("prdc")]
            public int predeckCount { get; set; }

            [JsonPropertyName("fpur")]
            public int firstPayment { get; set; }

            [JsonPropertyName("wmsc")]
            public int weaponMakeSlotCount { get; set; }

            [JsonPropertyName("wic")]
            public int weaponInventoryCount { get; set; }
        }


        public class Unit
        {
            [JsonPropertyName("sp")]
            public List<int> spList { get; set; }

            [JsonPropertyName("uid")]
            public string id;

            [JsonPropertyName("lv")]
            public int level;

            [JsonPropertyName("hp")]
            public int Hp;
        }


        public class Building
        {
            [JsonPropertyName("bid")]
            public int id { get; set; }

            [JsonPropertyName("stus")]
            public int state { get; set; }

            [JsonPropertyName("lv")]
            public int level { get; set; }

            [JsonPropertyName("remain")]
            public int remainTime { get; set; }
        }


        public class Commander
        {
            [JsonPropertyName("cid")]
            public string id { get; set; }

            [JsonPropertyName("lv")]
            public string __level { get; set; }

            [JsonPropertyName("grd")]
            public string __rank { get; set; }

            [JsonPropertyName("cls")]
            public string __cls { get; set; }

            [JsonPropertyName("exp")]
            public string __exp { get; set; }

            [JsonPropertyName("medl")]
            public int medl { get; set; }

            [JsonPropertyName("skv1")]
            public string __skv1 { get; set; }

            [JsonPropertyName("skv2")]
            public string __skv2 { get; set; }

            [JsonPropertyName("skv3")]
            public string __skv3 { get; set; }

            [JsonPropertyName("skv4")]
            public string __skv4 { get; set; }

            [JsonPropertyName("role")]
            public string role { get; set; }

            [JsonPropertyName("stus")]
            public string state { get; set; }

            [JsonPropertyName("cos")]
            public int currentCostume { get; set; }

            [JsonPropertyName("clst")]
            public List<int> haveCostume { get; set; }

            [JsonPropertyName("evt")]
            public Dictionary<int, int> eventCostume { get; set; }

            [JsonPropertyName("fs")]
            public int favorStep { get; set; }

            [JsonPropertyName("fp")]
            public int favorPoint { get; set; }

            [JsonPropertyName("rsf")]
            public int favorRewardStep { get; set; }

            [JsonPropertyName("favr")]
            public int favr { get; set; }

            [JsonPropertyName("fvrd")]
            public int fvrd { get; set; }

            [JsonPropertyName("eq")]
            public Dictionary<string, int> equipItemInfo { get; set; }

            [JsonPropertyName("mry")]
            public int marry { get; set; }

            [JsonPropertyName("tsdc")]
            public List<int> transcendence { get; set; }

            [JsonPropertyName("wp")]
            public Dictionary<string, WeaponData> equipWeaponInfo { get; set; }

        }


        public class DailyCheckPoint
        {
            [JsonPropertyName("swbc")]
            public int sweepTicketBuyCount { get; set; }

            [JsonPropertyName("spbc")]
            public int explorationTicketBuyCount { get; set; }
        }


        public class PartData
        {
            [JsonPropertyName("pidx")]
            public string idx { get; set; }

            [JsonPropertyName("cnt")]
            public int count { get; set; }
        }


        public class UserGuild
        {
            [JsonPropertyName("gidx")]
            public int idx { get; set; }

            [JsonPropertyName("gnm")]
            public string name { get; set; }

            [JsonPropertyName("lev")]
            public int level { get; set; }

            [JsonPropertyName("pnt")]
            public int point { get; set; }

            [JsonPropertyName("apnt")]
            public int aPoint { get; set; }

            [JsonPropertyName("mstr")]
            public int memberGrade { get; set; }

            [JsonPropertyName("emb")]
            public int emblem { get; set; }

            [JsonPropertyName("gtyp")]
            public int guildType { get; set; }

            [JsonPropertyName("lvlm")]
            public int limitLevel { get; set; }

            [JsonPropertyName("ntc")]
            public string notice { get; set; }

            [JsonPropertyName("stat")]
            public int state { get; set; }

            [JsonPropertyName("ctime")]
            public double closeTime { get; set; }

            [JsonPropertyName("reg")]
            public double createTime { get; set; }

            [JsonPropertyName("mxCnt")]
            public int maxCount { get; set; }

            [JsonPropertyName("cnt")]
            public int count { get; set; }

            [JsonPropertyName("skill")]
            public List<GuildSkill> skillDada { get; set; }

            [JsonPropertyName("occupy")]
            public int occupy { get; set; }

            [JsonPropertyName("world")]
            public int world { get; set; }


            public class GuildSkill
            {
                [JsonPropertyName("gsid")]
                public int idx { get; set; }

                [JsonPropertyName("gslv")]
                public int level { get; set; }
            }
        }


        public class VipRechargeData
        {
            [JsonPropertyName("vidx")]
            public int idx = 101;

            [JsonPropertyName("mid")]
            public int mid = 1;

            [JsonPropertyName("cnt")]
            public int count = 1;
        }


        public class TutorialData
        {
            [JsonPropertyName("step")]
            public int step { get; set; }

            [JsonPropertyName("skip")]
            public bool skip { get; set; }
        }


        public class PreDeck
        {
            [JsonPropertyName("dpid")]
            public int idx { get; set; }

            [JsonPropertyName("dpnm")]
            public string name { get; set; }

            [JsonPropertyName("deck")]
            public Dictionary<string, int> deckData { get; set; }
        }
    }
}
