using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGK.Logic.Protocols;

namespace StellarGK.Database.Handlers
{
    public class DatabaseGuildApplication : DatabaseTable<GuildApplicationScheme>
    {
        public DatabaseGuildApplication() : base("GuildApplications") { }

        public void CreateGuildApplication(string session, int guildIdx)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            if (user == null) { return; }

            GuildApplicationScheme guildApplication = new()
            {
                guildId = guildIdx,
                uno = user.uno,
            };

            collection.InsertOne(guildApplication);

        }


        public string RetrieveGuildApplication(string session, int guildIdx)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            if (user == null) { }

            var tryGuild = collection.AsQueryable()
                       .Where(d => d.uno == user.uno)
                       .Where(d => d.guildId == guildIdx)
                       .FirstOrDefault();

            if (tryGuild != null) { return "reg"; }

            return string.Empty; 

        }

        public bool DeleteGuildApplication(string session, int guildIdx)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            if (user == null) { }

            var filter = Builders<GuildApplicationScheme>.Filter.And(Builders<GuildApplicationScheme>.Filter.Eq("uno", user.uno),
                         Builders<GuildApplicationScheme>.Filter.Eq("guildId", guildIdx));

            var result = collection.DeleteOne(filter);

            return result.DeletedCount > 0;
        }
    }
}