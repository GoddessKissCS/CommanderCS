using System.Threading.Channels;
using System;
using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGK.Host;
using StellarGK.Tools;
using StellarGK.Host.Handlers.Login;

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

            int memberId = DatabaseManager.AutoIncrements.GetNextNumber("MemberId", 1000);

            AccountScheme user = new()
            {
                name = name,
                memberId = memberId,              
                token = Guid.NewGuid().ToString(),
                password = Crypto.ComputeSha256Hash(password),
                channel = channel,
                creationTime = Constants.CurrentTimeStamp,
                lastLoginTime = Constants.CurrentTimeStamp,
                isBanned = null,
                banReason = null,
                blockedUsers = new() { },
                clearance = Clearance.Player,
                lastServerLoggedIn = 1,
            };

            DatabaseManager.Dormitory.Create(memberId);

            collection.InsertOne(user);

            return user;
        }
        public AccountScheme CreateGuest(int platformid, int channel)
        {
            string name = Constants.CreateGuestName;
            AccountScheme? tryUser = collection.AsQueryable().Where(d => d.name == name).FirstOrDefault();
            if (tryUser != null) { return tryUser; }

            int memberId = DatabaseManager.AutoIncrements.GetNextNumber("MemberId", 1000);

            AccountScheme user = new()
            {
                name = name,
                memberId = memberId,
                token = Guid.NewGuid().ToString(),
                channel = channel,
                creationTime = Constants.CurrentTimeStamp,
                lastLoginTime = Constants.CurrentTimeStamp,
                isBanned = null,
                banReason = null,
                blockedUsers = new() { },
                clearance = Clearance.Guest,
                lastServerLoggedIn = 1,
            };

            collection.InsertOne(user);

            DatabaseManager.Dormitory.Create(memberId);

            return user;
        }

        public AccountScheme FindByName(string accountName)
        {
            AccountScheme? user = collection.AsQueryable().Where(d => d.name == accountName).FirstOrDefault();
            return user;
        }
        public AccountScheme? FindByUid(int memberId)
        {
            AccountScheme? user = collection.AsQueryable().Where(d => d.memberId == memberId).FirstOrDefault();
            return user;
        }
        public AccountScheme? FindByUid(string memberId)
        {
            AccountScheme? user = collection.AsQueryable().Where(d => d.memberId == int.Parse(memberId)).FirstOrDefault();
            return user;
        }
        public bool AccountExists(string accountName)
        {
            return collection.AsQueryable().Where(d => d.name == accountName).Count() > 0;
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

                var password_hash = Crypto.ComputeSha256Hash(password);

                var filter = Builders<AccountScheme>.Filter.Eq("Id", account.memberId);
                var update = Builders<AccountScheme>.Update.Set("name", oldName).Set("password", password_hash).Set("platformId", platformId).Set("channel", channel);

                collection.UpdateOne(filter, update);

                return ErrorCode.Success;
            }
        }

        public void UpdateLoginTime(int id)
        {
            var filter = Builders<AccountScheme>.Filter.Eq("Id", id);
            var update = Builders<AccountScheme>.Update.Set("lastLoginTime", Constants.CurrentTimeStamp);

            collection.UpdateOne(filter, update);

        }

        public void UpdateLoginTime(string name)
        {
            var account = FindByName(name);

            var filter = Builders<AccountScheme>.Filter.Eq("Id", account.memberId);
            var update = Builders<AccountScheme>.Update.Set("lastLoginTime", Constants.CurrentTimeStamp);

            collection.UpdateOne(filter, update);

        }

        public AccountScheme? FindBySession(string session)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            return FindByUid(user.memberId);
        }

        public void UpdateLastServerLoggedIn(int server, int memberid)
        {
            var user = FindByUid(memberid);

            var filter = Builders<AccountScheme>.Filter.Eq("Id", memberid);
            var update = Builders<AccountScheme>.Update.Set("lastServerLoggedIn", server);

            collection.UpdateOne(filter, update);

        }

        public ErrorCode RequestLogin(LoginRequest @params, string session)
        {
            var user = FindByUid(@params.memberId);
            if (user.isBanned == true && user.isBanned != null)
            {
                return ErrorCode.BannedOrSuspended;
            }
            else
            {
                DatabaseManager.GameProfile.UpdateOnLogin(@params, session);
                return ErrorCode.Success;
            }
        }

    }
}
