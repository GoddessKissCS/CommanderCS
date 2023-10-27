using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class CommanderDataRow : DataRow
	{
		public string id { get; set; }

		public string S_Idx { get; set; }

		public ECommanderType C_Type { get; set; }

		public bool npc { get; private set; }

		public string resourceId { get; set; }

		public string thumbnailId
		{
			get
			{
				return resourceId + "_1";
			}
		}

		public string worldMapRewardId
		{
			get
			{
				return resourceId + "_t3";
			}
		}

		public EGender gender { get; set; }

		public string unitId { get; set; }

		private string _isAcademyExposure
		{
			get
			{
				return isAcademyExposure.ToString();
			}
			set
			{
				isAcademyExposure = Regulation.ParseBool(value);
			}
		}

		public bool isAcademyExposure { get; set; }

		public int grade { get; set; }

		public int recruitHonor { get; set; }

		public int recruitGold { get; set; }

		public int overlapReward { get; set; }

		public int leadership { get; set; }

		public int favormax { get; set; }

		public string medalExplanation { get; set; }

		public string explanation { get; set; }

		public int marry { get; set; }

		public int vip { get; set; }

		public string levelPattern { get; set; }

		public string GetKey()
		{
			return id;
		}

		public string nickname
		{
			get
			{
				return Localization.Get(S_Idx);
			}
		}

		public CommanderVoiceDataRow GetVoiceDataRow(ECommanderVoiceEventType type)
		{
			if (_voiceEvents == null)
			{
				Regulation regulation = RemoteObjectManager.instance.regulation;
				int length = Enum.GetValues(typeof(ECommanderVoiceEventType)).Length;
				_voiceEvents = new CommanderVoiceDataRow[length];
				for (int i = 0; i < length; i++)
				{
					int num = regulation.commanderVoiceDtbl.FindIndex(string.Format("{0}_{1}", id, i));
					if (num >= 0)
					{
						_voiceEvents[i] = regulation.commanderVoiceDtbl[num];
					}
				}
			}
			return _voiceEvents[(int)type];
		}

		public List<CommanderVoiceDataRow> GetVoiceDataList()
		{
			Regulation regulation = RemoteObjectManager.instance.regulation;
			int length = Enum.GetValues(typeof(ECommanderVoiceEventType)).Length;
			List<CommanderVoiceDataRow> list = new List<CommanderVoiceDataRow>();
			for (int i = 0; i < length; i++)
			{
				int num = regulation.commanderVoiceDtbl.FindIndex(string.Format("{0}_{1}", id, i));
				if (num >= 0 && regulation.commanderVoiceDtbl[num] != null)
				{
					list.Add(regulation.commanderVoiceDtbl[num]);
				}
			}
			return list;
		}

		public static readonly string resourceIdFormat = "Commander-{0:0000}";

		private CommanderVoiceDataRow[] _voiceEvents;

		protected string _nickName;
	}
}
