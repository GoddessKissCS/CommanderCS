using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommanderCSLibrary.Shared.Regulation
{
    public class AchievementDataRow : DataRow
    {
        public int index { get; private set; }
        public int idx { get; private set; }
        public int sort { get; private set; }
        public int type { get; private set; }
        public int count { get; private set; }
        public int count1 { get; private set; }
        public int description { get; private set; }
        public string link { get; private set; }
        public string icon { get; private set; }
        public int title { get; private set; }


        private AchievementDataRow()
        {
        }

        public string GetKey()
        {
            return index.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }

    }
}
