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
            GuildScheme Guild = DatabaseManager.Guild.FindByGuildId(User.GuildId);

            // HERE WE WOULD NEED TO CHECK FIRST IF SOMEONE ELSE HAS A HIGHER SCORE OR LOWER Score and place us accordigl

            RaidRankScheme existing = DatabaseCollection.Find(x => x.id == User.MemberId).FirstOrDefault();

            if (existing == null)
            {
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

                return;
            }

            if (existing.score < score)
            {
                var filter = Builders<RaidRankScheme>.Filter.And(
                    Builders<RaidRankScheme>.Filter.Eq(r => r.id, User.MemberId),
                    Builders<RaidRankScheme>.Filter.Lt(r => r.score, score) // Only replace if existing score is lower
                );

                RaidRankScheme raidRank = new()
                {
                    id = User.MemberId,
                    score = score,
                    grade = 0,
                    level = User.Resources.level,
                    rank = 999999,
                    thumb = User.Resources.thumbnailId.ToString(),
                    time = time,
                    _name = User.Resources.nickname,
                };

                if (Guild != null)
                {
                    raidRank.guildServer = Guild.World;
                    raidRank.guildName = Guild.Name;
                }

                //DatabaseCollection.ReplaceOne(filter, raidRank, new ReplaceOptions { IsUpsert = true });
            }

        }


        public List<RankData> GetTopRanks()
        {
            List<RaidRankScheme> ranks = DatabaseCollection.Find(_ => true)
                .SortByDescending(r => r.score)
                .ThenBy(r => r.time)
                .Limit(100)
                .ToList();

            List<RankData> rankList = [];

            int currentRank = 1;
            foreach (var rank in ranks)
            {
                RankData rankData = new()
                {
                    id = rank.id,
                    level = rank.level,
                    _name = rank._name,
                    thumb = rank.thumb,
                    score = rank.score,
                    grade = rank.grade,
                    rank = currentRank,
                    time = rank.time,
                    guildName = rank.guildName,
                    guildServer = rank.guildServer,
                };
                rankList.Add(rankData);
                currentRank++;
            }

            return rankList;
        }


        public RankingUserData GetUserRaidInfo(int memberId)
        {
            List<RaidRankScheme> allRanks = DatabaseCollection.Find(_ => true)
                .SortByDescending(r => r.score)
                .ThenBy(r => r.time)
                .ToList();

            RaidRankScheme userRank = null;
            int userPosition = 0;
            int totalPlayers = allRanks.Count;

            for (int i = 0; i < allRanks.Count; i++)
            {
                if (allRanks[i].id == memberId)
                {
                    userRank = allRanks[i];
                    userPosition = i + 1;
                    break;
                }
            }

            if (userRank == null)
            {
                return new RankingUserData();
            }

            float rankingRate = totalPlayers > 0 ? (float)userPosition / totalPlayers * 100f : 0f;


            var userRanked = new RankingUserData
            {
                score = userRank.score,
                bestScore = userRank.score,
                ranking = userPosition,
                rankingRate = rankingRate,
                raidRank = userRank.grade,
                raidCnt = 1,
                averageScore = userRank.score,
            };

            return userRanked;
        }

    }
}