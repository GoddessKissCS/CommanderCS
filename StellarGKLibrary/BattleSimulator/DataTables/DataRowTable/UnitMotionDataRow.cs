using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class UnitMotionDataRow : DataRow
	{
		private UnitMotionDataRow()
		{
		}

		public string key { get; private set; }

		public int playTime { get; private set; }

		[JsonIgnore]
		public IList<FireEvent> fireEvents
		{
			get
			{
				return _fireEvents.AsReadOnly();
			}
		}

		[JsonIgnore]
		public IList<AttackSwitchEvent> atkSwitchEvents
		{
			get
			{
				return _atkSwitchEvents.AsReadOnly();
			}
		}

		[JsonIgnore]
		public IList<int> fireCounts
		{
			get
			{
				return _fireCounts.AsReadOnly();
			}
		}

		[JsonIgnore]
		public int totalFireCount
		{
			get
			{
				int num = 0;
				foreach (int num2 in fireCounts)
				{
					num += num2;
				}
				return num;
			}
		}


		private void OnDeserialized(StreamingContext context)
		{
			Regulation.ExtendList<FireEvent>(ref _fireEvents, 20);
			Regulation.FillList<int>(ref _fireCounts, 3);
		}

		public string GetKey()
		{
			return key;
		}

		public static string MakeKey(string assetPath, string animationClipName)
		{
			string prefabHome = UnitDataRow.PrefabHome;
			if (assetPath.IndexOf(prefabHome) != 0)
			{
				throw new ArgumentException();
			}
			string text = assetPath.Substring((prefabHome + "/").Length);
			text = text.Substring(0, text.LastIndexOf("/"));
			if (text.StartsWith(UnitDataRow.ResourceIdPrefix))
			{
				string text2 = text.Substring(UnitDataRow.ResourceIdPrefix.Length);
				int num = 0;
				if (int.TryParse(text2, out num))
				{
					text = num.ToString();
				}
			}
			return text + "/" + animationClipName;
		}

		public static string MakeAnimationClipName(string key)
		{
			int num = key.LastIndexOf("/") + 1;
			if (num <= 0 || num >= key.Length)
			{
				return string.Empty;
			}
			return key.Substring(num);
		}

		public static UnitMotionDataRow Create(string key, int playTime, List<FireEvent> fireEvents, List<AttackSwitchEvent> atkSwitchEvents)
		{
			UnitMotionDataRow unitMotionDataRow = new UnitMotionDataRow();
			unitMotionDataRow.key = key;
			unitMotionDataRow.playTime = playTime;
			unitMotionDataRow._fireEvents = fireEvents;
			unitMotionDataRow._atkSwitchEvents = atkSwitchEvents;
			unitMotionDataRow._fireCounts = new List<int>(new int[3]);
			foreach (FireEvent fireEvent in fireEvents)
			{
				if (fireEvent != null)
				{
					List<int> fireCounts;
					int firePointTypeIndex;
					(fireCounts = unitMotionDataRow._fireCounts)[firePointTypeIndex = fireEvent.firePointTypeIndex] = fireCounts[firePointTypeIndex] + 1;
				}
			}
			return unitMotionDataRow;
		}

		public const int FirePointTypeCount = 3;

		public const int FireEventCount = 20;

		[JsonProperty("fireEvent")]
		private List<FireEvent> _fireEvents;

		[JsonProperty("atkSwitchEvents")]
		private List<AttackSwitchEvent> _atkSwitchEvents;

		[JsonProperty("fireCounts")]
		private List<int> _fireCounts;
	}
}
