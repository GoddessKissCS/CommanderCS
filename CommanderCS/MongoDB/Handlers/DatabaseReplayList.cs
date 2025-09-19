using CommanderCS.Library.Enums;
using CommanderCS.MongoDB.Schemes;
using System.Buffers.Text;
using System.Security.Cryptography.X509Certificates;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for storing replay list data.
    /// </summary>
    public class DatabaseReplayList : DatabaseTable<ReplayScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseReplayList"/> class with the specified table name.
        /// </summary>
        public DatabaseReplayList() : base("ReplayList")
        {
            
        }

        public ReplayScheme Insert(int uno, int memberId, string ClientReplay, string ServerReplay, EBattleType type)
        {
            int replayId = DatabaseManager.AutoIncrements.GetNextNumber("ReplayId");
            
            ReplayScheme replay = new()
            {
                ReplayId = replayId,
                ReplayClientData = ClientReplay,
                ReplayServerData = ServerReplay,
                BattleType = type,
                Uno = uno,
                MemberId = memberId,
                
            };


            DatabaseCollection.InsertOne(replay);

            return replay;
        }

    }
}