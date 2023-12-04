using CommanderCS.Database.Schemes;
using CommanderCS.Enum;
using CommanderCS.Host;
using CommanderCS.Host.Handlers.Login;
using CommanderCS.Packets.Handlers.UserTerm;
using CommanderCS.Utils;
using CommanderCSLibrary.Utils;
using MongoDB.Driver;
using static CommanderCS.Cryptography.Crypto;

namespace CommanderCS.Database.Handlers
{
    public class DatabaseAccount : DatabaseTable<AccountScheme>
    {
        public DatabaseAccount() : base("Account")
        {
        }

        public AccountScheme Create(string name = "", string password = "", int platformid = 0, int channel = 0)
        {
            AccountScheme existingUser = DatabaseCollection.AsQueryable().Where(d => d.Name == name).FirstOrDefault();

            if (existingUser != null)
            {
                return existingUser;
            }

            int memberId = DatabaseManager.AutoIncrements.GetNextNumber("MemberId");

            var CurrTimeStamp = TimeManager.CurrentEpoch;

            AccountScheme user = new()
            {
                MemberId = memberId,
                Token = Guid.NewGuid().ToString(),
                Channel = channel,
                CreationTime = CurrTimeStamp,
                LastLoginTime = CurrTimeStamp,
                isBanned = false,
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

            DatabaseCollection.InsertOne(user);

            return user;
        }

        public AccountScheme FindByName(string accountName)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.Name == accountName).FirstOrDefault();
        }

        public AccountScheme? FindByUid(int memberId)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.MemberId == memberId).FirstOrDefault();
        }

        public bool AccountExists(string accountName)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.Name == accountName).Any();
        }

        public AccountScheme? FindBySession(string session)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            return FindByUid(user.MemberId);
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

            DatabaseCollection.UpdateOne(filter, update);

            return ErrorCode.Success;
        }

        public void ChangeMemberShipOpenPlatform(string guestname, int platformId, string token, int channel)
        {
            var filter = Builders<AccountScheme>.Filter.Eq("Name", guestname) & Builders<AccountScheme>.Filter.Eq("Token", token);
            var update = Builders<AccountScheme>.Update.Set("PlatformId", platformId).Set("Channel", channel);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateLoginTime(int id)
        {
            var CurrTimeStamp = TimeManager.CurrentEpoch;

            var filter = Builders<AccountScheme>.Filter.Eq("MemberId", id);
            var update = Builders<AccountScheme>.Update.Set("LastLoginTime", CurrTimeStamp);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateLoginTime(string name)
        {
            var account = FindByName(name);

            var CurrTimeStamp = TimeManager.CurrentEpoch;

            var filter = Builders<AccountScheme>.Filter.Eq("MemberId", account.MemberId);
            var update = Builders<AccountScheme>.Update.Set("LastLoginTime", CurrTimeStamp);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateLastServerLoggedIn(int server, int memberid)
        {
            var filter = Builders<AccountScheme>.Filter.Eq("MemberId", memberid);
            var update = Builders<AccountScheme>.Update.Set("LastServerLoggedIn", server);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public ErrorCode RequestLogin(LoginRequest @params, string session)
        {
            var user = FindByUid(@params.memberId);

            if (user.isBanned == true && user.isBanned != null)
            {
                return ErrorCode.BannedOrSuspended;
            }

            //var timeDifference = TimeManager.GetTimeDifferenceInMinutes(user.LastLoginTime);

            //if(timeDifference < 3)
            //{
            //    return ErrorCode.UnableToJoin;
            //}

            DatabaseManager.GameProfile.UpdateOnLogin(@params, session);
            return ErrorCode.Success;
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

            var options = new FindOneAndUpdateOptions<AccountScheme>
            {
                ReturnDocument = ReturnDocument.After,
                IsUpsert = false
            };

            var updatedAccount = DatabaseCollection.FindOneAndUpdate(filter, update, options);

            return updatedAccount;
        }
    }
}