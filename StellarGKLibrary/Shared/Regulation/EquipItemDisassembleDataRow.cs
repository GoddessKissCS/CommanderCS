using StellarGKLibrary.Enums;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class EquipItemDisassembleDataRow : DataRow
	{
		public EItemStatType disassembleType { get; set; }

		public int level { get; set; }

		public string disassembleMaterial1 { get; set; }

		public int return1 { get; set; }

		public string disassembleMaterial2 { get; set; }

		public int return2 { get; set; }

		public string disassembleMaterial3 { get; set; }

		public int return3 { get; set; }

		public string disassembleMaterial4 { get; set; }

		public int return4 { get; set; }

		public string disassembleMaterial5 { get; set; }

		public int return5 { get; set; }

		public string needGoodsIdx { get; set; }

		public int goodsIdxVolume { get; set; }

		public string sellGoodsIdx { get; set; }

		public int sellGoodsIdxVolume { get; set; }

		public string GetKey()
		{
			return disassembleType + level.ToString();
		}
	}
}
