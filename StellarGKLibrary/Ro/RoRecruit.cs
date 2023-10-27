using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]
public class RoRecruit
{
	[JsonProperty]
	public TimeData refreshTime { get; set; }

	[JsonProperty]
	public List<RoRecruit.Entry> entryList { get; set; }

	public int entryCount { get; set; }

	[OnDeserialized]
	private void OnDeserialized(StreamingContext context)
	{
		if (entryList == null)
		{
			entryList = new List<RoRecruit.Entry>();
		}
	}

	public static RoRecruit Create()
	{
		return new RoRecruit
		{
			entryList = new List<RoRecruit.Entry>(),
			refreshTime = TimeData.Create(),
			entryCount = 8
		};
	}

	public void Clear()
	{
		entryList.Clear();
		refreshTime.SetInvalidValue();
	}

	public List<RoCommander> GetCommanderList()
	{
		List<RoCommander> list = new List<RoCommander>();
		entryList.ForEach(delegate(RoRecruit.Entry entry)
		{
			list.Add(entry.commander);
		});
		return list;
	}

	public RoRecruit.Entry Find(string commanderId)
	{
		return entryList.Find((RoRecruit.Entry entry) => entry.commander.id == commanderId);
	}

	public int FindIndex(string commanderId)
	{
		return entryList.FindIndex((RoRecruit.Entry entry) => entry.commander.id == commanderId);
	}

	public void RemoveNoDealyCommander()
	{
		entryList.RemoveAll((RoRecruit.Entry entry) => entry.recruited || !entry.delayTime.IsProgress());
	}

	public static double RefreshInterval = Utility.ToSeconds(0.0, 0.0, 1.0, 0.0);

	public static double DelayTimePerWait = Utility.ToSeconds(7.0, 0.0, 0.0, 0.0);

	[JsonObject]
	public class Entry
	{
		public RoCommander commander { get; set; }

		public bool recruited { get; set; }

		public bool exist { get; set; }

		public TimeData delayTime { get; set; }

		public int delayCount { get; set; }

		public int gold { get; set; }

		public int honor { get; set; }

		public int medal { get; set; }


		private void OnDeserialized(StreamingContext context)
		{
		}

		public static RoRecruit.Entry Create(string commanderId, int level, int grade, int cls, int costume, int favorRewardStep, int marry, List<int> transcendence)
		{
			return new RoRecruit.Entry
			{
				commander = RoCommander.Create(commanderId, level, grade, cls, costume, favorRewardStep, marry, transcendence, "N"),
				recruited = false,
				delayTime = TimeData.Create(),
				delayCount = 0
			};
		}
	}
}
