using MongoDB.Driver;
using StellarGK.Database.Models;
using StellarGK.Host;
using StellarGK.Utils;

namespace StellarGK.Database.Handlers
{
    public class DatabaseAccount : DatabaseTable<AccountScheme>
    {
        public DatabaseAccount() : base("Account") { }

        // TODO add resetRemain 

        public AccountScheme Create(string name, string password, int platformid, int channel)
        {
            AccountScheme? tryUser = collection.AsQueryable().Where(d => d.name == name).FirstOrDefault();
            if (tryUser != null) { return tryUser; }

            int memberId = DatabaseManager.AutoIncrements.GetNextNumber("UID", 1000);

            AccountScheme user = new()
            {
                name = name,
                Id = memberId,
                server = 1,
                token = Guid.NewGuid().ToString(),
                password = Crypto.ComputeSha256Hash(password),
                platformId = platformid,
                channel = channel,
                // result.worldState != -1;
                // if exploration is finished id assume
                worldState = 1,
                uno = memberId.ToString(),
                creationTime = Constants.CurrentTimeStamp,
                lastLoginTime = Constants.CurrentTimeStamp,
                isBanned = false,
                banReason = "",
                PermissionLevel = 0,
                guildId = null,
                lastStage = 0,
            };

            collection.InsertOne(user);

            return user;
        }
        public AccountScheme CreateGuest(int platformid, int channel)
        {
            string name = Constants.CreateGuestName;
            AccountScheme? tryUser = collection.AsQueryable().Where(d => d.name == name).FirstOrDefault();
            if (tryUser != null) { return tryUser; }

            int memberId = DatabaseManager.AutoIncrements.GetNextNumber("UID", 1000);

            AccountScheme user = new()
            {
                name = name,
                Id = memberId,
                server = 1,
                token = Guid.NewGuid().ToString(),
                platformId = platformid,
                channel = channel,
                // result.worldState != -1;
                // if exploration is finished id assume
                worldState = 1,
                uno = memberId.ToString(),
                creationTime = Constants.CurrentTimeStamp,
                lastLoginTime = Constants.CurrentTimeStamp,
                isBanned = false,
                banReason = "",
                PermissionLevel = 0,
                guildId = null,
                lastStage = 0,
            };

            collection.InsertOne(user);

            return user;
        }


        public AccountScheme FindByName(string accountName)
        {
            AccountScheme? user = collection.AsQueryable().Where(d => d.name == accountName).FirstOrDefault();
            return user;
        }
        public AccountScheme FindByPassword(string password)
        {
            password = Crypto.ComputeSha256Hash(password);

            AccountScheme? user = collection.AsQueryable().Where(d => d.password == password).FirstOrDefault();
            return user;
        }
        public AccountScheme? FindByToken(string token)
        {
            AccountScheme? user = collection.AsQueryable().Where(d => d.token == token).FirstOrDefault();
            return user;
        }
        public AccountScheme? FindByUid(int memberId)
        {
            AccountScheme? user = collection.AsQueryable().Where(d => d.Id == memberId).FirstOrDefault();
            return user;
        }
        public AccountScheme? FindBySession(string session)
        {
            AccountScheme? user = collection.AsQueryable().Where(d => d.session == session).FirstOrDefault();

            return user;
        }

        public bool AccountExists(string accountName)
        {
            return collection.AsQueryable().Where(d => d.name == accountName).Count() > 0;
        }


        public void UpdateUponLogin(int memberId, string device, string deviceId, int patchType, int osCode, string osVersion, string gameVersion, string apk, string pushRegistrationId, string language, string countryName, string gpid, int channel, string session)
        {
            var filter = Builders<AccountScheme>.Filter.Eq("Id", memberId);

            var update = Builders<AccountScheme>.Update.Set("device", device).Set("gameversion", gameVersion).Set("deviceid", deviceId).Set("patchType", patchType).Set("osCode", osCode).Set("osversion", osVersion).Set("apk", apk).Set("pushRegistrationId", pushRegistrationId).Set("language", language).Set("country", countryName).Set("gpid", gpid).Set("channel", channel).Set("session", session);

            collection.UpdateOne(filter, update);
        }
        public void UpdateLoginTime(int memberId)
        {
            var filter = Builders<AccountScheme>.Filter.Eq("Id", memberId);

            var update = Builders<AccountScheme>.Update.Set("lastLoginTime", Constants.CurrentTimeStamp);

            collection.UpdateOne(filter, update);
        }
        public void UpdateStep(int memberId, int tutorialStep)
        {
            var filter = Builders<AccountScheme>.Filter.Eq("Id", memberId);

            var update = Builders<AccountScheme>.Update.Set("step", tutorialStep);

            collection.UpdateOne(filter, update);
        }
        public void UpdateStepAndSkip(int memberId, int tutorialStep, bool skip)
        {
            var filter = Builders<AccountScheme>.Filter.Eq("Id", memberId);

            var update = Builders<AccountScheme>.Update.Set("step", tutorialStep).Set("skip", skip);

            collection.UpdateOne(filter, update);
        }

        public ErrorCode ChangeMemberShip(string oldName, string password, int platformId, string newName, int channel)
        {

            if (Misc.NameCheck(oldName))
            {
                return ErrorCode.InappropriateWords;
            }

            if (AccountExists(oldName))
            {
                return ErrorCode.IdAlreadyExists;
            }
            else
            {
                var account = FindByName(newName);

                var filter = Builders<AccountScheme>.Filter.Eq("Id", account.Id);
                var update = Builders<AccountScheme>.Update.Set("name", oldName).Set("password", Crypto.ComputeSha256Hash(password)).Set("platformId", platformId).Set("channel", channel);

                collection.UpdateOne(filter, update);

                return ErrorCode.Success;
            }
        }

    }
}
