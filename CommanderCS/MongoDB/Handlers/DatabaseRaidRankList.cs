using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB.Schemes;
using MongoDB.Driver;
using static CommanderCS.Library.Protocols.PvPRankingList;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for storing raid rank list data.
    /// </summary>
    public class DatabaseRaidRankList : DatabaseTable<RaidRankScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseRaidRankList"/> class with the specified table name.
        /// </summary>
        public DatabaseRaidRankList() : base("RaidRankList")
        {
        }

        /// <summary>
        /// Inserts a new raid rank list entry into the database.
        /// </summary>
        /// <param name="uno">The unique identifier of the player.</param>
        /// <param name="rankingData">The ranking data of the player.</param>
        public void Insert(GameProfileScheme User, int score, int time)
        {
            GuildScheme Guild = DatabaseManager.Guild.FindByUid(User.GuildId);
            
            // HERE WE WOULD NEED TO CHECK FIRST IF SOMEONE ELSE HAS A HIGHER SCORE OR LOWER Score and place us accordigly
            
            RaidRankScheme raidRank = new()
            {
                id = User.MemberId,
                score = score,
                grade = 0,
                level = User.Resources.level,
                rank = 1,
                thumb = User.Resources.thumbnailId.ToString(),
                time = time,
                _name = User.Resources.nickname,
            };

            if (Guild != null)
            {
                raidRank.guildServer = Guild.World;
                raidRank.guildName = Guild.Name;
            }

            DatabaseCollection.InsertOne(raidRank);
        }


        public List<RankData> GetTopRanks()
        {
            List<RaidRankScheme> ranks = DatabaseCollection.Find(_ => true)
                .SortByDescending(r => r.score)
                .ThenBy(r => r.time)
                .Limit(100)
                .ToList();

            List<RankData> rankList = [];

            foreach(var rank in ranks)
            {
                RankData rankData = new()
                {
                    id = rank.id,
                    level = rank.level,
                    _name = rank._name,
                    thumb = rank.thumb,
                    score = rank.score,
                    grade = rank.grade,
                    rank = rank.rank,
                    time = rank.time,
                    guildName = rank.guildName,
                    guildServer = rank.guildServer,
                };
                rankList.Add(rankData);
            }

            return rankList;
        }


    }
}