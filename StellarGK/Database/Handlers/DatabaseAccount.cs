using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGK.Host;
using StellarGK.Host.Handlers.Login;
using StellarGK.Packets.Handlers.UserTerm;
using StellarGKLibrary.Enum;
using StellarGKLibrary.Utils;
using static StellarGKLibrary.Cryptography.Crypto;

namespace StellarGK.Database.Handlers
{
    public class DatabaseAccount : DatabaseTable<AccountScheme>
    {
        public DatabaseAccount() : base("Account")
        {
        }

        public AccountScheme Create(string name = "", string password = "", int platformid = 0, int channel = 0)
        {
            AccountScheme? tryUser = Collection.AsQueryable().Where(d => d.Name == name).FirstOrDefault();
            if (tryUser != null) { return tryUser; }

            int memberId = DatabaseManager.AutoIncrements.GetNextNumber("MemberId", 1000);

            var CurrTimeStamp = Utility.CurrentTimeStamp();

            AccountScheme user = new()
            {
                MemberId = memberId,
                Token = Guid.NewGuid().ToString(),
                Channel = channel,
                CreationTime = CurrTimeStamp,
                LastLoginTime = CurrTimeStamp,
                isBanned = null,
                BanReason = null,
                LastServerLoggedIn = 1,
                Platform = (Platform)platformid,
            };

            if (platformid == 0)
            {
                user.Clearance = Clearance.Guest;
                user.Name = Utility.CreateGuestName();
            }
            else
            {
                user.Name = name;
                user.Password_Hash = ComputeSha256Hash(password);
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

            var password_hash = ComputeSha256Hash(password);

            var filter = Builders<AccountScheme>.Filter.Eq("MemberId", account.MemberId);
            var update = Builders<AccountScheme>.Update.Set("Name", changeName).Set("Password_Hash", password_hash).Set("PlatformId", platformId).Set("Channel", channel);

            Collection.UpdateOne(filter, update);

            return ErrorCode.Success;
        }

        public void UpdateLoginTime(int id)
        {
            var CurrTimeStamp = Utility.CurrentTimeStamp();

            var filter = Builders<AccountScheme>.Filter.Eq("MemberId", id);
            var update = Builders<AccountScheme>.Update.Set("LastLoginTime", CurrTimeStamp);

            Collection.UpdateOne(filter, update);
        }

        public void UpdateLoginTime(string name)
        {
            var account = FindByName(name);

            var CurrTimeStamp = Utility.CurrentTimeStamp();

            var filter = Builders<AccountScheme>.Filter.Eq("MemberId", account.MemberId);
            var update = Builders<AccountScheme>.Update.Set("LastLoginTime", CurrTimeStamp);

            Collection.UpdateOne(filter, update);
        }

        public AccountScheme? FindBySession(string session)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            return FindByUid(user.MemberId);
        }

        public void UpdateLastServerLoggedIn(int server, int memberid)
        {
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

        //public bool addblockeduser(blockuser tobeblocked, string session)
        //{
        //    var user = databasemanager.gameprofile.findbysession(session);
        //    var filter = builders<accountscheme>.filter.eq("memberid", user.memberid);
        //    var update = builders<accountscheme>.update.push("blockusers", tobeblocked);

        //    var updateresult = collection.updateone(filter, update);

        //    return updateresult.modifiedcount > 0;
        //}
        //public bool delblockeduser(string session, int ch, string uno)
        //{
        //    var user = databasemanager.gameprofile.findbysession(session);

        //    var filter = builders<accountscheme>.filter.eq("memberid", user.memberid) &
        //                 builders<accountscheme>.filter.elemmatch(x => x.blockedusers,
        //                 builders<blockuser>.filter.eq("ch", ch) & builders<blockuser>.filter.eq("uno", uno));

        //    var updateresult = collection.deleteone(filter);

        //    return updateresult.deletedcount > 0;
        //}

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