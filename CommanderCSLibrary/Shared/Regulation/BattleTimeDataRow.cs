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
        public int startDate { get; private set; }
        public int startTime { get; private set; }
        public int endDate { get; private set; }
        public int endTime { get; private set; }
        public int weekIdx { get; private set; }
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