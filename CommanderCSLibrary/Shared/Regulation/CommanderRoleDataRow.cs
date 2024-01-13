using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommanderCSLibrary.Shared.Regulation
{
    public class CommanderRoleDataRow : DataRow
    {
        public int commanderId { get; private set; }
        public string commanderRole { get; private set; }

        private CommanderRoleDataRow()
        {
        }
        public string GetKey()
        {
            return commanderId.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}
