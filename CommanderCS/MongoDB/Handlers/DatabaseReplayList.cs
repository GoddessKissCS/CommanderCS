using CommanderCS.Library.Enums;
using CommanderCS.MongoDB.Schemes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

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

        public List<ReplayScheme> FindByUno(int uno)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.Uno == uno).ToList();
        }

        public List<ReplayScheme> FindByUnoAndType(int uno, EBattleType type)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.Uno == uno && d.BattleType == type).ToList();
        }

        public List<ReplayScheme> FindByType(EBattleType type)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.BattleType == type).ToList();
        }

        public ReplayScheme FindByReplayId(int replayId)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.ReplayId == replayId).FirstOrDefault();
        }

    }
}