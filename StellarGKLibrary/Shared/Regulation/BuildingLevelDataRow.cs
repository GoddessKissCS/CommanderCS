using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.Enums;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class BuildingLevelDataRow : DataRow
	{
		public int index { get; set; }

		public EBuilding type { get; set; }

		public string resourceId
		{
			get
			{
				return type.ToString();
			}
		}

		public int level { get; set; }

		public string name { get; set; }

		public int userLevel { get; set; }

		public int vipLevel { get; set; }

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}

		public string GetKey()
		{
			return index.ToString();
		}

		private string _CombineLocalizeKey(string postfix)
		{
			if (postfix == "Name")
			{
				return (type + 1899).ToString();
			}
			return string.Format("Building.{0}.{1}", type, postfix);
		}

		public string locNameKey
		{
			get
			{
				return name;
			}
		}

		public string locInformationMessageKey
		{
			get
			{
				return _CombineLocalizeKey("Information.Message");
			}
		}

		public string locInformationSubMessageKey
		{
			get
			{
				return _CombineLocalizeKey("Information.SubMessage");
			}
		}

		public string locDescriptionKey
		{
			get
			{
				return _CombineLocalizeKey("Description");
			}
		}

		public string locFuctionKey
		{
			get
			{
				return _CombineLocalizeKey("Function");
			}
		}

		public string GetLocalizedDescriptionTitleKey(int idx)
		{
			return string.Format("Building.{0}.Information.Description.{1}.Title", type, idx);
		}

		public string GetLocalizedDescriptionValueKey(int idx)
		{
			return string.Format("Building.{0}.Information.Description.{1}.Value", type, idx);
		}

		public static readonly string ResourceIdFormat = "thum_{0}";
	}
}
