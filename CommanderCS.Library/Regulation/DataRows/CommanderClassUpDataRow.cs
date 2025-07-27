using CommanderCS.Library.Regulation;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    public class CommanderClassUpDataRow : DataRow
    {
        public string GRADE { get; set; }
        public int UPGRADE_COST { get; set; }
        public string ROLE { get; set; }
        public string CPU_ID { get; set; }
        public int CPU_AMOUNT { get; set; }
        public string ATK_ID { get; set; }
        public int ATK_AMOUNT { get; set; }
        public string DEF_ID { get; set; }
        public int DEF_AMOUNT { get; set; }
        public string SUP_ID { get; set; }
        public int SUP_AMOUNT { get; set; }
        public string MOTORBLOCK_ID { get; set; }
        public int MOTORBLOCK_ID_AMOUNT { get; set; }
        public string PLATE_ID { get; set; }
        public int PLATE_AMOUNT { get; set; }

        private CommanderClassUpDataRow()
        {
        }

        public string GetKey()
        {
            return GRADE;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}