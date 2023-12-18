using CommanderCSLibrary.Shared.Enum;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation
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
