using CommanderCS.Host;
using CommanderCS.Host.Handlers.Login;
using CommanderCS.MongoDB.Schemes;
using CommanderCS.Packets.Handlers.UserTerm;
using CommanderCSLibrary.Cryptography;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Enum;
using MongoDB.Driver;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for accounts.
    /// </summary>
    public class DatabaseAccount : DatabaseTable<AccountScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseAccount"/> class.
        /// </summary>
        public DatabaseAccount() : base("Account")
        {
        }

        /// <summary>
        /// Creates a new account with the provided details or retrieves an existing account if the name already exists.
        /// </summary>
        /// <param name="name">The name of the account.</param>
        /// <param name="password">The password for the account.</param>
        /// <param name="platformid">The platform ID of the account.</param>
        /// <param name="channel">The channel ID of the account.</param>
        /// <returns>The created or existing account.</returns>
        public AccountScheme GetOrCreate(string name = "", string password = "", int platformid = 0, int channel = 0)
        {
            AccountScheme existingUser = DatabaseCollection.AsQueryable().Where(d => d.Name == name).FirstOrDefault();

            if (existingUser is not null)
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
                user.Password_Hash = Crypto.ComputeSha256Hash(password);
                user.Clearance = Clearance.Player;
            }

            DatabaseCollection.InsertOne(user);

            return user;
        }

        /// <summary>
        /// Finds an account by its name.
        /// </summary>
        /// <param name="accountName">The name of the account to find.</param>
        /// <returns>The account with the specified name, or null if not found.</returns>
        public AccountScheme? FindByName(string accountName)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.Name == accountName).FirstOrDefault();
        }

        /// <summary>
        /// Finds an account by its unique identifier.
        /// </summary>
        /// <param name="memberId">The unique identifier of the account to find.</param>
        /// <returns>The account with the specified unique identifier, or null if not found.</returns>
        public AccountScheme? FindByUid(int memberId)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.MemberId == memberId).FirstOrDefault();
        }

        /// <summary>
        /// Checks if an account with the specified name exists.
        /// </summary>
        /// <param name="accountName">The name of the account to check.</param>
        /// <returns>True if an account with the specified name exists, otherwise false.</returns>
        public bool AccountExists(string accountName)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.Name == accountName).Any();
        }

        /// <summary>
        /// Finds an account associated with the specified session.
        /// </summary>
        /// <param name="session">The session associated with the account.</param>
        /// <returns>The account associated with the session, or null if not found.</returns>
        public AccountScheme? FindBySession(string session)
        {
            GameProfileScheme? user = DatabaseManager.GameProfile.FindBySession(session);

            var account = FindByUid(user.MemberId);

            return account;
        }

        /// <summary>
        /// Changes the membership details of an account.
        /// </summary>
        /// <param name="changeName">The new name for the account.</param>
        /// <param name="password">The new password for the account.</param>
        /// <param name="platformId">The new platform ID for the account.</param>
        /// <param name="guestName">The current guest name of the account.</param>
        /// <param name="channel">The new channel for the account.</param>
        /// <returns>The error code indicating the result of the operation.</returns>
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

            DatabaseCollection.UpdateOne(filter, update);

            return ErrorCode.Success;
        }

        /// <summary>
        /// Changes the membership details of an open platform account.
        /// </summary>
        /// <param name="guestname">The current guest name of the account.</param>
        /// <param name="platformId">The new platform ID for the account.</param>
        /// <param name="token">The token associated with the account.</param>
        /// <param name="channel">The new channel for the account.</param>
        public void ChangeMemberShipOpenPlatform(string guestname, int platformId, string token, int channel)
        {
            var filter = Builders<AccountScheme>.Filter.Eq("Name", guestname) & Builders<AccountScheme>.Filter.Eq("Token", token);
            var update = Builders<AccountScheme>.Update.Set("PlatformId", platformId).Set("Channel", channel);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the last login time of the account with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the account.</param>
        public void UpdateLoginTime(int id)
        {
            var CurrTimeStamp = TimeManager.CurrentEpoch;

            var filter = Builders<AccountScheme>.Filter.Eq("MemberId", id);
            var update = Builders<AccountScheme>.Update.Set("LastLoginTime", CurrTimeStamp);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the last server logged in for the account with the specified member ID.
        /// </summary>
        /// <param name="server">The ID of the server where the account last logged in.</param>
        /// <param name="memberid">The ID of the account.</param>
        public void UpdateLastServerLoggedIn(int server, int memberid)
        {
            var filter = Builders<AccountScheme>.Filter.Eq("MemberId", memberid);
            var update = Builders<AccountScheme>.Update.Set("LastServerLoggedIn", server);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Processes a login request, updates necessary data, and returns an error code indicating the result.
        /// </summary>
        /// <param name="params">The login request parameters.</param>
        /// <param name="session">The session associated with the login request.</param>
        /// <returns>The error code indicating the result of the login request.</returns>
        public ErrorCode RequestLogin(LoginRequest @params, string session)
        {
            var user = FindByUid(@params.memberId);

            if (user.isBanned == true && user.isBanned is not null)
            {
                return ErrorCode.BannedOrSuspended;
            }

            //var timeDifference = TimeManager.GetTimeDifferenceInMinutes(user.LastLoginTime);

            //if(timeDifference < 3)
            //{
            //    return ErrorCode.UnableToJoin;
            //}

            DatabaseManager.GameProfile.UpdateOnLogin(@params, session);

            UpdateLastServerLoggedIn(@params.world, @params.memberId);

            return ErrorCode.Success;
        }

        /// <summary>
        /// Changes the device associated with the account.
        /// </summary>
        /// <param name="plfm">The new platform for the device.</param>
        /// <param name="uid">The unique identifier of the device.</param>
        /// <param name="pwd">The password for the device.</param>
        /// <returns>The error code indicating the result of the device change operation.</returns>
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

        /// <summary>
        /// Changes the device details associated with the account.
        /// </summary>
        /// <param name="params">The parameters for changing the device.</param>
        /// <returns>The updated account after changing the device details, or null if the account is not found.</returns>
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