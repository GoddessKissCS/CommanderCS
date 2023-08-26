using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGK.Host;
using StellarGK.Host.Handlers.Login;
using StellarGK.Logic.Protocols;
using StellarGK.Tools;

namespace StellarGK.Database.Handlers
{
    public class DatabaseAccount : DatabaseTable<AccountScheme>
    {
        public DatabaseAccount() : base("Account") { }

#warning TODO add resetRemain 

        public AccountScheme Create(string name = "", string password = "", int platformid = 0, int channel = 0)
        {
            AccountScheme? tryUser = Collection.AsQueryable().Where(d => d.Name == name).FirstOrDefault();
            if (tryUser != null) { return tryUser; }

            int memberId = DatabaseManager.AutoIncrements.GetNextNumber("MemberId", 1000);

            AccountScheme user = new()
            {
                MemberId = memberId,
                Token = Guid.NewGuid().ToString(),
                Channel = channel,
                CreationTime = Constants.CurrentTimeStamp,
                LastLoginTime = Constants.CurrentTimeStamp,
                isBanned = null,
                BanReason = null,
                LastServerLoggedIn = 1,
                Platform = (Logic.Enums.Platform)platformid,
            };

            if (platformid == 0)
            {
                string guestName = Constants.CreateGuestName;
                user.Clearance = Clearance.Guest;
                user.Name = guestName;

            }
            else
            {
                user.Name = name;
                user.Password_Hash = Crypto.ComputeSha256Hash(password);
                user.Clearance = Clearance.Player;
            }

            DatabaseManager.Dormitory.Create(memberId);

            Collection.InsertOne(user);

            return user;
        }

        public AccountScheme FindByName(string accountName)
        {
            return Collection.AsQueryable().Where(d => d.Name == accountName).FirstOrDefault();
        }
        public AccountScheme? FindByUid(int memberId)
        {
            return Collection.AsQueryable().Where(d => d.MemberId == memberId).FirstOrDefault();
        }
        public AccountScheme? FindByUid(string memberId)
        {
            return Collection.AsQueryable().Where(d => d.MemberId == int.Parse(memberId)).FirstOrDefault();
        }
        public bool AccountExists(string accountName)
        {
            return Collection.AsQueryable().Where(d => d.Name == accountName).Count() > 0;
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

                var filter = Builders<AccountScheme>.Filter.Eq("Id", account.MemberId);
                var update = Builders<AccountScheme>.Update.Set("name", oldName).Set("password", password_hash).Set("platformId", platformId).Set("channel", channel);

                Collection.UpdateOne(filter, update);

                return ErrorCode.Success;
            }
        }

        public void UpdateLoginTime(int id)
        {
            var filter = Builders<AccountScheme>.Filter.Eq("Id", id);
            var update = Builders<AccountScheme>.Update.Set("LastLoginTime", Constants.CurrentTimeStamp);

            Collection.UpdateOne(filter, update);
        }

        public void UpdateLoginTime(string name)
        {
            var account = FindByName(name);

            var filter = Builders<AccountScheme>.Filter.Eq("Id", account.MemberId);
            var update = Builders<AccountScheme>.Update.Set("LastLoginTime", Constants.CurrentTimeStamp);

            Collection.UpdateOne(filter, update);
        }

        public AccountScheme? FindBySession(string session)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            return FindByUid(user.MemberId);
        }

        public void UpdateLastServerLoggedIn(int server, int memberid)
        {
            var user = FindByUid(memberid);

            var filter = Builders<AccountScheme>.Filter.Eq("Id", memberid);
            var update = Builders<AccountScheme>.Update.Set("LastServerLoggedIn", server);

            Collection.UpdateOne(filter, update);

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

        public bool AddBlockedUser(BlockUser toBeBlocked, string session)
        {

            var user = DatabaseManager.GameProfile.FindBySession(session);
            var filter = Builders<AccountScheme>.Filter.Eq("Id", user.MemberId);
            var update = Builders<AccountScheme>.Update.Push("BlockUsers", toBeBlocked);

            var updateResult = Collection.UpdateOne(filter, update);

            if (updateResult.ModifiedCount > 0)
            {
                return true;
            }
            return false;
        }
        public bool DelBlockedUser(string session, int ch, string uno)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            var filter = Builders<AccountScheme>.Filter.Eq("memberId", user.MemberId);
            var update = Builders<AccountScheme>.Update.PullFilter("BlockedUser",
                         Builders<BlockUser>.Filter.And(
                         Builders<BlockUser>.Filter.Eq("ch", ch),
                         Builders<BlockUser>.Filter.Eq("uno", uno)
                                                             ));

            var updateResult = Collection.UpdateOne(filter, update);

            if (updateResult.ModifiedCount > 0)
            {
                return true;
            }
            return false;
        }

    }
}
