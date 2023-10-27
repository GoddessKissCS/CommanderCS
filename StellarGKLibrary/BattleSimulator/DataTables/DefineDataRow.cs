using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.DataTables
{
    [JsonObject]
    [Serializable]
    public class DefineDataRow : DataRow
    {
        public string key { get; private set; }

        public string value { get; private set; }

        public string GetKey()
        {
            return key;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}
