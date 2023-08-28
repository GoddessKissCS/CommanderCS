using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGK.Host;
using StellarGK.Host.Handlers.Login;
using StellarGK.Logic.Enums;
using StellarGK.Logic.Protocols;
using StellarGK.Tools;
using System.Threading.Channels;
using System;
using StellarGK.Packets.Handlers.UserTerm;
using MongoDB.Driver.Core.Bindings;

namespace StellarGK.Database.Handlers
{
    public class DatabaseAccount : DatabaseTable<AccountScheme>
    {
        public DatabaseAccount() : base("Account") { }
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
                Platform = (Platform)platformid,
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
            return Collection.AsQueryable().Where(d => d.Name == accountName).Any();
        }

        public ErrorCode ChangeMemberShip(string changeName, string password, int platformId, string guestName, int channel)
        {

            if (Misc.NameCheck(changeName))
            {
                return ErrorCode.InappropriateWords;
            }

            if (AccountExists(changeName))
            {
                return ErrorCode.IdAlreadyExists;
            }

            var account = FindByName(guestName);

            var password_hash = Crypto.ComputeSha256Hash(password);

            var filter = Builders<AccountScheme>.Filter.Eq("MemberId", account.MemberId);
            var update = Builders<AccountScheme>.Update.Set("Name", changeName).Set("Password_Hash", password_hash).Set("PlatformId", platformId).Set("Channel", channel);

            Collection.UpdateOne(filter, update);

            return ErrorCode.Success;

        }


        public void UpdateLoginTime(int id)
        {
            var filter = Builders<AccountScheme>.Filter.Eq("MemberId", id);
            var update = Builders<AccountScheme>.Update.Set("LastLoginTime", Constants.CurrentTimeStamp);

            Collection.UpdateOne(filter, update);
        }

        public void UpdateLoginTime(string name)
        {
            var account = FindByName(name);

            var filter = Builders<AccountScheme>.Filter.Eq("MemberId", account.MemberId);
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

            var filter = Builders<AccountScheme>.Filter.Eq("MemberId", memberid);
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

            DatabaseManager.GameProfile.UpdateOnLogin(@params, session);
            return ErrorCode.Success;
        }

        public bool AddBlockedUser(BlockUser toBeBlocked, string session)
        {

            var user = DatabaseManager.GameProfile.FindBySession(session);
            var filter = Builders<AccountScheme>.Filter.Eq("MemberId", user.MemberId);
            var update = Builders<AccountScheme>.Update.Push("BlockUsers", toBeBlocked);

            var updateResult = Collection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }
        public bool DelBlockedUser(string session, int ch, string uno)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            var filter = Builders<AccountScheme>.Filter.Eq("MemberId", user.MemberId);
            var update = Builders<AccountScheme>.Update.PullFilter("BlockedUser",
                         Builders<BlockUser>.Filter.And(
                         Builders<BlockUser>.Filter.Eq("ch", ch),
                         Builders<BlockUser>.Filter.Eq("uno", uno)
                                                             ));

            var updateResult = Collection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }


        public ErrorCode ChangeDevice(Platform plfm, string uid, string pwd)
        {
            throw new NotImplementedException();

            /*
            if (Misc.NameCheck(uid))
            {
                return ErrorCode.InappropriateWords;
            }

            if (AccountExists(changeName))
            {
                return ErrorCode.IdAlreadyExists;
            }
            else
            {
                var account = FindByName(guestName);

                var password_hash = Crypto.ComputeSha256Hash(password);

                var filter = Builders<AccountScheme>.Filter.Eq("MemberId", account.MemberId);
                var update = Builders<AccountScheme>.Update.Set("Name", changeName).Set("Password_Hash", password_hash).Set("PlatformId", platformId).Set("Channel", channel);
                Collection.UpdateOne(filter, update);
                return ErrorCode.Success;
            }
            */
        }

        public AccountScheme? ChangeDevice(ChangeDeviceRequest @params)
        {
            var account = FindByName(@params.uid);

            var filter = Builders<AccountScheme>.Filter.Eq("MemberId", account.MemberId);
            var update = Builders<AccountScheme>.Update.Set("PlatformId", @params.plfm).Set("Channel", @params.plfm).Set("OsCode", @params.oscd);
            Collection.UpdateOne(filter, update);

            return FindByName(@params.uid);
        }
    }
}
