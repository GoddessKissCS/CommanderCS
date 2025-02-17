using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation.DataRows
{
    public class CommanderRoleDataRow : DataRow
    {
        public int Id { get; private set; }
        public string Role { get; private set; }

        private CommanderRoleDataRow()
        {
        }

        public string GetKey()
        {
            return Id.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}