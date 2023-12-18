using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CommanderCSLibrary.Shared.Regulation
{
    public class BattleTimeDataRow : DataRow
    {
        public int category { get; private set; }
        public int type { get; private set; }
        public int typeIndex { get; private set; }
        public string startDate { get; private set; }
        public string startTime { get; private set; }
        public string endDate { get; private set; }
        public string endTime { get; private set; }
        public string weekIdx { get; private set; }
        private BattleTimeDataRow()
        {
        }

        public string GetKey()
        {
            return category.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}