using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Shared.Regulation;

[JsonObject]
public class RoScramble
{
	public string id { get; private set; }

	public List<RoScramble.Stage> stageList { get; private set; }

	public string lastOpenedStageId { get; set; }

	public RoScramble.Stage lastOpenedStage
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
			stageList.ForEach(delegate(RoScramble.Stage row)
			{
				if (row.isCleared)
				{
					count++;
				}
			});
			return count;
		}
	}

	private static Regulation _reg
	{
		get
		{
			return RemoteObjectManager.instance.regulation;
		}
	}

	public List<GuildStruggleDataRow> stageDataRowList
	{
		get
		{
			return RoScramble._reg.guildStruggleDtbl.FindAll((GuildStruggleDataRow row) => true);
		}
	}

	public bool isComplete
	{
		get
		{
			return false;
		}
	}

	public string name
	{
		get
		{
			return string.Empty;
		}
	}

	public static RoScramble Create()
	{
		RoScramble roScramble = new RoScramble();
		List<RoScramble.Stage> stageList = new List<RoScramble.Stage>();
		List<GuildStruggleDataRow> stageDataRowList = roScramble.stageDataRowList;
		stageDataRowList.ForEach(delegate(GuildStruggleDataRow row)
		{
			stageList.Add(RoScramble.Stage.Create(row.idx));
		});
		roScramble.stageList = stageList;
		if (stageList.Count > 0)
		{
			roScramble.OpenStage(stageList[0].id);
		}
		return roScramble;
	}

	public RoScramble.Stage FindStage(string stageId)
	{
		return stageList.Find((RoScramble.Stage stage) => stage.id == stageId);
	}

	public void OpenStage(string stageId)
	{
	}

	public void StageClear(string stageId)
	{
	}

	[JsonObject]
	public class Stage
	{
		public string id { get; private set; }

		public bool isOpen { get; set; }

		public bool clear { get; set; }

		public int hp { get; set; }

		public bool isCleared
		{
			get
			{
				return clear;
			}
		}

		public string commanderId { get; set; }

		public GuildStruggleDataRow data
		{
			get
			{
				return RoScramble._reg.guildStruggleDtbl[id];
			}
		}

		public static RoScramble.Stage Create(string id)
		{
			return new RoScramble.Stage
			{
				id = id,
				isOpen = false,
				clear = false
			};
		}

		public RoUser GetEnemy()
		{
			return null;
		}
	}
}
