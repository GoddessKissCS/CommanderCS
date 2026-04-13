using CommanderCS.MongoDB.Schemes;
using MongoDB.Driver;

namespace CommanderCS.MongoDB.Handlers
{
    public class DatabaseConquestMatching : DatabaseTable<ConquestMatchingScheme>
    {
        public DatabaseConquestMatching() : base("GuildConquestMatching")
        {
        }

        public ConquestMatchingScheme FindByGuildId(int guildId)
        {
            return DatabaseCollection.Find(x => x.GuildId == guildId).FirstOrDefault();
        }

        public void AddGuildToPool(GuildScheme guild)
        {
            ConquestMatchingScheme existing = FindByGuildId(guild.GuildId);

            if (existing != null)
            {
                return;
            }

            ConquestMatchingScheme scheme = new()
            {
                GuildId = guild.GuildId,
                Level = guild.Level,
                Count = guild.Count,
                World = guild.World,
                Emblem = guild.Emblem,
                Name = guild.Name,
            };

            DatabaseCollection.InsertOne(scheme);
        }

        public void RemoveGuildFromPool(int guildId)
        {
            DatabaseCollection.DeleteOne(x => x.GuildId == guildId);
        }

        public ConquestMatchingScheme FindMatch(int guildId)
        {
            return DatabaseCollection.Find(x => x.GuildId != guildId).FirstOrDefault();
        }
    }
}
