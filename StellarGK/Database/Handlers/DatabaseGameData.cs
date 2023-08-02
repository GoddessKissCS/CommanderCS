using MongoDB.Driver;
using StellarGK.Database.Models;
using StellarGK.Logic.ExcelReader;
using StellarGK.Logic.Protocols;

namespace StellarGK.Database.Handlers
{
    public class DatabaseGameData : DatabaseTable<GameDataScheme>
    {

        public DatabaseGameData() : base("GameData") { }

        public GameDataScheme Create(int mIdx)
        {
            GameDataScheme? tryUser = collection.AsQueryable().Where(d => d.Id == mIdx).FirstOrDefault();
            if (tryUser != null) { return tryUser; }

            GameDataScheme user = new()
            {
                Id = mIdx,
                stages = WorldMapStageData.GetInstance().GetStages(),
                medalData = new()
                {
                    {"1", 10}
                },
                eventResourceData = new()
                {

                },
                foodData = new()
                {

                },
                groupItemData = new()
                {

                },
                ItemData = new()
                {

                },
                partData = new()
                {

                },
                commanderData = new()
                {

                },
                sweepClearData = new()
                {

                },
                completeRewardGroupIdx = new()
                {

                },
                donHaveCommCostumeData = new()
                {

                },
                equipItem = new()
                {

                },
                preDeck = new()
                {

                },
                weaponList = new()
                {

                },
                dispatchedCommanders = new()
                {

                }
            };

            collection.InsertOne(user);

            return user;
        }


        public GameDataScheme? FindByNickname(string name)
        {
            AccountScheme? user = DatabaseAccount.collection.AsQueryable().Where(d => d.name == name).FirstOrDefault();

            var battleinfo = FindByUid(user.Id);

            return battleinfo;
        }
        public GameDataScheme? FindByToken(string token)
        {
            AccountScheme? user = DatabaseAccount.collection.AsQueryable().Where(d => d.token == token).FirstOrDefault();
            var battleinfo = FindByUid(user.Id);

            return battleinfo;
        }
        public GameDataScheme? FindByUid(int uid)
        {
            GameDataScheme? user = collection.AsQueryable().Where(d => d.Id == uid).FirstOrDefault();
            return user;
        }
        public GameDataScheme? FindBySession(string session)
        {
            AccountScheme? user = DatabaseAccount.collection.AsQueryable().Where(d => d.session == session).FirstOrDefault();
            var battleinfo = FindByUid(user.Id);

            return battleinfo;
        }



        public void UpdateMedalData(int mIdx, Dictionary<string, int> dictionary)
        {
            var filter = Builders<GameDataScheme>.Filter.Eq(x => x.Id, mIdx);
            var update = Builders<GameDataScheme>.Update.Set(x => x.medalData, dictionary);

            collection.UpdateOne(filter, update);
        }
        public void UpdateMedalData(string session, Dictionary<string, int> dictionary)
        {
            var user = FindBySession(session);

            var filter = Builders<GameDataScheme>.Filter.Eq(x => x.Id, user.Id);
            var update = Builders<GameDataScheme>.Update.Set(x => x.medalData, dictionary);

            collection.UpdateOne(filter, update);
        }
        public void UpdateCommanderData(int mIdx, Dictionary<string, UserInformationResponse.Commander> newCommanderData)
        {
            var filter = Builders<GameDataScheme>.Filter.Eq(x => x.Id, mIdx);
            var update = Builders<GameDataScheme>.Update.Set(x => x.commanderData, newCommanderData);

            collection.UpdateOne(filter, update);
        }
        public void UpdateCommanderData(string session, Dictionary<string, UserInformationResponse.Commander> newCommanderData)
        {
            AccountScheme? user = DatabaseAccount.collection.AsQueryable().Where(d => d.session == session).FirstOrDefault();

            var filter = Builders<GameDataScheme>.Filter.Eq(x => x.Id, user.Id);
            var update = Builders<GameDataScheme>.Update.Set(x => x.commanderData, newCommanderData);

            collection.UpdateOne(filter, update);
        }
        public void UpdateItemData(int mIdx, Dictionary<string, int> goods)
        {
            var filter = Builders<GameDataScheme>.Filter.Eq(x => x.Id, mIdx);
            var update = Builders<GameDataScheme>.Update.Set(x => x.ItemData, goods);

            collection.UpdateOne(filter, update);
        }




    }
}
