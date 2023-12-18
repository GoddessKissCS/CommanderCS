using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommanderCSLibrary.Shared.Regulation
{
    public class MissionDataRow : DataRow
    {
        public int idx { get; private set; }
        public int level { get; private set; }
        public string startTime { get; private set; }
        public string endTime { get; private set; }
        public int count { get; private set; }
        public int description { get; private set; }
        public string link { get; private set; }
        public string icon { get; private set; }
        public int title { get; private set; }
        public int VipCount { get; private set; }

        private MissionDataRow()
        {
        }

        public string GetKey()
        {
            return idx.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}
