using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class EquipItemDisassembleDataRow : DataRow
    {
        public EItemStatType disassembleType { get; private set; }

        public int level { get; private set; }

        public string disassembleMaterial1 { get; private set; }

        public int return1 { get; private set; }

        public string disassembleMaterial2 { get; private set; }

        public int return2 { get; private set; }

        public string disassembleMaterial3 { get; private set; }

        public int return3 { get; private set; }

        public string disassembleMaterial4 { get; private set; }

        public int return4 { get; private set; }

        public string disassembleMaterial5 { get; private set; }

        public int return5 { get; private set; }

        public string needGoodsIdx { get; private set; }

        public int goodsIdxVolume { get; private set; }

        public string sellGoodsIdx { get; private set; }

        public int sellGoodsIdxVolume { get; private set; }

        public string GetKey()
        {
            return string.Concat(disassembleType, level.ToString());
        }
    }
}