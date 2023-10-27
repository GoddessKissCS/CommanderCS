using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Shared.Regulation;

[JsonObject]
public class RoWorldMap
{
	public string id { get; private set; }

	public List<RoWorldMap.Stage> stageList { get; private set; }

	public bool rwd { get; set; }

	public string lastOpenedStageId { get; private set; }

	public RoWorldMap.Stage lastOpenedStage
	{
		get
		{
			return FindStage(lastOpenedStageId);
		}
	}

	public int stageCount
	{
		get
		{
			return stageList.Count;
		}
	}

	public int clearStageCount
	{
		get
		{
			int count = 0;
			stageList.ForEach(delegate(RoWorldMap.Stage row)
			{
				if (row.isCleared)
				{
					count++;
				}
			});
			return count;
		}
	}

	public int maxStarCount
	{
		get
		{
			return stageList.Count * 3;
		}
	}

	public int starCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < stageList.Count; i++)
			{
				num += stageList[i].star;
			}
			return num;
		}
	}

	private static Regulation _reg
	{
		get
		{
			return RemoteObjectManager.instance.regulation;
		}
	}

	public WorldMapDataRow dataRow
	{
		get
		{
			return RoWorldMap._reg.worldMapDtbl[id];
		}
	}

	public List<WorldMapStageDataRow> stageDataRowList
	{
		get
		{
			return RoWorldMap._reg.worldMapStageDtbl.FindAll((WorldMapStageDataRow row) => row.worldMapId == id);
		}
	}

	public bool isComplete
	{
		get
		{
			return stageCount > 0 && stageCount == clearStageCount;
		}
	}

	public bool isActivate
	{
		get
		{
			return stageCount > 0 && dataRow.unlockUserLevel <= RemoteObjectManager.instance.localUser.level;
		}
	}

	public bool canMoveNextMap
	{
		get
		{
			if (stageCount > clearStageCount)
			{
				return false;
			}
			int num = RoWorldMap._reg.worldMapDtbl.FindIndex(id);
			return RoWorldMap._reg.worldMapDtbl.IsValidIndex(num + 1) && RoWorldMap._reg.worldMapDtbl[num + 1].unlockUserLevel <= RemoteObjectManager.instance.localUser.level;
		}
	}

	public bool canMovePreviousMap
	{
		get
		{
			int num = RoWorldMap._reg.worldMapDtbl.FindIndex(id);
			return RoWorldMap._reg.worldMapDtbl.IsValidIndex(num - 1) && num - 1 != 0 && RoWorldMap._reg.worldMapDtbl[num - 1] != null;
		}
	}

	public string name
	{
		get
		{
			return dataRow.name;
		}
	}

	public static List<RoWorldMap> CreateAll()
	{
		List<RoWorldMap> list = new List<RoWorldMap>();
		RoWorldMap._reg.worldMapDtbl.ForEach(delegate(WorldMapDataRow row)
		{
			list.Add(RoWorldMap.Create(row.id));
		});
		return list;
	}

	public static RoWorldMap Create(string worldMapId)
	{
		if (!RoWorldMap._reg.worldMapDtbl.ContainsKey(worldMapId))
		{
			return null;
		}
		RoWorldMap roWorldMap = new RoWorldMap();
		roWorldMap.id = worldMapId;
		List<RoWorldMap.Stage> stageList = new List<RoWorldMap.Stage>();
		List<WorldMapStageDataRow> stageDataRowList = roWorldMap.stageDataRowList;
		stageDataRowList.ForEach(delegate(WorldMapStageDataRow row)
		{
			stageList.Add(RoWorldMap.Stage.Create(row.id));
		});
		roWorldMap.stageList = stageList;
		if (stageList.Count > 0)
		{
			roWorldMap.OpenStage(stageList[0].id);
		}
		return roWorldMap;
	}

	public RoWorldMap.Stage FindStage(string stageId)
	{
		return stageList.Find((RoWorldMap.Stage stage) => stage.id == stageId);
	}

	public RoWorldMap.Stage FindNextStage(string stageId)
	{
		int num = stageList.FindIndex((RoWorldMap.Stage row) => row.id == stageId);
		num++;
		if (num < 0 || num >= stageList.Count)
		{
			return null;
		}
		return stageList[num];
	}

	public RoWorldMap.Stage FindPreviousStage(string stageId)
	{
		int num = stageList.FindIndex((RoWorldMap.Stage row) => row.id == stageId);
		num--;
		if (num < 0 || num >= stageList.Count)
		{
			return null;
		}
		return stageList[num];
	}

	public void OpenStage(string stageId)
	{
		RoWorldMap.Stage stage = FindStage(stageId);
		stage.isOpen = true;
		lastOpenedStageId = stageId;
		if (stage.data.type == EStageTypeIdRange.PowerPlant)
		{
			stage = FindNextStage(stageId);
			if (stage == null)
			{
				return;
			}
			OpenStage(stage.id);
		}
	}

	public void StageClear(string stageId)
	{
		RoWorldMap.Stage stage = FindStage(stageId);
		stage.clearCount++;
		stage = FindNextStage(stageId);
		if (stage == null)
		{
			return;
		}
		OpenStage(stage.id);
	}

	public void RefreshByClearCount()
	{
		for (int i = 0; i < stageList.Count; i++)
		{
			RoWorldMap.Stage stage = null;
			if (i > 0)
			{
				stage = stageList[i - 1];
			}
			RoWorldMap.Stage stage2 = stageList[i];
			if (stage == null || stage.isCleared)
			{
				stage2.isOpen = true;
			}
			else
			{
				stage2.isOpen = false;
			}
			if (stage2.isOpen)
			{
				lastOpenedStageId = stage2.id;
			}
		}
	}

	[JsonObject]
	public class Stage
	{
		public string id { get; private set; }

		public bool isOpen { get; set; }

		public bool clear { get; set; }

		public int star { get; set; }

		public bool canBattle
		{
			get
			{
				return typeData.battleCount > clearCount;
			}
		}

		public bool isCleared
		{
			get
			{
				return clear;
			}
		}

		public bool isProduct
		{
			get
			{
				return !string.IsNullOrEmpty(commanderId) && time.IsValid();
			}
		}

		public int clearCount { get; set; }

		public int clearEnableCount
		{
			get
			{
				return typeData.battleCount - clearCount;
			}
		}

		public string commanderId { get; set; }

		public TimeData time { get; set; }

		public int targetTime { get; set; }

		public int rechargeCount
		{
			get
			{
				RoLocalUser localUser = RemoteObjectManager.instance.localUser;
				if (localUser.stageRechargeList.ContainsKey(id))
				{
					return localUser.stageRechargeList[id];
				}
				return 0;
			}
		}

		public CommanderDataRow commanderData
		{
			get
			{
				return RoWorldMap._reg.commanderDtbl[commanderId];
			}
		}

		public WorldMapStageDataRow data
		{
			get
			{
				return RoWorldMap._reg.worldMapStageDtbl[id];
			}
		}

		public WorldMapStageTypeDataRow typeData
		{
			get
			{
				return RoWorldMap._reg.worldMapStageTypeDtbl[data.typeId];
			}
		}

		public static RoWorldMap.Stage Create(string id)
		{
			return new RoWorldMap.Stage
			{
				id = id,
				isOpen = false,
				clearCount = 0,
				clear = false,
				time = TimeData.Create()
			};
		}

		public RoUser GetEnemy()
		{
			return RoUser.CreateNPC("Enemy-" + data.enemyId, "NPC", RoTroop.CreateEnemy(data.enemyId));
		}
	}
}
