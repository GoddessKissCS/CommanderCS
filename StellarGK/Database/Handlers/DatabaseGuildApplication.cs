using MongoDB.Driver;
using StellarGK.Database.Schemes;

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
                GuildId = guildIdx,
                Uno = user.Uno,
            };

            Collection.InsertOne(guildApplication);
        }


        public string RetrieveGuildApplication(string session, int guildIdx)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            if (user == null) { return string.Empty; }

            var tryGuild = Collection.AsQueryable()
                            .Where(d => d.Uno == user.Uno)
                            .Where(d => d.GuildId == guildIdx)
                            .FirstOrDefault();

            if (tryGuild != null) {  return "reg";  }

            return string.Empty;

        }

        public bool DeleteGuildApplication(string session, int guildIdx)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            if (user == null) { }

            var filter = Builders<GuildApplicationScheme>.Filter.And(Builders<GuildApplicationScheme>.Filter.Eq("uno", user.Uno),
                         Builders<GuildApplicationScheme>.Filter.Eq("guildId", guildIdx));

            var result = Collection.DeleteOne(filter);

            return result.DeletedCount > 0;
        }
    }
}