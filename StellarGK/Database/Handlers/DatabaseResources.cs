using MongoDB.Driver;
using StellarGK.Database.Models;
using StellarGK.Logic.ExcelReader;
using StellarGK.Logic.Protocols;

namespace StellarGK.Database.Handlers
{
    public class DatabaseResources : DatabaseTable<ResourcesScheme>
    {
        public DatabaseResources() : base("Resources") { }

        public ResourcesScheme Create(int mIdx)
        {
            ResourcesScheme? tryUser = collection.AsQueryable().Where(d => d.Id == mIdx).FirstOrDefault();
            if (tryUser != null) { return tryUser; }

            ResourcesScheme user = new()
            {
                Id = mIdx,
                nickname = "",
                annCoin = "0",
                blackChallenge = "0",
                blueprintArmy = "0",
                blueprintNavy = "0",
                bullet = "500",
                cash = "500",
                challenge = "0",
                challengeCoin = "0",
                chip = "0",
                commanderGift = "0",
                commanderPromotionPoint = "0",
                eventRaidTicket = "0",
                exp = "0",
                explorationTicket = "0",
                gold = "100000",
                guildCoin = "0",
                level = "1",
                oil = "0",
                opcon = "0",
                opener = "0",
                raidCoin = "0",
                honor = "0",
                ring = "0",
                sweepTicket = "0",
                thumbnailId = "1001",
                vipExp = "0",
                vipLevel = "0",
                waveDuelCoin = "0",
                waveDuelTicket = "0",
                weaponImmediateTicket = "0",
                weaponMakeTicket = "0",
                weaponMaterial1 = "0",
                weaponMaterial2 = "0",
                weaponMaterial3 = "0",
                weaponMaterial4 = "0",
                worldDuelCoin = "0",
                worldDuelTicket = "0",
                worldDuelUpgradeCoin = "0",
            };

            collection.InsertOne(user);

            return user;
        }
        public ResourcesScheme? FindByNickname(string name)
        {
            ResourcesScheme? battleinfo = collection.AsQueryable().Where(d => d.nickname == name).FirstOrDefault();

            return battleinfo;
        }
        public ResourcesScheme? FindByToken(string token)
        {
            AccountScheme? user = DatabaseAccount.collection.AsQueryable().Where(d => d.token == token).FirstOrDefault();
            var battleinfo = FindByUid(user.Id);

            return battleinfo;
        }
        public ResourcesScheme? FindByUid(int uid)
        {
            ResourcesScheme? user = collection.AsQueryable().Where(d => d.Id == uid).FirstOrDefault();
            return user;
        }
        public ResourcesScheme? FindBySession(string session)
        {
            AccountScheme? user = DatabaseAccount.collection.AsQueryable().Where(d => d.session == session).FirstOrDefault();
            var battleinfo = FindByUid(user.Id);

            return battleinfo;
        }



        public UserInformationResponse.Resource? ResourcesSchemeToUserInformationResource(ResourcesScheme resources)
        {
            UserInformationResponse.Resource resource = new()
            {
                __nickname = resources.nickname,
                __annCoin = resources.annCoin,
                __level = resources.level,
                __blackChallenge = resources.blackChallenge,
                __blueprintArmy = resources.blueprintArmy,
                __blueprintNavy = resources.blueprintNavy,
                __bullet = resources.bullet,
                __cash = resources.cash,
                __challenge = resources.challenge,
                __challengeCoin = resources.challengeCoin,
                __chip = resources.chip,
                __commanderGift = resources.commanderGift,
                __commanderPromotionPoint = resources.commanderPromotionPoint,
                __eventRaidTicket = resources.eventRaidTicket,
                __exp = resources.exp,
                __explorationTicket = resources.explorationTicket,
                __gold = resources.gold,
                __guildCoin = resources.guildCoin,
                __honor = resources.honor,
                __oil = resources.oil,
                __opcon = resources.opcon,
                __opener = resources.opener,
                __raidCoin = resources.raidCoin,
                __ring = resources.ring,
                __sweepTicket = resources.sweepTicket,
                __thumbnailId = resources.thumbnailId,
                __vipExp = resources.vipExp,
                __vipLevel = resources.vipLevel,
                __waveDuelCoin = resources.waveDuelCoin,
                __waveDuelTicket = resources.waveDuelTicket,
                __weaponImmediateTicket = resources.weaponImmediateTicket,
                __weaponMakeTicket = resources.weaponMakeTicket,
                __weaponMaterial1 = resources.weaponMaterial1,
                __weaponMaterial2 = resources.weaponMaterial2,
                __weaponMaterial3 = resources.weaponMaterial3,
                __weaponMaterial4 = resources.weaponMaterial4,
                __worldDuelCoin = resources.worldDuelCoin,
                __worldDuelTicket = resources.worldDuelTicket,
                __worldDuelUpgradeCoin = resources.worldDuelUpgradeCoin,

            };

            return resource;

        }
        public UserInformationResponse.Resource? RequestResourcesScheme(string session)
        {
            return ResourcesSchemeToUserInformationResource(FindBySession(session));

        }
        public UserInformationResponse.Resource? RequestResourcesScheme(int mIdx)
        {
            return ResourcesSchemeToUserInformationResource(FindByUid(mIdx));
        }



 
        public void UpdateCash(int id, int cash, bool useAddition)
        {
            var resources = FindByUid(id);

            if (useAddition)
            {
                cash = Convert.ToInt32(resources.cash) + cash;

            }
            else
            {
                cash = Convert.ToInt32(resources.cash) - cash;
            }

            var filter = Builders<ResourcesScheme>.Filter.Eq("Id", resources.Id);

            var update = Builders<ResourcesScheme>.Update.Set("cash", cash);

            collection.UpdateOne(filter, update);

        }
        public void UpdateGold(int id, int gold, bool useAddition)
        {
            var resources = FindByUid(id);

            if (useAddition)
            {
                gold = Convert.ToInt32(resources.gold) + gold;

            }
            else
            {
                gold = Convert.ToInt32(resources.gold) - gold;
            }

            var filter = Builders<ResourcesScheme>.Filter.Eq("Id", resources.Id);

            var update = Builders<ResourcesScheme>.Update.Set("gold", gold);

            collection.UpdateOne(filter, update);


        }
        public void UpdateGold(string session, int gold, bool useAddition)
        {
            var resources = FindBySession(session);

            if (useAddition)
            {
                gold = Convert.ToInt32(resources.gold) + gold;

            }
            else
            {
                gold = Convert.ToInt32(resources.gold) - gold;
            }

            var filter = Builders<ResourcesScheme>.Filter.Eq("Id", resources.Id);

            var update = Builders<ResourcesScheme>.Update.Set("gold", gold);

            collection.UpdateOne(filter, update);


        }
        public void UpdateCash(string session, int cash, bool useAddition)
        {
            var resources = FindBySession(session);

            if (useAddition)
            {
                cash = Convert.ToInt32(resources.cash) + cash;

            }
            else
            {
                cash = Convert.ToInt32(resources.cash) - cash;
            }

            var filter = Builders<ResourcesScheme>.Filter.Eq("Id", resources.Id);

            var update = Builders<ResourcesScheme>.Update.Set("cash", cash);

            collection.UpdateOne(filter, update);

        }
        public void UpdateGoldAndCash(int id, int gold, int cash)
        {
            var resources = FindByUid(id);

            var filter = Builders<ResourcesScheme>.Filter.Eq("Id", resources.Id);

            var update = Builders<ResourcesScheme>.Update.Set("gold", gold).Set("cash", cash);

            collection.UpdateOne(filter, update);
        }
        public void UpdateNickName(string accountName, string sess)
        {
            AccountScheme? user = DatabaseAccount.collection.AsQueryable().Where(d => d.session == sess).FirstOrDefault();
            var battleinfo = FindByUid(user.Id);

            var filter = Builders<ResourcesScheme>.Filter.Eq("Id", user.Id);

            var update = Builders<ResourcesScheme>.Update.Set("nickname", accountName);

            collection.UpdateOne(filter, update);
        }


        public void UpdateExpAndLevel(int id, int exp, int level)
        {
            var filter = Builders<ResourcesScheme>.Filter.Eq("Id", id);

            var update = Builders<ResourcesScheme>.Update.Set("exp", exp).Set("level", level);

            collection.UpdateOne(filter, update);
        }



        public bool ChangeThumbnail(int idx, string session)
        {

            // TODO UPDATING

            var user = FindBySession(session);

            int id = CommanderCostumeData.GetInstance().FromId(idx).ctid;

            var filter = Builders<ResourcesScheme>.Filter.Eq("Id", user.Id);

            var update = Builders<ResourcesScheme>.Update.Set("thumbnailId", id);

            collection.UpdateOne(filter, update);

            return true;

        }

    }
}
