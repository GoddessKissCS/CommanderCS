//using StellarGKLibrary.Enums;
//using System.Collections.Generic;
//using System.Security.Cryptography;
//using System.Text;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using StellarGKLibrary.Shared.Battle.Internal;

//using System.Numerics;

//namespace StellarGKLibrary.Shared.Battle
//{
//	[JsonObject]
//	public class Simulator
//	{
//		private Simulator()
//		{
//		}

//		public Regulation regulation { get; set; }

//		public Record record { get; set; }

//		public int frameNum { get; set; }

//		public bool isReplayMode { get; set; }

//		public ClearMission mission { get; set; }

//		public bool isGiveUp
//		{
//			get
//			{
//				return _isGiveUp;
//			}
//			set
//			{
//				if (initState.battleType == EBattleType.Raid || initState.battleType == EBattleType.WaveBattle)
//				{
//					_isGiveUp = value;
//				}
//			}
//		}

//		public InitState initState
//		{
//			get
//			{
//				return record.initState;
//			}
//		}

//		public IList<Troop> lhsTroops
//		{
//			get
//			{
//				return initState.lhsTroops;
//			}
//		}

//		public IList<Troop> rhsTroops
//		{
//			get
//			{
//				return initState.rhsTroops;
//			}
//		}

//		public List<string> battleItemDrks
//		{
//			get
//			{
//				return initState.battleItemDrks;
//			}
//		}

//		public List<GuildSkillState> guildSkillState
//		{
//			get
//			{
//				return initState.guildSkills;
//			}
//		}

//		public Option option
//		{
//			get
//			{
//				return record.option;
//			}
//		}

//		public bool ableAuto { get; set; }

//		public bool isLhsAnnihilated { get; set; }

//		public bool isRhsAnnihilated { get; set; }

//		public bool isWaitingNextTurn { get; set; }

//		public int unitCount
//		{
//			get
//			{
//				return (lhsTroops.Count + rhsTroops.Count) * 9;
//			}
//		}

//		public Frame frame
//		{
//			get
//			{
//				return record.frames[frameNum];
//			}
//		}

//		public Result result
//		{
//			get
//			{
//				return record.result;
//			}
//		}

//		public bool isEnded
//		{
//			get
//			{
//				return result != null;
//			}
//		}

//		public bool isTimeOut
//		{
//			get
//			{
//				Option option = record.option;
//				int[,] array = new int[2, 2];
//				array[0, 0] = option.timeLimit;
//				array[0, 1] = frame.time;
//				array[1, 0] = option.turnLimit;
//				array[1, 1] = frame._waveTurn;
//				int[,] array2 = array;
//				for (int i = 0; i < array2.GetLength(0); i++)
//				{
//					if (array2[i, 0] > 0 && array2[i, 0] <= array2[i, 1])
//					{
//						return true;
//					}
//				}
//				return false;
//			}
//		}

//		public bool isTurnOut
//		{
//			get
//			{
//				Option option = record.option;
//				return option.turnLimit > 0 && option.turnLimit <= frame._waveTurn;
//			}
//		}

//		public static Simulator Create(Regulation rg, BattleData bd)
//		{
//			if (bd == null)
//			{
//				throw new ArgumentNullException("BattleData");
//			}
//			if (bd.isReplayMode)
//			{
//				return Simulator.Create(rg, bd.record);
//			}
//			List<string> list = new List<string>();
//			List<Troop> list2 = new List<Troop>();
//			for (int i = 0; i < bd.attacker.battleTroopList.Count; i++)
//			{
//				list2.Add(bd.attacker.battleTroopList[i].ToBattleTroop());
//			}
//			List<Troop> list3 = new List<Troop>();
//			for (int j = 0; j < bd.defender.battleTroopList.Count; j++)
//			{
//				list3.Add(bd.defender.battleTroopList[j].ToBattleTroop());
//			}
//			if (bd.rewardItems != null)
//			{
//				bd.rewardItems.RemoveAll((Protocols.RewardInfo.RewardData row) => row.rewardType == ERewardType.Favor);
//				Protocols.RewardInfo.RewardData rewardData = bd.rewardItems.Find((Protocols.RewardInfo.RewardData row) => row.rewardType == ERewardType.Goods && row.rewardId == "4");
//				if (rewardData != null)
//				{
//					bd.rewardItems.Remove(rewardData);
//				}
//				if (bd.rewardItems.Count > 0)
//				{
//					int count = bd.rewardItems.Count;
//					int count2 = list3.Count;
//					int num = 0;
//					for (int k = 1; k <= count2; k++)
//					{
//						num += k;
//					}
//					int num2 = 0;
//					for (int l = 0; l < list3.Count; l++)
//					{
//						Troop troop = list3[l];
//						int num3;
//						if (l == list3.Count - 1)
//						{
//							num3 = count - num2;
//						}
//						else
//						{
//							int num4 = (l + 1) * 100 / num;
//							int num5 = count * num4 / 100;
//							num3 = num5;
//						}
//						if (num3 > 0)
//						{
//							num2 += num3;
//							List<Troop.Slot> list4 = troop._slots.FindAll((Troop.Slot x) => x != null && !string.IsNullOrEmpty(x.id));
//							for (int m = 0; m < num3; m++)
//							{
//								int num6 = UnityEngine.Random.Range(0, list4.Count);
//								list4[num6].dropItemCnt++;
//							}
//						}
//					}
//				}
//			}
//			int num7 = new System.Random().Next();
//			InitState initState = InitState.Create(bd.type, list2, list3, list, num7);
//			initState._stageId = bd.stageId;
//			List<GuildSkillState> list5 = null;
//			RoLocalUser localUser = RemoteObjectManager.instance.localUser;
//			if (localUser.IsExistGuild() && localUser.guildInfo.idx != 0 && localUser.guildSkillList != null)
//			{
//				list5 = new List<GuildSkillState>();
//				for (int n = 0; n < localUser.guildSkillList.Count; n++)
//				{
//					GuildSkillState guildSkillState = localUser.guildSkillList[n].ToBattleGuildSkillData();
//					if (guildSkillState != null && guildSkillState._skillLevel > 0)
//					{
//						list5.Add(guildSkillState);
//					}
//				}
//			}
//			initState._guildSkills = list5;
//			List<string> list6 = null;
//			if (localUser.completeRewardGroupList != null)
//			{
//				list6 = new List<string>();
//				for (int num8 = 0; num8 < localUser.completeRewardGroupList.Count; num8++)
//				{
//					list6.Add(localUser.completeRewardGroupList[num8].ToString());
//				}
//			}
//			initState._groupBuffs = list6;
//			if (bd.type == EBattleType.Guerrilla)
//			{
//				initState._stageId = string.Format("{0}_{1}", bd.sweepType, bd.sweepLevel);
//			}
//			else if (bd.type == EBattleType.Raid)
//			{
//				initState._raidData = bd.raidData.ToBattleRaidData();
//			}
//			else if (bd.type == EBattleType.EventBattle)
//			{
//				initState._stageId = string.Format("{0}_{1}", bd.eventId, bd.eventLevel);
//			}
//			else if (bd.type == EBattleType.EventRaid)
//			{
//				initState._stageId = string.Format("{0}_{1}", bd.eventId, bd.eventRaidIdx);
//			}
//			else if (bd.type == EBattleType.Duel || bd.type == EBattleType.WaveDuel || bd.type == EBattleType.WorldDuel || bd.type == EBattleType.Conquest)
//			{
//				initState._dualData = new DualData();
//				initState._dualData._playerName = bd.attacker.nickname;
//				initState._dualData._playerLevel = bd.attacker.level;
//				initState._dualData._playerGuildName = bd.attacker.guildName;
//				initState._dualData._enemyName = bd.defender.nickname;
//				initState._dualData._enemyLevel = bd.defender.level;
//				initState._dualData._enemyRank = bd.defender.duelRanking;
//				initState._dualData._enemyGuildName = bd.defender.guildName;
//				initState._dualData._enemyUno = bd.defender.uno;
//				if (bd.defender.guildSkillList != null)
//				{
//					List<GuildSkillState> list7 = new List<GuildSkillState>();
//					for (int num9 = 0; num9 < bd.defender.guildSkillList.Count; num9++)
//					{
//						if (bd.defender.guildSkillList[num9].skillLevel > 0)
//						{
//							list7.Add(bd.defender.guildSkillList[num9].ToBattleGuildSkillData());
//						}
//					}
//					initState._dualData._enemyGuildSkills = list7;
//				}
//				List<string> list8 = null;
//				if (bd.defender.completeRewardGroupList != null)
//				{
//					list8 = new List<string>();
//					for (int num10 = 0; num10 < bd.defender.completeRewardGroupList.Count; num10++)
//					{
//						list8.Add(bd.defender.completeRewardGroupList[num10].ToString());
//					}
//				}
//				initState._dualData._enemyGroupBuffs = list8;
//				if (bd.type == EBattleType.WorldDuel)
//				{
//					initState._dualData._worldDuelData = new WorldDuelData();
//					initState._dualData._worldDuelData._playerWorld = bd.attacker.world;
//					initState._dualData._worldDuelData._playerBuffs = bd.attacker.GetBuffIdxList();
//					initState._dualData._worldDuelData._enemyWorld = bd.defender.world;
//					initState._dualData._worldDuelData._enemyBuffs = bd.defender.GetBuffIdxList();
//				}
//			}
//			return Simulator.Create(rg, initState);
//		}

//		public static Simulator Create(Regulation rg, InitState initState)
//		{
//			if (initState == null)
//			{
//				throw new ArgumentNullException("initState");
//			}
//			return Simulator.Create(rg, new Record
//			{
//				_simulatorVersion = 1000000,
//				_regulationVersion = rg.version,
//				_initState = initState,
//				_lhsInputMap = new Dictionary<int, Input>(),
//				_rhsInputMap = new Dictionary<int, Input>(),
//				_frames = new List<Frame>()
//			});
//		}

//		public static Simulator Create(Regulation rg, Record record)
//		{
//			if (rg == null)
//			{
//				throw new ArgumentNullException("rg");
//			}
//			if (record == null)
//			{
//				throw new ArgumentNullException("record");
//			}
//			if (1000000 < record.simulatorVersion)
//			{
//				string text = "Simulator is outdated.";
//				throw new InvalidOperationException(text);
//			}
//			Simulator simulator = new Simulator();
//			simulator.regulation = rg;
//			simulator.record = Record.Copy(record);
//			simulator._unitUpdater = new _UnitUpdater();
//			simulator._skillUpdater = new _SkillUpdater();
//			simulator._projectileUpdater = new _ProjectileUpdater();
//			simulator._timeLineUpdater = new _TimeLineUpdater();
//			simulator._statusCleaner = new _StatusEffectCleaner();
//			simulator.record._option.playMode = Option.Default.playMode;
//			simulator.record._option.timeLimit = Option.Default.timeLimit;
//			simulator.record._option.turnLimit = Option.Default.turnLimit;
//			simulator.record._option.winSideByTimeOut = Option.Default.winSideByTimeOut;
//			simulator.record._option.canSelectTarget = Option.Default.canSelectTarget;
//			simulator.record._option.canEnemyUnitCtl = Option.Default.canEnemyUnitCtl;
//			simulator.record._option.immediatelyUseActiveSkill = Option.Default.immediatelyUseActiveSkill;
//			simulator.record._option.canInterfereSkill = Option.Default.canInterfereSkill;
//			simulator.record._option.waitingInputMode = Option.Default.waitingInputMode;
//			simulator.record._option.canLhsCutIn = Option.Default.canLhsCutIn;
//			simulator.record._option.canRhsCutIn = Option.Default.canRhsCutIn;
//			simulator.record._option.enableLhsFireAction = Option.Default.enableLhsFireAction;
//			simulator.record._option.enableRhsFireAction = Option.Default.enableRhsFireAction;
//			simulator.record._option.enableFatalCut = Option.Default.enableFatalCut;
//			simulator.record._option.delayTurnChangeTime = Option.Default.delayTurnChangeTime;
//			if (simulator.initState.battleType == EBattleType.Plunder)
//			{
//				int num = rg.worldMapStageDtbl.FindIndex(record.initState.stageID);
//				if (num >= 0)
//				{
//					WorldMapStageDataRow worldMapStageDataRow = rg.worldMapStageDtbl[num];
//					simulator.record._option.timeLimit = -1;
//					simulator.record._option.turnLimit = worldMapStageDataRow.turn3;
//				}
//			}
//			else if (simulator.initState.battleType == EBattleType.Duel || simulator.initState.battleType == EBattleType.WorldDuel || simulator.initState.battleType == EBattleType.Conquest)
//			{
//				simulator.record._option.timeLimit = -1;
//				simulator.record._option.turnLimit = int.Parse(rg.defineDtbl["ARENA_END_TURN"].value);
//			}
//			else if (simulator.initState.battleType == EBattleType.WaveDuel)
//			{
//				simulator.record._option.timeLimit = -1;
//				simulator.record._option.turnLimit = int.Parse(rg.defineDtbl["ARENA_3WAVE_END_TURN"].value);
//			}
//			else if (simulator.initState.battleType == EBattleType.Guerrilla)
//			{
//				SweepDataRow sweepDataRow = rg.sweepDtbl[simulator.initState.stageID];
//				simulator.record._option.timeLimit = -1;
//				simulator.record._option.turnLimit = sweepDataRow.endTurn;
//			}
//			else if (simulator.initState.battleType == EBattleType.Annihilation)
//			{
//				AnnihilateBattleDataRow annihilateBattleDataRow = rg.annihilateBattleDtbl[simulator.initState.stageID];
//				simulator.record._option.timeLimit = -1;
//				simulator.record._option.turnLimit = annihilateBattleDataRow.endTurn;
//			}
//			else if (simulator.initState.battleType == EBattleType.ScenarioBattle)
//			{
//				ScenarioBattleDataRow scenarioBattleDataRow = rg.scenarioBattleDtbl[record.initState.stageID];
//				simulator.record._option.timeLimit = -1;
//				simulator.record._option.turnLimit = scenarioBattleDataRow.turn3;
//			}
//			else if (simulator.initState.battleType == EBattleType.WaveBattle)
//			{
//				WaveBattleDataRow waveBattleDataRow = rg.FindWaveBattleData(int.Parse(record.initState.stageID));
//				simulator.record._option.timeLimit = -1;
//				simulator.record._option.turnLimit = waveBattleDataRow.endTurn;
//			}
//			else if (simulator.initState.battleType == EBattleType.CooperateBattle)
//			{
//				CooperateBattleDataRow cooperateBattleDataRow = rg.cooperateBattleDtbl[record.initState.stageID];
//				simulator.record._option.timeLimit = -1;
//				simulator.record._option.turnLimit = cooperateBattleDataRow.endTurn;
//			}
//			else if (simulator.initState.battleType == EBattleType.EventBattle)
//			{
//				EventBattleFieldDataRow eventBattleFieldDataRow = rg.eventBattleFieldDtbl[record.initState.stageID];
//				simulator.record._option.timeLimit = -1;
//				simulator.record._option.turnLimit = eventBattleFieldDataRow.endTurn;
//			}
//			else if (simulator.initState.battleType == EBattleType.EventRaid)
//			{
//				EventRaidDataRow eventRaidDataRow = rg.eventRaidDtbl[record.initState.stageID];
//				simulator.record._option.timeLimit = -1;
//				simulator.record._option.turnLimit = eventRaidDataRow.endTurn;
//			}
//			else if (simulator.initState.battleType == EBattleType.InfinityBattle)
//			{
//				InfinityFieldDataRow infinityFieldDataRow = rg.infinityFieldDtbl[record.initState.stageID];
//				simulator.record._option.timeLimit = -1;
//				simulator.record._option.turnLimit = infinityFieldDataRow.endTurn;
//			}
//			else if (simulator.initState.battleType == EBattleType.Raid)
//			{
//				int endPhase = 0;
//				rg.raidDtbl.FindAll(delegate (RaidDataRow x)
//				{
//					if (x.key == record.initState.raidData.raidId)
//					{
//						if (x.phase >= endPhase)
//						{
//							endPhase = x.phase;
//						}
//						return true;
//					}
//					return false;
//				});
//				simulator.record._option.timeLimit = -1;
//				simulator.record._option.turnLimit = endPhase;
//			}
//			if (simulator.record.frames.Count == 0)
//			{
//				Frame frame = simulator._CreateInitFrame();
//				simulator.record._frames.Add(frame);
//				if (simulator.record._length < 1)
//				{
//					simulator.record._length = 1;
//				}
//				else
//				{
//					simulator.isReplayMode = true;
//				}
//			}
//			else
//			{
//				simulator.isReplayMode = true;
//			}
//			simulator.frameNum = 0;
//			simulator.isLhsAnnihilated = false;
//			simulator.isRhsAnnihilated = false;
//			simulator.isWaitingNextTurn = true;
//			simulator.ableAuto = false;
//			simulator.mission = new ClearMission();
//			simulator.mission.Init(simulator);
//			return simulator;
//		}

//		public static bool HasTimeEvent(int eventTime, int elapsedTime)
//		{
//			int num = elapsedTime - 66;
//			return num < eventTime && elapsedTime >= eventTime;
//		}

//		private List<Unit> _CreateInitStateUnits()
//		{
//			List<Unit> list = new List<Unit>();
//			for (int i = lhsTroops.Count - 1; i >= 0; i--)
//			{
//				Troop troop = lhsTroops[i];
//				troop._activeSlotCount = 0;
//				for (int j = 0; j < troop.slots.Count; j++)
//				{
//					Troop.Slot slot = troop.slots[j];
//					if (slot == null || slot.isEmpty)
//					{
//						list.Add(null);
//					}
//					else
//					{
//						troop._activeSlotCount++;
//						Unit unit = Unit._Create(regulation, slot.id);
//						unit._side = EBattleSide.Left;
//						unit._unitIdx = list.Count;
//						_InitUnitSlotData(unit, slot);
//						troop._speed = troop._speed + unit.speed + unit._addSpeed;
//						list.Add(unit);
//						initState._lhsUnitCount++;
//						if (unit.isDead && initState.battleType != EBattleType.WaveBattle && frameNum < record.frames.Count)
//						{
//							frame._lhsDeadUnitCount++;
//						}
//						EJob job = regulation.unitDtbl[unit.dri].job;
//						if (job != EJob.Attack)
//						{
//							if (job != EJob.Defense)
//							{
//								if (job == EJob.Support)
//								{
//									initState._lhsSupporterCount++;
//								}
//							}
//							else
//							{
//								initState._lhsDefenderCount++;
//							}
//						}
//						else
//						{
//							initState._lhsAttackerCount++;
//						}
//						if (unit._cdri >= 0)
//						{
//							CommanderDataRow commanderDataRow = regulation.commanderDtbl[unit._cdri];
//							switch (commanderDataRow.grade)
//							{
//								case 2:
//									initState._lhsInitGrade2Count++;
//									break;
//								case 3:
//									initState._lhsInitGrade3Count++;
//									break;
//								case 4:
//									initState._lhsInitGrade4Count++;
//									break;
//								case 5:
//									initState._lhsInitGrade5Count++;
//									break;
//							}
//						}
//					}
//				}
//			}
//			for (int k = 0; k < rhsTroops.Count; k++)
//			{
//				Troop troop2 = rhsTroops[k];
//				troop2._activeSlotCount = 0;
//				for (int l = 0; l < troop2.slots.Count; l++)
//				{
//					Troop.Slot slot2 = troop2.slots[l];
//					if (slot2 == null || slot2.isEmpty)
//					{
//						list.Add(null);
//					}
//					else
//					{
//						troop2._activeSlotCount++;
//						Unit unit2 = Unit._Create(regulation, slot2.id);
//						unit2._side = EBattleSide.Right;
//						unit2._unitIdx = list.Count;
//						_InitUnitSlotData(unit2, slot2);
//						initState._rhsTroopsHealth += (long)unit2._health;
//						initState._rhsTroopsMaxHealth += (long)unit2._maxHealth;
//						troop2._speed = troop2._speed + unit2.speed + unit2._addSpeed;
//						if (initState.battleType == EBattleType.Plunder || initState.battleType == EBattleType.SeaRobber || initState.battleType == EBattleType.Guerrilla)
//						{
//							UnitDataRow unitDataRow = regulation.unitDtbl[unit2.dri];
//							if (!string.IsNullOrEmpty(unitDataRow.dropGoldPattern) && unitDataRow.dropGoldPattern != "0")
//							{
//								int num = regulation.dropGoldPatternDtbl.FindIndex(unitDataRow.dropGoldPattern);
//								if (num >= 0)
//								{
//									DropGoldPatternDataRow dropGoldPatternDataRow = regulation.dropGoldPatternDtbl[num];
//									unit2._dropGold = (unit2._level - 1) / dropGoldPatternDataRow.levelStep * dropGoldPatternDataRow.goldStep;
//								}
//								else
//								{
//									Logger.Log("Not Found DropGoldPattern " + unitDataRow.dropGoldPattern);
//								}
//							}
//						}
//						list.Add(unit2);
//					}
//				}
//			}
//			return list;
//		}

//		private void _InitUnitSlotData(Unit unit, Troop.Slot slot)
//		{
//			unit._rank = slot.rank;
//			unit._level = slot.level;
//			unit._cls = slot.cls;
//			unit._cid = slot.cid;
//			if (!string.IsNullOrEmpty(unit._cid))
//			{
//				unit._cdri = regulation.commanderDtbl.FindIndex(unit._cid);
//				if (unit._cdri < 0)
//				{
//				}
//			}
//			unit._dropItemCnt = slot.dropItemCnt;
//			unit._scale = slot.scale;
//			unit._charType = (ECharacterType)slot.charType;
//			unit._marry = slot.marry;
//			unit._partIdx = slot.partIdx;
//			unit._mainIdx = slot.mainIdx;
//			_InitUnitLevelPatternData(unit, slot);
//			_InitUnitTranscendenceData(unit, slot);
//			_InitUnitWorldDuelSkillData(unit, slot);
//			_InitUnitOpartsData(unit, slot);
//			_InitUnitCostumeData(unit, slot);
//			_InitUnitFavorData(unit, slot);
//			_InitUnitGuildSkillData(unit, slot);
//			_InitUnitGroupBuffData(unit, slot);
//			_InitUnitWeaponData(unit, slot);
//			_InitUnitHealthData(unit, slot);
//			_InitUnitSkillData(unit, slot);
//		}

//		private void _InitUnitLevelPatternData(Unit unit, Troop.Slot slot)
//		{
//			UnitDataRow unitDataRow = regulation.unitDtbl[unit.dri];
//			string text = string.Format("{0}_{1}", (unit.marry != 1) ? unitDataRow.levelPattern : unitDataRow.afterLevelPattern, unit._rank);
//			int num = regulation.levelPatternDtbl.FindIndex(text);
//			if (num == -1)
//			{
//				throw new ArgumentException("Not found LevelPatternDri : " + text);
//			}
//			LevelPatternDataRow levelPatternDataRow = regulation.levelPatternDtbl[num];
//			unit._addHp = unit._level * levelPatternDataRow.hp;
//			unit._addAtk = unit._level * levelPatternDataRow.atk;
//			unit._addDef = unit._level * levelPatternDataRow.def;
//			unit._addAim = unit._level * levelPatternDataRow.aim;
//			unit._addLuck = unit._level * levelPatternDataRow.luck;
//			string text2 = string.Format("{0}_{1}", (unit.marry != 1) ? unitDataRow.classPattern : unitDataRow.afterClassPattern, unit._cls);
//			int num2 = regulation.classPatternDtbl.FindIndex(text2);
//			if (num2 == -1)
//			{
//				throw new ArgumentException("Not found ClassPatternDri : " + text2);
//			}
//			ClassPatternDataRow classPatternDataRow = regulation.classPatternDtbl[num2];
//			unit._addHp += classPatternDataRow.hp;
//			unit._addAtk += classPatternDataRow.atk;
//			unit._addDef += classPatternDataRow.def;
//			unit._addAim += classPatternDataRow.aim;
//			unit._addLuck += classPatternDataRow.luck;
//		}

//		private void _InitUnitTranscendenceData(Unit unit, Troop.Slot slot)
//		{
//			int num = 0;
//			for (int i = 0; i < slot.transcendence.Count; i++)
//			{
//				TranscendenceSlotDataRow transcendenceSlotDataRow = regulation.transcendenceSlotDtbl[i];
//				switch (transcendenceSlotDataRow.stat)
//				{
//					case StatType.ATK:
//						unit._addAtk += slot.transcendence[i] * transcendenceSlotDataRow.addStat;
//						break;
//					case StatType.DEF:
//						unit._addDef += slot.transcendence[i] * transcendenceSlotDataRow.addStat;
//						break;
//					case StatType.HP:
//						unit._addHp += slot.transcendence[i] * transcendenceSlotDataRow.addStat;
//						break;
//					case StatType.ACCUR:
//						unit._addAim += slot.transcendence[i] * transcendenceSlotDataRow.addStat;
//						break;
//					case StatType.LUCK:
//						unit._addLuck += slot.transcendence[i] * transcendenceSlotDataRow.addStat;
//						break;
//					case StatType.CRITR:
//						unit._addCitr += slot.transcendence[i] * transcendenceSlotDataRow.addStat;
//						break;
//					case StatType.CRITDMG:
//						unit._addCitDmg += slot.transcendence[i] * transcendenceSlotDataRow.addStat;
//						break;
//					case StatType.MOB:
//						unit._addSpeed += slot.transcendence[i] * transcendenceSlotDataRow.addStat;
//						break;
//				}
//				num += slot.transcendence[i];
//			}
//			if (num > 0)
//			{
//				int num2 = 0;
//				int num3 = num;
//				for (int j = 0; j < regulation.transcendenceStepUpgradeDtbl.length; j++)
//				{
//					if (num3 <= 0)
//					{
//						break;
//					}
//					TranscendenceStepUpgradeDataRow transcendenceStepUpgradeDataRow = regulation.transcendenceStepUpgradeDtbl[j];
//					int num4 = transcendenceStepUpgradeDataRow.stepPoint - num2;
//					int num5 = ((num3 >= num4) ? num4 : num3);
//					int num6 = num5 / transcendenceStepUpgradeDataRow.statAddMeasure * transcendenceStepUpgradeDataRow.statAddVolume;
//					switch (transcendenceStepUpgradeDataRow.stat)
//					{
//						case StatType.ATK:
//							unit._addAtk += num6;
//							break;
//						case StatType.DEF:
//							unit._addDef += num6;
//							break;
//						case StatType.HP:
//							unit._addHp += num6;
//							break;
//						case StatType.ACCUR:
//							unit._addAim += num6;
//							break;
//						case StatType.LUCK:
//							unit._addLuck += num6;
//							break;
//						case StatType.CRITR:
//							unit._addCitr += num6;
//							break;
//						case StatType.CRITDMG:
//							unit._addCitDmg += num6;
//							break;
//						case StatType.MOB:
//							unit._addSpeed += num6;
//							break;
//					}
//					num3 -= num5;
//					num2 = transcendenceStepUpgradeDataRow.stepPoint;
//				}
//			}
//		}

//		private void _InitUnitWorldDuelSkillData(Unit unit, Troop.Slot slot)
//		{
//			if (initState.battleType != EBattleType.WorldDuel)
//			{
//				return;
//			}
//			initState.dualData._worldDuelData.Init(regulation);
//			UnitDataRow unitDataRow = regulation.unitDtbl[unit.dri];
//			Dictionary<EWorldDuelBuff, int> dictionary = ((unit.side != EBattleSide.Left) ? initState.dualData._worldDuelData.enemyBuffs : initState.dualData._worldDuelData.plyerBuffs);
//			switch (unitDataRow.job)
//			{
//				case EJob.Attack:
//				case EJob.Attack_x:
//					unit._addAtk += (int)((long)(unitDataRow.attackDamage + unit._addAtk) * (long)dictionary[EWorldDuelBuff.att] / 10000L);
//					if (unit._addAtk < 0)
//					{
//						unit._addAtk = 0;
//					}
//					break;
//				case EJob.Defense:
//				case EJob.Defense_x:
//					unit._addDef += (int)((long)(unitDataRow.defense + unit._addDef) * (long)dictionary[EWorldDuelBuff.def] / 10000L);
//					if (unit._addDef < 0)
//					{
//						unit._addDef = 0;
//					}
//					break;
//				case EJob.Support:
//				case EJob.Support_x:
//					unit._addAtk += (int)((long)(unitDataRow.attackDamage + unit._addAtk) * (long)dictionary[EWorldDuelBuff.sup] / 10000L);
//					if (unit._addAtk < 0)
//					{
//						unit._addAtk = 0;
//					}
//					break;
//			}
//		}

//		private void _InitUnitOpartsData(Unit unit, Troop.Slot slot)
//		{
//			if (slot.equipItem == null)
//			{
//				return;
//			}
//			int num = 0;
//			int num2 = 0;
//			EItemSetType eitemSetType = EItemSetType.NONE;
//			foreach (KeyValuePair<int, Troop.Slot.Item> keyValuePair in slot.equipItem)
//			{
//				Troop.Slot.Item value = keyValuePair.Value;
//				EquipItemDataRow equipItemDataRow = regulation.equipItemDtbl[value.id];
//				int pointType = equipItemDataRow.pointType;
//				Dictionary<int, Troop.Slot.Item>.Enumerator enumerator;
//				KeyValuePair<int, Troop.Slot.Item> keyValuePair2 = enumerator.Current;
//				if (pointType != keyValuePair2.Key)
//				{
//					num++;
//				}
//				else
//				{
//					if (num == 0)
//					{
//						eitemSetType = equipItemDataRow.setItemType;
//					}
//					if (eitemSetType != EItemSetType.NONE && eitemSetType == equipItemDataRow.setItemType)
//					{
//						num2++;
//					}
//					switch (equipItemDataRow.statType)
//					{
//						case EItemStatType.ATK:
//							unit._addAtk += equipItemDataRow.GetStatPoint(value.lv);
//							break;
//						case EItemStatType.DEF:
//							unit._addDef += equipItemDataRow.GetStatPoint(value.lv);
//							break;
//						case EItemStatType.ACCUR:
//							unit._addAim += equipItemDataRow.GetStatPoint(value.lv);
//							break;
//						case EItemStatType.LUCK:
//							unit._addLuck += equipItemDataRow.GetStatPoint(value.lv);
//							break;
//					}
//					num++;
//				}
//			}
//			if (num2 == 4)
//			{
//				Troop.Slot.Item item = slot.equipItem[1];
//				EquipItemDataRow equipItemDataRow2 = regulation.equipItemDtbl[item.id];
//				switch (equipItemDataRow2.setItemType)
//				{
//					case EItemSetType.ATK:
//						unit._addAtk += equipItemDataRow2.statEffect;
//						break;
//					case EItemSetType.DEF:
//						unit._addDef += equipItemDataRow2.statEffect;
//						break;
//					case EItemSetType.ACCUR:
//						unit._addAim += equipItemDataRow2.statEffect;
//						break;
//					case EItemSetType.LUCK:
//						unit._addLuck += equipItemDataRow2.statEffect;
//						break;
//					case EItemSetType.CRITR:
//						unit._addCitr += equipItemDataRow2.statEffect;
//						break;
//					case EItemSetType.CRITDMG:
//						unit._addCitDmg += equipItemDataRow2.statEffect;
//						break;
//				}
//			}
//		}

//		private void _InitUnitCostumeData(Unit unit, Troop.Slot slot)
//		{
//			if (slot.costume <= 0)
//			{
//				return;
//			}
//			unit._ctid = slot.costume.ToString();
//			unit._ctdri = regulation.commanderCostumeDtbl.FindIndex(unit._ctid);
//			if (unit._ctdri < 0)
//			{
//				return;
//			}
//			CommanderCostumeDataRow commanderCostumeDataRow = regulation.commanderCostumeDtbl[unit._ctdri];
//			if (commanderCostumeDataRow == null)
//			{
//				return;
//			}
//			if (commanderCostumeDataRow.statType1 == StatType.ATK)
//			{
//				unit._addAtk += commanderCostumeDataRow.stat1;
//			}
//			else if (commanderCostumeDataRow.statType1 == StatType.DEF)
//			{
//				unit._addDef += commanderCostumeDataRow.stat1;
//			}
//			else if (commanderCostumeDataRow.statType1 == StatType.HP)
//			{
//				unit._addHp += commanderCostumeDataRow.stat1;
//			}
//			else if (commanderCostumeDataRow.statType1 == StatType.ACCUR)
//			{
//				unit._addAim += commanderCostumeDataRow.stat1;
//			}
//			else if (commanderCostumeDataRow.statType1 == StatType.LUCK)
//			{
//				unit._addLuck += commanderCostumeDataRow.stat1;
//			}
//			else if (commanderCostumeDataRow.statType1 == StatType.CRITR)
//			{
//				unit._addCitr += commanderCostumeDataRow.stat1;
//			}
//			else if (commanderCostumeDataRow.statType1 == StatType.CRITDMG)
//			{
//				unit._addCitDmg += commanderCostumeDataRow.stat1;
//			}
//			else if (commanderCostumeDataRow.statType1 == StatType.MOB)
//			{
//				unit._addSpeed += commanderCostumeDataRow.stat1;
//			}
//			if (commanderCostumeDataRow.statType2 == StatType.ATK)
//			{
//				unit._addAtk += commanderCostumeDataRow.stat2;
//			}
//			else if (commanderCostumeDataRow.statType2 == StatType.DEF)
//			{
//				unit._addDef += commanderCostumeDataRow.stat2;
//			}
//			else if (commanderCostumeDataRow.statType2 == StatType.HP)
//			{
//				unit._addHp += commanderCostumeDataRow.stat2;
//			}
//			else if (commanderCostumeDataRow.statType2 == StatType.ACCUR)
//			{
//				unit._addAim += commanderCostumeDataRow.stat2;
//			}
//			else if (commanderCostumeDataRow.statType2 == StatType.LUCK)
//			{
//				unit._addLuck += commanderCostumeDataRow.stat2;
//			}
//			else if (commanderCostumeDataRow.statType2 == StatType.CRITR)
//			{
//				unit._addCitr += commanderCostumeDataRow.stat2;
//			}
//			else if (commanderCostumeDataRow.statType2 == StatType.CRITDMG)
//			{
//				unit._addCitDmg += commanderCostumeDataRow.stat2;
//			}
//			else if (commanderCostumeDataRow.statType2 == StatType.MOB)
//			{
//				unit._addSpeed += commanderCostumeDataRow.stat2;
//			}
//			if (commanderCostumeDataRow.statType3 == StatType.ATK)
//			{
//				unit._addAtk += commanderCostumeDataRow.stat3;
//			}
//			else if (commanderCostumeDataRow.statType3 == StatType.DEF)
//			{
//				unit._addDef += commanderCostumeDataRow.stat3;
//			}
//			else if (commanderCostumeDataRow.statType3 == StatType.HP)
//			{
//				unit._addHp += commanderCostumeDataRow.stat3;
//			}
//			else if (commanderCostumeDataRow.statType3 == StatType.ACCUR)
//			{
//				unit._addAim += commanderCostumeDataRow.stat3;
//			}
//			else if (commanderCostumeDataRow.statType3 == StatType.LUCK)
//			{
//				unit._addLuck += commanderCostumeDataRow.stat3;
//			}
//			else if (commanderCostumeDataRow.statType3 == StatType.CRITR)
//			{
//				unit._addCitr += commanderCostumeDataRow.stat3;
//			}
//			else if (commanderCostumeDataRow.statType3 == StatType.CRITDMG)
//			{
//				unit._addCitDmg += commanderCostumeDataRow.stat3;
//			}
//			else if (commanderCostumeDataRow.statType3 == StatType.MOB)
//			{
//				unit._addSpeed += commanderCostumeDataRow.stat3;
//			}
//		}

//		private void _InitUnitFavorData(Unit unit, Troop.Slot slot)
//		{
//			unit._favorRewardStep = slot.favorRewardStep;
//			if (string.IsNullOrEmpty(unit._cid))
//			{
//				return;
//			}
//			List<FavorDataRow> list = regulation.favorDtbl.FindAll((FavorDataRow row) => row.cid == int.Parse(unit._cid) && row.step <= unit.favorRewardStep);
//			if (list == null)
//			{
//				return;
//			}
//			foreach (FavorDataRow favorDataRow in list)
//			{
//				if (favorDataRow.statType == StatType.ATK)
//				{
//					unit._addAtk += favorDataRow.stat;
//				}
//				else if (favorDataRow.statType == StatType.DEF)
//				{
//					unit._addDef += favorDataRow.stat;
//				}
//				else if (favorDataRow.statType == StatType.HP)
//				{
//					unit._addHp += favorDataRow.stat;
//				}
//				else if (favorDataRow.statType == StatType.ACCUR)
//				{
//					unit._addAim += favorDataRow.stat;
//				}
//				else if (favorDataRow.statType == StatType.LUCK)
//				{
//					unit._addLuck += favorDataRow.stat;
//				}
//				else if (favorDataRow.statType == StatType.CRITR)
//				{
//					unit._addCitr += favorDataRow.stat;
//				}
//				else if (favorDataRow.statType == StatType.CRITDMG)
//				{
//					unit._addCitDmg += favorDataRow.stat;
//				}
//				else if (favorDataRow.statType == StatType.MOB)
//				{
//					unit._addSpeed += favorDataRow.stat;
//				}
//			}
//		}

//		private void _InitUnitGuildSkillData(Unit unit, Troop.Slot slot)
//		{
//			UnitDataRow unitDataRow = regulation.unitDtbl[unit.dri];
//			List<GuildSkillState> list = null;
//			if (unit.side == EBattleSide.Left)
//			{
//				list = initState.guildSkills;
//			}
//			else if (initState.battleType == EBattleType.Duel || initState.battleType == EBattleType.WaveDuel || initState.battleType == EBattleType.WorldDuel || initState.battleType == EBattleType.Conquest)
//			{
//				list = initState.dualData._enemyGuildSkills;
//			}
//			if (list == null)
//			{
//				return;
//			}
//			for (int i = 0; i < list.Count; i++)
//			{
//				string text = string.Format("{0}_{1}", list[i]._id, list[i]._skillLevel);
//				int num = regulation.guildSkillDtbl.FindIndex(text);
//				if (num < 0)
//				{
//					throw new ArgumentException("Not found GuildData : " + text);
//				}
//				GuildSkillDataRow guildSkillDataRow = regulation.guildSkillDtbl[num];
//				list[i]._dr = guildSkillDataRow;
//				if (guildSkillDataRow.idx == 1)
//				{
//					unit._addAtk += (unitDataRow.attackDamage + unit._addAtk) * guildSkillDataRow.value / 100;
//				}
//				else if (guildSkillDataRow.idx == 2)
//				{
//					unit._addDef += (unitDataRow.defense + unit._addDef) * guildSkillDataRow.value / 100;
//				}
//				else if (guildSkillDataRow.idx == 3)
//				{
//					unit._addHp += (unitDataRow.maxHealth + unit._addHp) * guildSkillDataRow.value / 100;
//				}
//				else if (guildSkillDataRow.idx == 4)
//				{
//					unit._addAim += (unitDataRow.accuracy + unit._addAim) * guildSkillDataRow.value / 100;
//				}
//				else if (guildSkillDataRow.idx == 5)
//				{
//					unit._addLuck += (unitDataRow.luck + unit._addLuck) * guildSkillDataRow.value / 100;
//				}
//				else if (guildSkillDataRow.idx == 6)
//				{
//					unit._addCitr += (unitDataRow.criticalChance + unit._addCitr) * guildSkillDataRow.value / 100;
//				}
//				else if (guildSkillDataRow.idx == 7)
//				{
//					unit._addCitDmg += (unitDataRow.criticalDamage + unit._addCitDmg) * guildSkillDataRow.value / 100;
//				}
//				else if (guildSkillDataRow.idx == 8)
//				{
//					unit._addSpeed += guildSkillDataRow.value;
//				}
//				else if (guildSkillDataRow.idx != 9)
//				{
//					if (guildSkillDataRow.idx == 10)
//					{
//						unit._initIncreaseSp = guildSkillDataRow.value;
//					}
//				}
//			}
//		}

//		private void _InitUnitGroupBuffData(Unit unit, Troop.Slot slot)
//		{
//			Simulator.< _InitUnitGroupBuffData > c__AnonStorey3 < _InitUnitGroupBuffData > c__AnonStorey = new Simulator.< _InitUnitGroupBuffData > c__AnonStorey3();
//			< _InitUnitGroupBuffData > c__AnonStorey.unit = unit;
//			UnitDataRow unitDataRow = regulation.unitDtbl[< _InitUnitGroupBuffData > c__AnonStorey.unit.dri];
//			< _InitUnitGroupBuffData > c__AnonStorey.groupBuffs = null;
//			if (< _InitUnitGroupBuffData > c__AnonStorey.unit.side == EBattleSide.Left)
//			{
//				< _InitUnitGroupBuffData > c__AnonStorey.groupBuffs = initState._groupBuffs;
//			}
//			else if (initState.battleType == EBattleType.Duel || initState.battleType == EBattleType.WaveDuel || initState.battleType == EBattleType.WorldDuel || initState.battleType == EBattleType.Conquest)
//			{
//				< _InitUnitGroupBuffData > c__AnonStorey.groupBuffs = initState.dualData._enemyGroupBuffs;
//			}
//			if (< _InitUnitGroupBuffData > c__AnonStorey.groupBuffs == null)
//			{
//				return;
//			}
//			int gi;
//			for (gi = 0; gi < < _InitUnitGroupBuffData > c__AnonStorey.groupBuffs.Count; gi++)
//			{
//				bool flag = false;
//				GroupInfoDataRow groupInfoDataRow = regulation.groupInfoDtbl.Find((GroupInfoDataRow data) => data.groupIdx == < _InitUnitGroupBuffData > c__AnonStorey.groupBuffs[gi] && data.rewardType >= ERewardType.GroupEff_1 && data.rewardType <= ERewardType.GroupEff_8);
//				if (groupInfoDataRow != null)
//				{
//					if (groupInfoDataRow.rewardIdx == 1001)
//					{
//						if (unitDataRow.job == EJob.Attack)
//						{
//							flag = true;
//						}
//					}
//					else if (groupInfoDataRow.rewardIdx == 1002)
//					{
//						if (unitDataRow.job == EJob.Defense)
//						{
//							flag = true;
//						}
//					}
//					else if (groupInfoDataRow.rewardIdx == 1003)
//					{
//						if (unitDataRow.job == EJob.Support)
//						{
//							flag = true;
//						}
//					}
//					else if (groupInfoDataRow.rewardIdx == 1004)
//					{
//						GroupMemberDataRow groupMemberDataRow = regulation.groupMemberDtbl.Find((GroupMemberDataRow row) => row.gidx == < _InitUnitGroupBuffData > c__AnonStorey.groupBuffs[gi] && row.memberType == 1 && row.memberIdx == < _InitUnitGroupBuffData > c__AnonStorey.unit.cid);
//						if (groupMemberDataRow != null)
//						{
//							flag = true;
//						}
//					}
//					else if (groupInfoDataRow.rewardIdx == 1005)
//					{
//						flag = true;
//					}
//					else if (< _InitUnitGroupBuffData > c__AnonStorey.unit.cid == groupInfoDataRow.rewardIdx.ToString())
//					{
//						flag = true;
//					}
//					if (flag)
//					{
//						if (groupInfoDataRow.typeIndex == 1)
//						{
//							if (groupInfoDataRow.rewardType == ERewardType.GroupEff_1)
//							{
//								< _InitUnitGroupBuffData > c__AnonStorey.unit._addAtk += (unitDataRow.attackDamage + < _InitUnitGroupBuffData > c__AnonStorey.unit._addAtk) * groupInfoDataRow.minCount / 100;
//							}
//							else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_2)
//							{
//								< _InitUnitGroupBuffData > c__AnonStorey.unit._addDef += (unitDataRow.defense + < _InitUnitGroupBuffData > c__AnonStorey.unit._addDef) * groupInfoDataRow.minCount / 100;
//							}
//							else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_3)
//							{
//								< _InitUnitGroupBuffData > c__AnonStorey.unit._addHp += (unitDataRow.maxHealth + < _InitUnitGroupBuffData > c__AnonStorey.unit._addHp) * groupInfoDataRow.minCount / 100;
//							}
//							else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_4)
//							{
//								< _InitUnitGroupBuffData > c__AnonStorey.unit._addAim += (unitDataRow.accuracy + < _InitUnitGroupBuffData > c__AnonStorey.unit._addAim) * groupInfoDataRow.minCount / 100;
//							}
//							else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_5)
//							{
//								< _InitUnitGroupBuffData > c__AnonStorey.unit._addLuck += (unitDataRow.luck + < _InitUnitGroupBuffData > c__AnonStorey.unit._addLuck) * groupInfoDataRow.minCount / 100;
//							}
//							else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_6)
//							{
//								< _InitUnitGroupBuffData > c__AnonStorey.unit._addCitr += (unitDataRow.criticalChance + < _InitUnitGroupBuffData > c__AnonStorey.unit._addCitr) * groupInfoDataRow.minCount / 100;
//							}
//							else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_7)
//							{
//								< _InitUnitGroupBuffData > c__AnonStorey.unit._addCitDmg += (unitDataRow.criticalDamage + < _InitUnitGroupBuffData > c__AnonStorey.unit._addCitDmg) * groupInfoDataRow.minCount / 100;
//							}
//							else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_8)
//							{
//								< _InitUnitGroupBuffData > c__AnonStorey.unit._addSpeed += (unitDataRow.speed + < _InitUnitGroupBuffData > c__AnonStorey.unit._addSpeed) * groupInfoDataRow.minCount / 100;
//							}
//						}
//						else if (groupInfoDataRow.typeIndex == 2)
//						{
//							if (groupInfoDataRow.rewardType == ERewardType.GroupEff_1)
//							{
//								< _InitUnitGroupBuffData > c__AnonStorey.unit._addAtk = < _InitUnitGroupBuffData > c__AnonStorey.unit._addAtk + groupInfoDataRow.minCount;
//							}
//							else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_2)
//							{
//								< _InitUnitGroupBuffData > c__AnonStorey.unit._addDef = < _InitUnitGroupBuffData > c__AnonStorey.unit._addDef + groupInfoDataRow.minCount;
//							}
//							else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_3)
//							{
//								< _InitUnitGroupBuffData > c__AnonStorey.unit._addHp = < _InitUnitGroupBuffData > c__AnonStorey.unit._addHp + groupInfoDataRow.minCount;
//							}
//							else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_4)
//							{
//								< _InitUnitGroupBuffData > c__AnonStorey.unit._addAim = < _InitUnitGroupBuffData > c__AnonStorey.unit._addAim + groupInfoDataRow.minCount;
//							}
//							else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_5)
//							{
//								< _InitUnitGroupBuffData > c__AnonStorey.unit._addLuck = < _InitUnitGroupBuffData > c__AnonStorey.unit._addLuck + groupInfoDataRow.minCount;
//							}
//							else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_6)
//							{
//								< _InitUnitGroupBuffData > c__AnonStorey.unit._addCitr = < _InitUnitGroupBuffData > c__AnonStorey.unit._addCitr + groupInfoDataRow.minCount;
//							}
//							else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_7)
//							{
//								< _InitUnitGroupBuffData > c__AnonStorey.unit._addCitDmg = < _InitUnitGroupBuffData > c__AnonStorey.unit._addCitDmg + groupInfoDataRow.minCount;
//							}
//							else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_8)
//							{
//								< _InitUnitGroupBuffData > c__AnonStorey.unit._addSpeed = < _InitUnitGroupBuffData > c__AnonStorey.unit._addSpeed + groupInfoDataRow.minCount;
//							}
//						}
//					}
//				}
//			}
//		}

//		private bool _CheckWeaponData(UnitDataRow unitDr, WeaponDataRow weaponDr)
//		{
//			return weaponDr.privateWeapon != 1 || !(weaponDr.unitIdx != unitDr.key);
//		}

//		private bool _CheckWeaponData(WeaponDataRow weaponDr, EWeaponSkill skillPoint)
//		{
//			if (weaponDr.privateWeapon == 1 && weaponDr.skillPoint != EWeaponSkill.None)
//			{
//				if (weaponDr.skillPoint != skillPoint)
//				{
//					return false;
//				}
//				if (string.IsNullOrEmpty(weaponDr.skillIdx) || weaponDr.skillIdx == "0")
//				{
//					return false;
//				}
//			}
//			return true;
//		}

//		private void _ApplyUnitWeaponStatPoint(Unit unit, int weaponlevel, EItemStatType type, int basePoint, int addPoint, int pointRate)
//		{
//			switch (type)
//			{
//				case EItemStatType.ATK:
//					unit._addAtk += WeaponDataRow.GetStatPoint(weaponlevel, basePoint, addPoint) * pointRate / 100;
//					break;
//				case EItemStatType.DEF:
//					unit._addDef += WeaponDataRow.GetStatPoint(weaponlevel, basePoint, addPoint) * pointRate / 100;
//					break;
//				case EItemStatType.ACCUR:
//					unit._addAim += WeaponDataRow.GetStatPoint(weaponlevel, basePoint, addPoint) * pointRate / 100;
//					break;
//				case EItemStatType.LUCK:
//					unit._addLuck += WeaponDataRow.GetStatPoint(weaponlevel, basePoint, addPoint) * pointRate / 100;
//					break;
//				case EItemStatType.CRITDMG:
//					unit._addCitDmg += WeaponDataRow.GetStatPoint(weaponlevel, basePoint, addPoint) * pointRate / 100;
//					break;
//				case EItemStatType.MOB:
//					unit._addSpeed += WeaponDataRow.GetStatPoint(weaponlevel, basePoint, addPoint) * pointRate / 100;
//					break;
//			}
//		}

//		private void _InitUnitWeaponData(Unit unit, Troop.Slot slot)
//		{
//			if (slot.weaponItem == null)
//			{
//				return;
//			}
//			if (slot.weaponItem.Count <= 0)
//			{
//				return;
//			}
//			int num = 0;
//			string text = string.Empty;
//			UnitDataRow unitDataRow = regulation.unitDtbl[unit.dri];
//			Dictionary<int, Troop.Slot.Item>.Enumerator enumerator = slot.weaponItem.GetEnumerator();
//			while (enumerator.MoveNext())
//			{
//				DataTable<WeaponDataRow> weaponDtbl = regulation.weaponDtbl;
//				KeyValuePair<int, Troop.Slot.Item> keyValuePair = enumerator.Current;
//				WeaponDataRow weaponDataRow = weaponDtbl[keyValuePair.Value.id];
//				if (!_CheckWeaponData(unitDataRow, weaponDataRow))
//				{
//					throw new ArgumentNullException("Fail CheckWeaponData!! " + weaponDataRow.idx);
//				}
//				int num2 = 100;
//				switch (weaponDataRow.slotType)
//				{
//					case 1:
//						num2 = unitDataRow.partHead;
//						break;
//					case 2:
//						num2 = unitDataRow.partRightHand;
//						break;
//					case 3:
//						num2 = unitDataRow.partLeftHand;
//						break;
//					case 4:
//						num2 = unitDataRow.partBody;
//						break;
//					case 5:
//						num2 = unitDataRow.partSpecial;
//						break;
//				}
//				for (int i = 0; i < 4; i++)
//				{
//					KeyValuePair<int, Troop.Slot.Item> keyValuePair2 = enumerator.Current;
//					_ApplyUnitWeaponStatPoint(unit, keyValuePair2.Value.lv, weaponDataRow.statType[i], weaponDataRow.statBasePoint[i], weaponDataRow.statAddPoint[i], num2);
//				}
//				if (weaponDataRow.weaponSetType != "0")
//				{
//					if (weaponDataRow.weaponSetType != text)
//					{
//						num = 1;
//						text = weaponDataRow.weaponSetType;
//					}
//					else
//					{
//						num++;
//					}
//				}
//			}
//			if (num == 5)
//			{
//				WeaponSetDataRow weaponSetDataRow = regulation.weaponSetDtbl[text];
//				if (weaponSetDataRow != null)
//				{
//					switch (weaponSetDataRow.weaponSetStatType)
//					{
//						case EItemSetType.ATK:
//							unit._addAtk += weaponSetDataRow.weaponSetStatAddPoint;
//							break;
//						case EItemSetType.DEF:
//							unit._addDef += weaponSetDataRow.weaponSetStatAddPoint;
//							break;
//						case EItemSetType.ACCUR:
//							unit._addAim += weaponSetDataRow.weaponSetStatAddPoint;
//							break;
//						case EItemSetType.LUCK:
//							unit._addLuck += weaponSetDataRow.weaponSetStatAddPoint;
//							break;
//						case EItemSetType.CRITR:
//							unit._addCitr += weaponSetDataRow.weaponSetStatAddPoint;
//							break;
//						case EItemSetType.CRITDMG:
//							unit._addCitDmg += weaponSetDataRow.weaponSetStatAddPoint;
//							break;
//					}
//				}
//			}
//		}

//		private void _InitWeaponSkillData(Unit unit, Skill skill, Troop.Slot slot)
//		{
//			if (skill == null || slot.weaponItem == null)
//			{
//				return;
//			}
//			int count = unit.skills.Count;
//			if (!slot.weaponItem.ContainsKey(count))
//			{
//				return;
//			}
//			WeaponDataRow weaponDataRow = regulation.weaponDtbl[slot.weaponItem[count].id];
//			if ((skill.SkillDataRow.targetType == ESkillTargetType.Enemy || weaponDataRow.targetType == ESkillTargetType.Enemy) && skill.SkillDataRow.targetType != weaponDataRow.targetType)
//			{
//				return;
//			}
//			skill._weaponEffects = WeaponEffect._Create(regulation, weaponDataRow);
//		}

//		private void _InitUnitHealthData(Unit unit, Troop.Slot slot)
//		{
//			UnitDataRow unitDataRow = regulation.unitDtbl[unit.dri];
//			unit._maxHealth = (int)((long)(unitDataRow.maxHealth + unit._addHp) * (100L + (long)unit.maxHealthBonus) / 100L);
//			if (initState.battleType == EBattleType.Annihilation || initState.battleType == EBattleType.WaveBattle || (initState.battleType == EBattleType.EventRaid && unit.side == EBattleSide.Right) || initState.battleType == EBattleType.Conquest)
//			{
//				unit._health = slot.health;
//				if (unit._health > unit._maxHealth)
//				{
//					unit._health = unit._maxHealth;
//				}
//			}
//			else
//			{
//				if (initState.battleType == EBattleType.Raid && (unit._charType == ECharacterType.RaidPart || unit._charType == ECharacterType.Raid))
//				{
//					string text = string.Format("{0}_{1}_{2}", initState.raidData.raidId, 0, unit._unitIdx % 9);
//					int num = regulation.raidDtbl.FindIndex(text);
//					if (num >= 0)
//					{
//						unit._maxHealth = regulation.raidDtbl[num].health;
//					}
//					else
//					{
//						unit._maxHealth = 0;
//					}
//					if (unit._charType == ECharacterType.Raid && unit._maxHealth <= 0)
//					{
//						unit._maxHealth = 1;
//					}
//				}
//				unit._health = unit._maxHealth;
//			}
//			if (unit.health <= 0)
//			{
//				unit._isDead = true;
//			}
//		}

//		private void _AddUnitSkill(Unit unit, Skill skill)
//		{
//			if (skill == null)
//			{
//				unit._skills.Add(null);
//				return;
//			}
//			int count = unit.skills.Count;
//			if (skill.isActiveSkill)
//			{
//				unit._activeSkillIdx = count;
//			}
//			if (unit._cls >= skill.SkillDataRow.openGrade)
//			{
//				if (skill.SkillDataRow.spCostOnBeHit > 0)
//				{
//					unit._hasEventCounterSkill = true;
//				}
//				if (skill.SkillDataRow.spCostOnCombo > 0)
//				{
//					unit._hasEventComboSkill = true;
//				}
//				if (skill.SkillDataRow.remainedHealthRate >= 0)
//				{
//					unit._hasEventHpSkill = true;
//					if (skill.isIgnoreDeathType)
//					{
//						unit._deathSkillIndex = count;
//						unit._hasEventDeathSkill = true;
//						if (skill.returnMotionDri >= 0)
//						{
//							unit._isEventMeleeDeathSkill = true;
//						}
//					}
//				}
//				if (skill.SkillDataRow.spCostOnEnter > 0)
//				{
//					unit._hasEventEnterSkill = true;
//				}
//			}
//			if (count > 0 && skill.CanUse)
//			{
//				unit._hasEnabledSkill = true;
//			}
//			unit._skills.Add(skill);
//		}

//		private void _InitSkillData(Unit unit, Skill skill, Troop.Slot.Skill slot = null)
//		{
//			if (skill == null)
//			{
//				return;
//			}
//			skill._sp = skill.SkillDataRow.initSp;
//			if (slot != null)
//			{
//				int num = 0;
//				if (initState.battleType == EBattleType.WaveBattle && initState.waveBattleData._wave > 1)
//				{
//					num += slot.sp;
//				}
//				else
//				{
//					if (skill.isActiveSkill && (initState.battleType == EBattleType.Annihilation || initState.battleType == EBattleType.Conquest || unit._charType == ECharacterType.SuperMercenary || unit._charType == ECharacterType.SuperNPCMercenary))
//					{
//						num += slot.sp;
//					}
//					if (unit._initIncreaseSp > 0)
//					{
//						int num2 = skill.SkillDataRow.maxSp * unit._initIncreaseSp / 100;
//						num += num2;
//					}
//				}
//				skill._sp += num;
//				skill._level = slot.lv;
//			}
//			if (skill._sp > skill.SkillDataRow.maxSp)
//			{
//				skill._sp = skill.SkillDataRow.maxSp;
//			}
//			skill._curSp = skill._sp;
//			skill._activeState = false;
//			if (skill.CanUse)
//			{
//				skill._activeState = true;
//			}
//			if (skill._level > unit.level)
//			{
//				skill._level = unit.level;
//			}
//			skill._skillLevelFormal.SetLevelFormal(skill._level);
//		}

//		private void _InitUnitSkillData(Unit unit, Troop.Slot slot)
//		{
//			UnitDataRow unitDataRow = regulation.unitDtbl[unit.dri];
//			for (int i = 0; i < 4; i++)
//			{
//				string skillDrk = unitDataRow.skillDrks[i];
//				if (string.IsNullOrEmpty(skillDrk) || skillDrk == "0")
//				{
//					_AddUnitSkill(unit, null);
//				}
//				else
//				{
//					Troop.Slot.Skill skill = slot.skills.Find((Troop.Slot.Skill x) => x.id == skillDrk);
//					int count = unit.skills.Count;
//					if (slot.weaponItem != null && slot.weaponItem.ContainsKey(count))
//					{
//						WeaponDataRow weaponDataRow = regulation.weaponDtbl[slot.weaponItem[count].id];
//						if (!_CheckWeaponData(weaponDataRow, Regulation.ParseWeaponSkillType(count)))
//						{
//							throw new ArgumentNullException("Fail CheckWeaponData!! " + weaponDataRow.idx);
//						}
//						SkillDataRow skillDataRow = regulation.skillDtbl[skillDrk];
//						if (unit._cls < skillDataRow.openGrade)
//						{
//							throw new ArgumentNullException("Fail OpenGrade CheckWeaponData!! " + weaponDataRow.idx);
//						}
//						if (weaponDataRow.privateWeapon == 1 && weaponDataRow.skillPoint != EWeaponSkill.None)
//						{
//							skillDrk = weaponDataRow.skillIdx;
//						}
//					}
//					Skill skill2 = Skill._Create(regulation, skillDrk);
//					_InitSkillData(unit, skill2, skill);
//					_InitWeaponSkillData(unit, skill2, slot);
//					_AddUnitSkill(unit, skill2);
//				}
//			}
//			string text = string.Empty;
//			if (slot.weaponItem != null && slot.weaponItem.ContainsKey(4))
//			{
//				WeaponDataRow weaponDataRow2 = regulation.weaponDtbl[slot.weaponItem[4].id];
//				if (!_CheckWeaponData(weaponDataRow2, Regulation.ParseWeaponSkillType(4)))
//				{
//					throw new ArgumentNullException("Fail CheckWeaponData!! " + weaponDataRow2.idx);
//				}
//				if (weaponDataRow2.privateWeapon == 1 && weaponDataRow2.skillPoint != EWeaponSkill.None)
//				{
//					text = weaponDataRow2.skillIdx;
//				}
//			}
//			if (string.IsNullOrEmpty(text))
//			{
//				_AddUnitSkill(unit, null);
//			}
//			else
//			{
//				Skill skill3 = Skill._Create(regulation, text);
//				_InitSkillData(unit, skill3, new Troop.Slot.Skill
//				{
//					id = text,
//					lv = slot.level,
//					sp = 0
//				});
//				_InitWeaponSkillData(unit, skill3, slot);
//				_AddUnitSkill(unit, skill3);
//			}
//		}

//		private Frame _CreateInitFrame()
//		{
//			StellarGKLibrary.Shared.Battle.Random random = new StellarGKLibrary.Shared.Battle.Random(initState.randomSeed);
//			Frame frame = new Frame();
//			frame._units = _CreateInitStateUnits();
//			frame._lhsTroopStartIndex = GetLhsTroopStartIndex(0);
//			frame._rhsTroopStartIndex = GetRhsTroopStartIndex(0);
//			frame._lhsTimeLine = new List<int>();
//			frame._rhsTimeLine = new List<int>();
//			frame._isWaitingInput = false;
//			frame._isWaitingNextTurn = false;
//			frame._isWaitingNextWave = false;
//			frame._turn = 0;
//			frame._waveTurn = 0;
//			frame._rhsWave = 1;
//			frame._lhsWave = 1;
//			frame._onTurn = false;
//			frame._lhsOnWave = false;
//			frame._rhsOnWave = false;
//			frame._onWaveTurn = false;
//			frame._gold = 0;
//			frame._armyDestoryCnt = 0;
//			frame._navyDestoryCnt = 0;
//			_AccessFrame(new _StatusEffectCleaner(), frame);
//			_AccessFrame(new _SkillInitializer(random), frame);
//			if (initState.battleType == EBattleType.WaveBattle)
//			{
//				WaveBattleData waveBattleData = initState.waveBattleData;
//				frame._rhsWave = waveBattleData._wave;
//				frame._waveTurn = waveBattleData._waveTurn;
//				frame._lhsTimeLine = waveBattleData._lhsTurnLine;
//				if (waveBattleData._lhsWaitingInput)
//				{
//					frame._turnUnitIndex = waveBattleData._lhsTurnUnitIndex;
//					frame._isWaitingNextTurn = false;
//					frame._isWaitingInput = true;
//					Unit unit = frame.units[frame._turnUnitIndex];
//					if (unit != null)
//					{
//						Skill skill = unit._skills[0];
//						if (skill != null)
//						{
//							SkillDataRow skillDataRow = regulation.skillDtbl[skill.dri];
//							skill._sp = skillDataRow.maxSp;
//							skill._curSp = skill._sp;
//							skill._activeState = true;
//						}
//					}
//				}
//			}
//			if (option.playMode != Option.PlayMode.RealTime)
//			{
//				_AccessFrame(new _TimeLineUpdater(random), frame);
//				frame._isWaitingNextTurn = true;
//				frame._isWaitingNextWave = true;
//			}
//			else
//			{
//				frame._turn = -1;
//			}
//			frame._randomSeed = random.seed;
//			return frame;
//		}

//		private Frame _CreateNextFrame(Frame curr, Input lhsInput, Input rhsInput)
//		{
//			StellarGKLibrary.Shared.Battle.Random random = new StellarGKLibrary.Shared.Battle.Random(curr.randomSeed);
//			Frame frame = new Frame();
//			frame._lhsInput = ((lhsInput != null) ? Input.Copy(lhsInput) : null);
//			frame._rhsInput = ((rhsInput != null) ? Input.Copy(rhsInput) : null);
//			frame._units = new List<Unit>();
//			for (int i = 0; i < curr._units.Count; i++)
//			{
//				if (curr._units[i] == null)
//				{
//					frame._units.Add(null);
//				}
//				else
//				{
//					frame._units.Add(curr._units[i]);
//				}
//			}
//			frame._time = curr._time;
//			frame._turn = curr._turn;
//			frame._lhsWave = curr._lhsWave;
//			frame._rhsWave = curr._rhsWave;
//			frame._waveTurn = curr._waveTurn;
//			frame._isLhsTimeLineTurn = curr._isLhsTimeLineTurn;
//			frame._lhsTimeLine = new List<int>(curr._lhsTimeLine);
//			frame._rhsTimeLine = new List<int>(curr._rhsTimeLine);
//			frame._isWaitingInput = curr._isWaitingInput;
//			frame._isWaitingNextWave = curr._isWaitingNextWave;
//			frame._hasSkillActionUnit = curr._hasSkillActionUnit;
//			frame._isWaitingNextTurn = isWaitingNextTurn;
//			frame._turnUnitIndex = curr._turnUnitIndex;
//			frame._lhsTroopStartIndex = curr._lhsTroopStartIndex;
//			frame._rhsTroopStartIndex = curr._rhsTroopStartIndex;
//			frame._onTurn = curr._onTurn;
//			frame._gold = curr.gold;
//			frame._armyDestoryCnt = curr._armyDestoryCnt;
//			frame._navyDestoryCnt = curr._navyDestoryCnt;
//			frame._totalAttackDamage = curr._totalAttackDamage;
//			frame._lhsActiveSkillUseCount = curr._lhsActiveSkillUseCount;
//			frame._lhsDeadUnitCount = curr._lhsDeadUnitCount;
//			isLhsAnnihilated = false;
//			isRhsAnnihilated = false;
//			bool flag = record.frames.Count == 1;
//			if (flag)
//			{
//				if (frame._lhsTroopStartIndex >= 0)
//				{
//					int lhsTroopStartIndex = frame._lhsTroopStartIndex;
//					int num = lhsTroopStartIndex + 9;
//					for (int j = lhsTroopStartIndex; j < num; j++)
//					{
//						Unit unit = frame._units[j];
//						if (unit != null)
//						{
//							unit._isEnteredNow = true;
//						}
//					}
//				}
//				if (frame._rhsTroopStartIndex < frame.units.Count)
//				{
//					int rhsTroopStartIndex = frame._rhsTroopStartIndex;
//					int num2 = rhsTroopStartIndex + 9;
//					for (int k = rhsTroopStartIndex; k < num2; k++)
//					{
//						Unit unit2 = frame._units[k];
//						if (unit2 != null)
//						{
//							unit2._isEnteredNow = true;
//						}
//					}
//				}
//			}
//			frame._time += 66;
//			frame._lhsOnWave = false;
//			frame._rhsOnWave = false;
//			frame._isWaitingNextWave = true;
//			_unitUpdater.SetRandom(random);
//			_AccessFrame(_unitUpdater, frame);
//			_AccessFrame(_statusCleaner, frame);
//			_skillUpdater.SetRandom(random);
//			_AccessFrame(_skillUpdater, frame);
//			_projectileUpdater.SetRandom(random);
//			_AccessFrame(_projectileUpdater, frame);
//			if (frame._isWaitingNextWave)
//			{
//				isLhsAnnihilated = true;
//				for (int l = 0; l < 9; l++)
//				{
//					Unit unit3 = frame._units[l + frame.lhsTroopStartIndex];
//					if (unit3 != null && !unit3.isDead)
//					{
//						isLhsAnnihilated = false;
//						break;
//					}
//				}
//				if (isLhsAnnihilated && !frame._isWaitingNextTurn)
//				{
//					bool flag2 = true;
//					if (flag2)
//					{
//						bool flag3 = frame._lhsTroopStartIndex - 9 >= 0;
//						if (flag3)
//						{
//							isLhsAnnihilated = false;
//							frame._isWaitingNextTurn = false;
//						}
//					}
//				}
//				isRhsAnnihilated = true;
//				for (int m = 0; m < 9; m++)
//				{
//					Unit unit4 = frame._units[m + frame.rhsTroopStartIndex];
//					if (unit4 != null && !unit4.isDead)
//					{
//						isRhsAnnihilated = false;
//						break;
//					}
//				}
//				if (isRhsAnnihilated && !frame._isWaitingNextTurn)
//				{
//					if (initState.battleType == EBattleType.WaveBattle)
//					{
//						isRhsAnnihilated = false;
//						frame._isWaitingNextTurn = false;
//					}
//					else
//					{
//						bool flag4 = true;
//						if (flag4)
//						{
//							bool flag5 = frame._rhsTroopStartIndex + 9 < frame.units.Count;
//							if (flag5)
//							{
//								isRhsAnnihilated = false;
//								frame._isWaitingNextTurn = false;
//							}
//						}
//					}
//				}
//				if (isRhsAnnihilated || isLhsAnnihilated)
//				{
//					random.Next(0, 32767);
//					frame._randomSeed = random.seed;
//					return frame;
//				}
//			}
//			if (option.playMode != Option.PlayMode.RealTime)
//			{
//				_timeLineUpdater.SetRandom(random);
//				_AccessFrame(_timeLineUpdater, frame);
//			}
//			else
//			{
//				frame._isWaitingInput = false;
//				frame._isWaitingNextTurn = false;
//				frame._turn = -1;
//			}
//			random.Next(0, 32767);
//			frame._randomSeed = random.seed;
//			if (lhsInput != null)
//			{
//				lhsInput._result = frame._lhsInput.result;
//			}
//			if (rhsInput != null)
//			{
//				rhsInput._result = frame._rhsInput.result;
//			}
//			return frame;
//		}

//		private string _MakeChecksum(Record record)
//		{
//			StringBuilder stringBuilder = new();
//			stringBuilder.Append(record.length + ",");
//			Frame frame = record.frames[0];
//			stringBuilder.Append(frame.randomSeed + ",");
//			Frame frame2 = record.frames[record.frames.Count - 1];
//			stringBuilder.Append(frame2.randomSeed + ",");
//			for (int i = 0; i < frame2.units.Count; i++)
//			{
//				Unit unit = frame2.units[i];
//				if (unit != null)
//				{
//					stringBuilder.Append(unit.health + ",");
//					if (unit.hasActiveSkill)
//					{
//						stringBuilder.Append(unit.skills[unit._activeSkillIdx].sp + ",");
//					}
//				}
//			}
//			if (record.result != null)
//			{
//				stringBuilder.Append(record.result.winSide + ",");
//				stringBuilder.Append(record.result.isTimeOut + ",");
//				stringBuilder.Append(record.result.totalAttackDamage + ",");
//				stringBuilder.Append(record.result.gold + ",");
//				stringBuilder.Append(record.result.clearRank + ",");
//			}
//			MD5 md = MD5.Create();
//			byte[] array = md.ComputeHash(Encoding.UTF8.GetBytes(stringBuilder.ToString()));
//			return BitConverter.ToString(array).Replace("-", string.Empty);
//		}

//		private bool _TryMakeResult()
//		{
//			bool flag = frame._lhsTroopStartIndex < 0;
//			bool flag2 = frame._rhsTroopStartIndex >= unitCount;
//			if (!isTimeOut && !flag && !flag2)
//			{
//				if (isReplayMode && frameNum == record._length - 1)
//				{
//					isGiveUp = true;
//				}
//				if (!isGiveUp)
//				{
//					return false;
//				}
//			}
//			List<Troop> list = new List<Troop>();
//			for (int i = 0; i < lhsTroops.Count; i++)
//			{
//				int lhsTroopStartIndex = GetLhsTroopStartIndex(i);
//				int num = lhsTroopStartIndex + 9;
//				Troop troop = Troop.Copy(lhsTroops[i]);
//				for (int j = lhsTroopStartIndex; j < num; j++)
//				{
//					Troop.Slot slot = troop._slots[j - lhsTroopStartIndex];
//					if (frame._units[j] == null)
//					{
//						slot = null;
//					}
//					else
//					{
//						Unit unit = frame._units[j];
//						UnitDataRow unitDataRow = regulation.unitDtbl[frame._units[j].dri];
//						int num2 = unitDataRow.maxHealth + unit._addHp;
//						slot.health = unit._health;
//						if (slot.health > num2)
//						{
//							slot.health = num2;
//						}
//						else if (slot.health < 0)
//						{
//							slot.health = 0;
//						}
//						if (initState.battleType == EBattleType.Annihilation && isTimeOut)
//						{
//							slot.health = 0;
//						}
//						if (slot.health > 0)
//						{
//							if (unit.criticalHitCount > 0)
//							{
//								for (int k = 1; k < unit.skills.Count; k++)
//								{
//									Skill skill = unit.skills[k];
//									if (skill != null)
//									{
//										skill._sp += skill.SkillDataRow.spOnCriticalHit;
//										if (skill._sp >= skill.SkillDataRow.maxSp)
//										{
//											skill._sp = skill.SkillDataRow.maxSp;
//										}
//									}
//								}
//								unit._hitCount = 0;
//								unit._criticalHitCount = 0;
//							}
//							else if (unit.hitCount > 0)
//							{
//								for (int l = 1; l < unit.skills.Count; l++)
//								{
//									Skill skill2 = unit.skills[l];
//									if (skill2 != null)
//									{
//										skill2._sp += skill2.SkillDataRow.spOnHit;
//										if (skill2._sp >= skill2.SkillDataRow.maxSp)
//										{
//											skill2._sp = skill2.SkillDataRow.maxSp;
//										}
//									}
//								}
//								unit._hitCount = 0;
//								unit._criticalHitCount = 0;
//							}
//							if (unit.beHitCount > 0)
//							{
//								for (int m = 1; m < unit.skills.Count; m++)
//								{
//									Skill skill3 = unit.skills[m];
//									if (skill3 != null)
//									{
//										skill3._sp += skill3.SkillDataRow.spOnBeHit;
//										if (skill3._sp >= skill3.SkillDataRow.maxSp)
//										{
//											skill3._sp = skill3.SkillDataRow.maxSp;
//										}
//									}
//								}
//								unit._beHitCount = 0;
//							}
//						}
//						slot.damagedHealth = num2 - slot.health;
//						if (slot.damagedHealth < 0)
//						{
//							slot.damagedHealth = 0;
//						}
//						slot.skills = new List<Troop.Slot.Skill>();
//						for (int n = 1; n < 4; n++)
//						{
//							Skill skill4 = unit.skills[n];
//							if (skill4 != null)
//							{
//								Troop.Slot.Skill skill5 = new Troop.Slot.Skill();
//								skill5.id = unitDataRow.skillDrks[n];
//								skill5.lv = skill4.level;
//								skill5.sp = skill4.sp;
//								slot.skills.Add(skill5);
//							}
//						}
//						slot.statsAttack = unit.statsAttack;
//						slot.statsHealing = unit.statsHealing;
//						slot.statsDefense = unit.statsDefense;
//					}
//					troop._slots[j - lhsTroopStartIndex] = slot;
//					if (slot != null)
//					{
//						troop._statsAttack += slot.statsAttack;
//						troop._statsHealing += slot.statsHealing;
//						troop._statsDefense += slot.statsDefense;
//					}
//				}
//				list.Add(troop);
//			}
//			List<Troop> list2 = new List<Troop>();
//			for (int num3 = 0; num3 < rhsTroops.Count; num3++)
//			{
//				int rhsTroopStartIndex = GetRhsTroopStartIndex(num3);
//				int num4 = rhsTroopStartIndex + 9;
//				Troop troop2 = Troop.Copy(rhsTroops[num3]);
//				for (int num5 = rhsTroopStartIndex; num5 < num4; num5++)
//				{
//					Troop.Slot slot2 = troop2._slots[num5 - rhsTroopStartIndex];
//					if (frame._units[num5] == null)
//					{
//						slot2 = null;
//					}
//					else
//					{
//						Unit unit2 = frame._units[num5];
//						UnitDataRow unitDataRow2 = regulation.unitDtbl[frame._units[num5].dri];
//						int num6 = unitDataRow2.maxHealth + unit2._addHp;
//						slot2.health = unit2._health;
//						if (slot2.health > num6)
//						{
//							slot2.health = num6;
//						}
//						else if (slot2.health < 0)
//						{
//							slot2.health = 0;
//						}
//						if (initState.battleType == EBattleType.Annihilation && isTimeOut)
//						{
//							slot2.health = 0;
//						}
//						if (slot2.health > 0)
//						{
//							if (unit2.criticalHitCount > 0)
//							{
//								for (int num7 = 1; num7 < unit2.skills.Count; num7++)
//								{
//									Skill skill6 = unit2.skills[num7];
//									if (skill6 != null)
//									{
//										skill6._sp += skill6.SkillDataRow.spOnCriticalHit;
//										if (skill6._sp >= skill6.SkillDataRow.maxSp)
//										{
//											skill6._sp = skill6.SkillDataRow.maxSp;
//										}
//									}
//								}
//								unit2._hitCount = 0;
//								unit2._criticalHitCount = 0;
//							}
//							else if (unit2.hitCount > 0)
//							{
//								for (int num8 = 1; num8 < unit2.skills.Count; num8++)
//								{
//									Skill skill7 = unit2.skills[num8];
//									if (skill7 != null)
//									{
//										skill7._sp += skill7.SkillDataRow.spOnHit;
//										if (skill7._sp >= skill7.SkillDataRow.maxSp)
//										{
//											skill7._sp = skill7.SkillDataRow.maxSp;
//										}
//									}
//								}
//								unit2._hitCount = 0;
//								unit2._criticalHitCount = 0;
//							}
//							if (unit2.beHitCount > 0)
//							{
//								for (int num9 = 1; num9 < unit2.skills.Count; num9++)
//								{
//									Skill skill8 = unit2.skills[num9];
//									if (skill8 != null)
//									{
//										skill8._sp += skill8.SkillDataRow.spOnBeHit;
//										if (skill8._sp >= skill8.SkillDataRow.maxSp)
//										{
//											skill8._sp = skill8.SkillDataRow.maxSp;
//										}
//									}
//								}
//								unit2._beHitCount = 0;
//							}
//						}
//						slot2.damagedHealth = num6 - slot2.health;
//						if (slot2.damagedHealth < 0)
//						{
//							slot2.damagedHealth = 0;
//						}
//						if (initState.battleType == EBattleType.Conquest)
//						{
//							slot2.skills = new List<Troop.Slot.Skill>();
//							for (int num10 = 1; num10 < 4; num10++)
//							{
//								Skill skill9 = unit2.skills[num10];
//								if (skill9 != null)
//								{
//									Troop.Slot.Skill skill10 = new Troop.Slot.Skill();
//									skill10.id = unitDataRow2.skillDrks[num10];
//									skill10.lv = skill9.level;
//									skill10.sp = skill9.sp;
//									slot2.skills.Add(skill10);
//								}
//							}
//						}
//						slot2.statsAttack = unit2.statsAttack;
//						slot2.statsHealing = unit2.statsHealing;
//						slot2.statsDefense = unit2.statsDefense;
//					}
//					troop2._slots[num5 - rhsTroopStartIndex] = slot2;
//					if (slot2 != null)
//					{
//						troop2._statsAttack += slot2.statsAttack;
//						troop2._statsHealing += slot2.statsHealing;
//						troop2._statsDefense += slot2.statsDefense;
//					}
//				}
//				list2.Add(troop2);
//			}
//			bool flag3 = false;
//			Result result = new Result();
//			if (!flag3)
//			{
//				result._isTimeOut = isTimeOut;
//				if (!isTimeOut)
//				{
//					result._winSide = ((!flag) ? (-1) : 1);
//					if (initState.battleType == EBattleType.Annihilation)
//					{
//						if (flag2)
//						{
//							result._winSide = -1;
//						}
//					}
//					else if (initState.battleType == EBattleType.Conquest && flag && flag2)
//					{
//						result._winSide = 0;
//					}
//				}
//				else
//				{
//					result._winSide = option.winSideByTimeOut;
//					if (initState.battleType == EBattleType.Annihilation)
//					{
//						result._winSide = -1;
//					}
//					else if (initState.battleType == EBattleType.Conquest)
//					{
//						result._winSide = 0;
//					}
//				}
//				if (isGiveUp)
//				{
//					result._winSide = 1;
//				}
//			}
//			if (result._winSide > 0)
//			{
//				mission.MissionAllFail();
//			}
//			mission.Update();
//			result._clearRank = mission.clearCount;
//			if (initState.battleType == EBattleType.InfinityBattle)
//			{
//				result._clearRank = mission.clearValue;
//			}
//			result._gold = frame.gold;
//			result._armyDestoryCnt = frame.armyDestoryCnt;
//			result._navyDestoryCnt = frame.navyDestoryCnt;
//			result._lhsTroops = list;
//			result._rhsTroops = list2;
//			result._totalAttackDamage = frame._totalAttackDamage;
//			record._result = result;
//			record._length = frameNum + 1;
//			record._result._checksum = _MakeChecksum(record);
//			return true;
//		}

//		public void Step(Input lhsInput, Input rhsInput)
//		{
//			if (isEnded)
//			{
//				return;
//			}
//			if (isReplayMode)
//			{
//				if (lhsInput != null || rhsInput != null)
//				{
//					throw new ArgumentException("Input Error");
//				}
//				record._lhsInputMap.TryGetValue(frameNum, out lhsInput);
//				record._rhsInputMap.TryGetValue(frameNum, out rhsInput);
//			}
//			else if (option.waitingInputMode)
//			{
//			}
//			Frame frame = record.frames[frameNum];
//			Frame frame2 = _CreateNextFrame(frame, lhsInput, rhsInput);
//			record._frames.Add(frame2);
//			frameNum++;
//			if (!isReplayMode)
//			{
//				if (frame2.lhsInput != null && frame2.lhsInput.result)
//				{
//					record._lhsInputMap.Add(frameNum - 1, Input.Copy(frame2.lhsInput));
//				}
//				if (frame2.rhsInput != null && frame2.rhsInput.result)
//				{
//					record._rhsInputMap.Add(frameNum - 1, Input.Copy(frame2.rhsInput));
//				}
//				record._length = frameNum + 1;
//			}
//			if (isLhsAnnihilated)
//			{
//				frame2._lhsTroopStartIndex -= 9;
//				if (frame2._lhsTroopStartIndex >= 0)
//				{
//					int num = frame2._lhsTroopStartIndex;
//					int num2 = num + 9;
//					for (int i = num; i < num2; i++)
//					{
//						Unit unit = frame2._units[i];
//						if (unit != null)
//						{
//							unit._isEnteredNow = true;
//						}
//					}
//					frame2._lhsWave++;
//					frame2._lhsOnWave = true;
//					if (!isRhsAnnihilated && frame2._rhsTroopStartIndex < frame2.units.Count)
//					{
//						num = frame2._rhsTroopStartIndex;
//						num2 = num + 9;
//						for (int j = num; j < num2; j++)
//						{
//							Unit unit2 = frame2._units[j];
//							if (unit2 != null)
//							{
//								unit2._isEnteredNow = true;
//							}
//						}
//					}
//				}
//			}
//			if (isRhsAnnihilated)
//			{
//				frame2._rhsTroopStartIndex += 9;
//				if (frame2._rhsTroopStartIndex < frame2.units.Count)
//				{
//					int num3 = frame2._rhsTroopStartIndex;
//					int num4 = num3 + 9;
//					for (int k = num3; k < num4; k++)
//					{
//						Unit unit3 = frame2._units[k];
//						if (unit3 != null)
//						{
//							unit3._isEnteredNow = true;
//						}
//					}
//					frame2._rhsWave++;
//					frame2._rhsOnWave = true;
//					if (!isLhsAnnihilated && frame2._lhsTroopStartIndex >= 0)
//					{
//						num3 = frame2._lhsTroopStartIndex;
//						num4 = num3 + 9;
//						for (int l = num3; l < num4; l++)
//						{
//							Unit unit4 = frame2._units[l];
//							if (unit4 != null)
//							{
//								unit4._isEnteredNow = true;
//							}
//						}
//					}
//				}
//			}
//			_TryMakeResult();
//			mission.Update();
//		}

//		public int GetUnitIndexByOffset(int unitIndex, int x, int z)
//		{
//			int num = unitIndex % 9;
//			int num2 = 3;
//			x += num % num2;
//			z += num / num2;
//			if (x < 0 || x >= num2 || z < 0)
//			{
//				return -1;
//			}
//			int num3 = num2 * z + x;
//			if (num3 < 9)
//			{
//				return unitIndex - num + num3;
//			}
//			return -1;
//		}

//		public int GetLhsTroopStartIndex(int troopIndex)
//		{
//			int num = lhsTroops.Count - troopIndex - 1;
//			return num * 9;
//		}

//		public int GetLhsUnitIndex(int troopIndex, int slotIndex)
//		{
//			int lhsTroopStartIndex = GetLhsTroopStartIndex(troopIndex);
//			return lhsTroopStartIndex + slotIndex;
//		}

//		public int GetLhsTroopIndex(int unitIndex)
//		{
//			int count = initState._lhsTroops.Count;
//			if (unitIndex < GetLhsTroopStartIndex(count - 1))
//			{
//				return -1;
//			}
//			if (unitIndex >= GetRhsTroopStartIndex(0))
//			{
//				return -1;
//			}
//			return count - 1 - unitIndex / 9;
//		}

//		public int GetRhsTroopStartIndex(int troopIndex)
//		{
//			int num = lhsTroops.Count + troopIndex;
//			return num * 9;
//		}

//		public int GetRhsUnitIndex(int troopIndex, int slotIndex)
//		{
//			int rhsTroopStartIndex = GetRhsTroopStartIndex(troopIndex);
//			return rhsTroopStartIndex + slotIndex;
//		}

//		public int GetRhsTroopIndex(int unitIndex)
//		{
//			if (unitIndex < GetRhsTroopStartIndex(0))
//			{
//				return -1;
//			}
//			if (unitIndex >= unitCount)
//			{
//				return -1;
//			}
//			return unitIndex / 9 - lhsTroops.Count;
//		}

//		public void AccessFrame(FrameAccessor accessor)
//		{
//			AccessFrame(accessor, frameNum);
//		}

//		public void AccessFrame(FrameAccessor accessor, int frameNum)
//		{
//			if (frameNum < 0 || frameNum + 1 > record.frames.Count)
//			{
//				throw new ArgumentOutOfRangeException("frameNum");
//			}
//			Frame frame = record.frames[frameNum];
//			_AccessFrame(accessor, frame);
//		}

//		private void _AccessFrame(FrameAccessor accessor, Frame frame)
//		{
//			if (accessor == null)
//			{
//				throw new ArgumentNullException("accessor");
//			}
//			if (accessor._AccessFrame(this, frame))
//			{
//				for (int i = 0; i < frame._units.Count; i++)
//				{
//					Unit unit = frame._units[i];
//					if (unit != null)
//					{
//						_AccessUnit(accessor, i, unit);
//					}
//				}
//			}
//			accessor.OnFrameAccessEnd();
//		}

//		public void _AccessUnit(FrameAccessor accessor, int index, Unit unit)
//		{
//			if (accessor._AccessUnit(index, unit))
//			{
//				for (int i = 0; i < unit._skills.Count; i++)
//				{
//					Skill skill = unit._skills[i];
//					if (skill != null)
//					{
//						_AccessSkill(accessor, i, skill);
//					}
//				}
//			}
//			accessor.OnUnitAccessEnd();
//		}

//		private void _AccessSkill(FrameAccessor accessor, int index, Skill skill)
//		{
//			if (accessor._AccessSkill(index, skill))
//			{
//				int num = 0;
//				for (int i = 0; i < skill._firePoints.Count; i++)
//				{
//					FirePoint firePoint = skill._firePoints[i];
//					if (firePoint != null)
//					{
//						num = i;
//						_AccessFirePoint(accessor, i, firePoint);
//					}
//				}
//				for (int j = 0; j < skill._fireSubPoints.Count; j++)
//				{
//					FirePoint firePoint2 = skill._fireSubPoints[j];
//					if (firePoint2 != null)
//					{
//						_AccessFirePoint(accessor, num, firePoint2);
//					}
//				}
//			}
//			accessor.OnSkillAccessEnd();
//		}

//		private void _AccessFirePoint(FrameAccessor accessor, int index, FirePoint firePoint)
//		{
//			if (accessor._AccessFirePoint(index, firePoint))
//			{
//				for (int i = 0; i < firePoint._projectiles.Count; i++)
//				{
//					Projectile projectile = firePoint._projectiles[i];
//					if (projectile != null)
//					{
//						accessor._AccessProjectile(i, projectile);
//						accessor.OnProjectileAccessEnd();
//					}
//				}
//			}
//			accessor.OnFirePointAccessEnd();
//		}

//		public bool CanUnitControl(Unit unit)
//		{
//			return !unit.isEnemyType || option.canEnemyUnitCtl;
//		}

//		public bool CanSkillAction(Unit unit, int skillIdx)
//		{
//			return (option.immediatelyUseActiveSkill || frame.turnUnitIndex == unit._unitIdx) && !unit.isWaitingReturnMotion && (option.canInterfereSkill || !unit.isUsingSkill) && unit.CanSkillAction(skillIdx);
//		}

//		public bool CanUnitInput(Unit unit)
//		{
//			return CanUnitControl(unit) && unit.hasActiveSkill && CanSkillAction(unit, unit._activeSkillIdx) && frame.FindSkillTarget(regulation, unit._unitIdx, unit._activeSkillIdx, 0) >= 0;
//		}

//		public bool CanUnitInput(int unitIdx)
//		{
//			Unit unit = frame.units[unitIdx];
//			return unit != null && CanUnitInput(unit);
//		}

//		public bool CanEnableFireAction(Unit unit)
//		{
//			bool flag = option.enableEffect;
//			if (unit.side == EBattleSide.Right)
//			{
//				if (!option.enableRhsFireAction)
//				{
//					flag = false;
//				}
//			}
//			else if (!option.enableLhsFireAction)
//			{
//				flag = false;
//			}
//			return flag;
//		}

//		public static Record Simulation(Regulation rg, string record, bool replay = false)
//		{
//			Record record2 = (Record)JsonConvert.DeserializeObject<JToken>(record);
//			if (!replay)
//			{
//				record2._lhsInputMap.Clear();
//				record2._rhsInputMap.Clear();
//				record2._length = 0;
//			}
//			Simulator simulator = Simulator.Create(rg, record2);
//			Input input = null;
//			while (!simulator.isEnded)
//			{
//				if (!simulator.isReplayMode)
//				{
//					input = null;
//					int lhsTroopStartIndex = simulator.frame.lhsTroopStartIndex;
//					for (int i = 0; i < 9; i++)
//					{
//						Unit unit = simulator.frame.units[lhsTroopStartIndex + i];
//						if (unit != null && simulator.CanUnitControl(unit) && unit.hasActiveSkill && simulator.frame.CanUseSkill(simulator.option) && simulator.CanSkillAction(unit, unit._activeSkillIdx))
//						{
//							int num = simulator.frame.FindSkillTarget(simulator.regulation, unit._unitIdx, unit._activeSkillIdx, 0);
//							if (num >= 0)
//							{
//								input = new Input(unit._unitIdx, unit._activeSkillIdx, -1);
//							}
//						}
//					}
//				}
//				simulator.Step(input, null);
//			}
//			JToken jtoken = (JToken)simulator.record;
//			JToken jtoken2 = (JToken)simulator.record.result;
//			return simulator.record;
//		}

//		public static Record Simulation(Regulation rg, BattleData bd, bool enableEffect = true)
//		{
//			Simulator simulator = Simulator.Create(rg, bd);
//			if (simulator == null)
//			{
//				return null;
//			}
//			simulator.record._option.enableEffect = enableEffect;
//			while (!simulator.isEnded)
//			{
//				Input input = null;
//				int lhsTroopStartIndex = simulator.frame.lhsTroopStartIndex;
//				for (int i = 0; i < 9; i++)
//				{
//					Unit unit = simulator.frame.units[lhsTroopStartIndex + i];
//					if (unit != null && simulator.CanUnitControl(unit) && unit.hasActiveSkill && simulator.frame.CanUseSkill(simulator.option) && simulator.CanSkillAction(unit, unit._activeSkillIdx))
//					{
//						int num = simulator.frame.FindSkillTarget(simulator.regulation, unit._unitIdx, unit._activeSkillIdx, 0);
//						if (num >= 0)
//						{
//							input = new Input(unit._unitIdx, unit._activeSkillIdx, -1);
//						}
//					}
//				}
//				simulator.Step(input, null);
//			}
//			return simulator.record;
//		}

//		public Unit FindLhsUnitByCmdResId(string resourceId)
//		{
//			for (int i = 0; i < lhsTroops.Count; i++)
//			{
//				int lhsTroopStartIndex = GetLhsTroopStartIndex(i);
//				for (int j = 0; j < 9; j++)
//				{
//					Unit unit = frame.units[j + lhsTroopStartIndex];
//					if (unit != null)
//					{
//						if (unit._cdri >= 0)
//						{
//							if (regulation.commanderDtbl[unit._cdri].resourceId == resourceId)
//							{
//								return unit;
//							}
//						}
//					}
//				}
//			}
//			return null;
//		}

//		public static int ActiveTroopCount(IList<Troop> troops)
//		{
//			int num = 0;
//			for (int i = 0; i < troops.Count; i++)
//			{
//				if (troops[i]._activeSlotCount > 0)
//				{
//					num++;
//				}
//			}
//			return num;
//		}

//		public const int Version = 1000000;

//		public const int FixedDeltaTime = 66;

//		private bool _isGiveUp;

//		protected _UnitUpdater _unitUpdater;

//		protected _SkillUpdater _skillUpdater;

//		protected _ProjectileUpdater _projectileUpdater;

//		protected _TimeLineUpdater _timeLineUpdater;

//		protected _StatusEffectCleaner _statusCleaner;
//	}
//}
