using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class GroupMemberDataRow : DataRow
    {
        public string gidx { get; private set; }

        public string idx { get; private set; }

        public int memberType { get; private set; }

        public int grade { get; private set; }

        public string memberIdx { get; private set; }

        private GroupMemberDataRow()
        {
        }

        public string GetKey()
        {
            return gidx;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}