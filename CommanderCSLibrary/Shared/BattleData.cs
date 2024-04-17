using CommanderCSLibrary.Shared.Battle;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using CommanderCSLibrary.Shared.Ro;

namespace CommanderCSLibrary.Shared
{
    public class BattleData
    {
        private static BattleData _instance;

        public List<RewardInfo.RewardData> rewardItems;

        public UserInformationResponse.BattleResult dualResult;

        public bool isWin { get; set; }

        public RoUser attacker { get; set; }

        public RoTroop attackerTroop => attacker.mainTroop;

        public RoUser defender { get; set; }

        public RoTroop defenderTroop => defender.mainTroop;

        public EBattleResultMove move { get; set; }

        public EBattleType type { get; set; }

        public RoRaid raidData { get; set; }

        public string worldId { get; set; }

        public string stageId { get; set; }

        public int stageLevel { get; set; }

        public bool worldDuelReMatch { get; set; }

        public int eventId { get; set; }

        public int eventLevel { get; set; }

        public int eventClear { get; set; }

        public string eventRaidBossId { get; set; }

        public string eventRaidIdx { get; set; }

        public int eventRaidAttendCount { get; set; }

        public int returnEventIdx { get; set; }

        public int sweepType { get; set; }

        public int sweepLevel { get; set; }

        public bool isReplayMode { get; set; }

        public Record record { get; set; }

        public bool IsCleared { get; set; }

        public int unitKillCount { get; set; }

        public int WaveCount { get; set; }

        public int conquestDeckId { get; set; }

        public int clearRank { get; set; }

        public BattleData()
        {
            IsCleared = false;
        }

        //public void RefreshAttackerTroop(bool removeMercenary = false)
        //{
        //	if (attacker == null)
        //	{
        //		return;
        //	}
        //	RoLocalUser localUser = RemoteObjectManager.instance.localUser;
        //	for (int i = 0; i < attacker.battleTroopList.Count; i++)
        //	{
        //		if (attacker.battleTroopList[i] == null)
        //		{
        //			continue;
        //		}
        //		for (int j = 0; j < attacker.battleTroopList[i].slots.Length; j++)
        //		{
        //			RoTroop.Slot slot = attacker.battleTroopList[i].slots[j];
        //			if (slot != null && slot.IsValid())
        //			{
        //				if (removeMercenary && (slot.charType == ECharacterType.Mercenary || slot.charType == ECharacterType.SuperMercenary || slot.charType == ECharacterType.NPCMercenary || slot.charType == ECharacterType.SuperNPCMercenary))
        //				{
        //					attacker.battleTroopList[i].slots[j].ResetSlot();
        //				}
        //				else if (slot.charType != ECharacterType.Helper)
        //				{
        //					RoCommander roCommander = localUser.FindCommander(slot.commanderId);
        //					attacker.battleTroopList[i].slots[j] = roCommander.ToSlot(slot.position);
        //				}
        //			}
        //		}
        //	}
        //	if (removeMercenary)
        //	{
        //		localUser.EngageCommander.Clear();
        //	}
        //}

        public static void Set(BattleData battleData)
        {
            if (_instance == null)
            {
                _instance = battleData;
            }
        }

        public static BattleData Get()
        {
            BattleData instance = _instance;
            _instance = null;
            return instance;
        }

        public static BattleData Create(EBattleType type)
        {
            BattleData battleData = new()
            {
                type = type
            };
            return battleData;
        }
    }
}