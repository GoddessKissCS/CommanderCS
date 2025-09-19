using CommanderCS.Library.Enums;
using MongoDB.Bson;

namespace CommanderCS.MongoDB.Schemes
{
    public class ReplayScheme
    {
        public ObjectId Id { get; set; }
        public int ReplayId { get; set; }
        public string ReplayClientData { get; set; }
        public string ReplayServerData { get; set; }
        public EBattleType BattleType { get; set; }
        public int Uno { get; set; }
        public int MemberId { get; set; }
    }
}
