using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB.Schemes;
using MongoDB.Driver;

namespace CommanderCS.MongoDB.Handlers
{
    public class DatabaseConquest : DatabaseTable<ConqeustScheme>
    {
        private const long PHASE_DURATION_SECONDS = 12 * 3600; // 12 hours per conquest state

        public DatabaseConquest() : base("GuildConquest")
        {
        }

        public ConqeustScheme FindByGuildId(int guildId)
        {
            return DatabaseCollection.Find(x => x.GuildId == guildId).FirstOrDefault();
        }

        public ConqeustScheme GetOrCreate(int guildId)
        {
            ConqeustScheme scheme = FindByGuildId(guildId);

            if (scheme != null)
            {
                return scheme;
            }

            scheme = new ConqeustScheme
            {
                GuildId = guildId,
                enemyGuildId = 0,
                notice = "",
                conquestTroopInfo = DefaultTroopInfo(),
                conquestInfo = DefaultConquestInfo(),
                phaseEndTime = 0,
            };

            DatabaseCollection.InsertOne(scheme);

            return scheme;
        }

        public string GetNotice(int guildId)
        {
            ConqeustScheme scheme = FindByGuildId(guildId);
            return scheme?.notice ?? "";
        }

        public void UpdateNotice(int guildId, string notice)
        {
            GetOrCreate(guildId);

            var filter = Builders<ConqeustScheme>.Filter.Eq(x => x.GuildId, guildId);
            var update = Builders<ConqeustScheme>.Update.Set(x => x.notice, notice);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public ConquestInfo GetConquestInfo(int guildId)
        {
            ConqeustScheme scheme = GetOrCreate(guildId);

            AdvanceStateIfExpired(scheme);

            ConquestInfo info = scheme.conquestInfo ?? DefaultConquestInfo();

            // Compute remain dynamically from the stored phase end time
            if (scheme.phaseEndTime > 0)
            {
                long now = TimeManager.CurrentEpoch;
                info.remain = (int)Math.Max(0, scheme.phaseEndTime - now);
            }
            else
            {
                info.remain = 0;
            }

            return info;
        }

        public void UpdateConquestInfo(int guildId, ConquestInfo info)
        {
            GetOrCreate(guildId);

            var filter = Builders<ConqeustScheme>.Filter.Eq(x => x.GuildId, guildId);
            var update = Builders<ConqeustScheme>.Update.Set(x => x.conquestInfo, info);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void JoinConquest(int guildId)
        {
            ConqeustScheme scheme = GetOrCreate(guildId);

            ConquestInfo info = scheme.conquestInfo ?? DefaultConquestInfo();
            info.state = EConquestState.Join;
            info.sign = 1;

            long phaseEnd = TimeManager.CurrentEpoch + PHASE_DURATION_SECONDS;

            var filter = Builders<ConqeustScheme>.Filter.Eq(x => x.GuildId, guildId);
            var update = Builders<ConqeustScheme>.Update
                .Set(x => x.conquestInfo, info)
                .Set(x => x.phaseEndTime, phaseEnd);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public ConquestTroopInfo GetTroopInfo(int guildId)
        {
            ConqeustScheme scheme = GetOrCreate(guildId);
            ConquestTroopInfoScheme troopScheme = scheme.conquestTroopInfo ?? DefaultTroopInfo();

            ConquestTroopInfo troopInfo = new()
            {
                slot = troopScheme.slot ?? [0, 1, 2],
                squard = troopScheme.squard?.ToDictionary(
                    kvp => int.Parse(kvp.Key),
                    kvp => new ConquestTroopInfo.Troop
                    {
                        point = kvp.Value.point,
                        status = kvp.Value.status,
                        remain = kvp.Value.remain,
                        mvtm = kvp.Value.mvtm,
                        path = kvp.Value.path ?? [],
                        ucash = kvp.Value.ucash,
                        deck = kvp.Value.deck ?? [],
                    }) ?? [],
                eGuild = troopScheme.enemyGuild != null ? new ConquestTroopInfo.Enemy
                {
                    name = troopScheme.enemyGuild.name,
                    world = troopScheme.enemyGuild.world,
                    emblem = troopScheme.enemyGuild.emblem,
                    level = troopScheme.enemyGuild.level,
                    mcnt = troopScheme.enemyGuild.memberCount,
                } : new(),
            };

            return troopInfo;
        }

        public void UpdateTroop(int guildId, int slot, Dictionary<string, string> deck)
        {
            GetOrCreate(guildId);

            var filter = Builders<ConqeustScheme>.Filter.Eq(x => x.GuildId, guildId);
            var update = Builders<ConqeustScheme>.Update
                .Set($"conquestTroopInfo.squard.{slot}.deck", deck);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void DeleteTroop(int guildId, int slot)
        {
            var filter = Builders<ConqeustScheme>.Filter.Eq(x => x.GuildId, guildId);
            var update = Builders<ConqeustScheme>.Update.Unset($"conquestTroopInfo.squard.{slot}");

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void AddSlot(int guildId, int slot)
        {
            GetOrCreate(guildId);

            var filter = Builders<ConqeustScheme>.Filter.Eq(x => x.GuildId, guildId);
            var update = Builders<ConqeustScheme>.Update.AddToSet(x => x.conquestTroopInfo.slot, slot);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateTroopPosition(int guildId, int slot, int dest, List<int> path, int travelTime, int ucash)
        {
            var filter = Builders<ConqeustScheme>.Filter.Eq(x => x.GuildId, guildId);
            var update = Builders<ConqeustScheme>.Update
                .Set($"conquestTroopInfo.squard.{slot}.point", dest)
                .Set($"conquestTroopInfo.squard.{slot}.path", path)
                .Set($"conquestTroopInfo.squard.{slot}.remain", travelTime)
                .Set($"conquestTroopInfo.squard.{slot}.mvtm", travelTime)
                .Set($"conquestTroopInfo.squard.{slot}.status", "M")
                .Set($"conquestTroopInfo.squard.{slot}.ucash", ucash);

            DatabaseCollection.UpdateOne(filter, update);
        }

        // Checks if the current phase timer has expired and advances the state if so.
        // Called on every GetConquestInfo so no external scheduler is needed.
        private void AdvanceStateIfExpired(ConqeustScheme scheme)
        {
            if (scheme.conquestInfo is null) return;
            if (scheme.phaseEndTime == 0) return;

            long now = TimeManager.CurrentEpoch;

            if (now < scheme.phaseEndTime) return;

            EConquestState nextState = scheme.conquestInfo.state switch
            {
                EConquestState.Join => EConquestState.Match,
                EConquestState.Match => EConquestState.Setting,
                EConquestState.Setting => EConquestState.Battle,
                EConquestState.Battle => EConquestState.None,
                _ => EConquestState.None,
            };

            long nextPhaseEnd = nextState != EConquestState.None
                ? now + PHASE_DURATION_SECONDS
                : 0;

            // Update scheme in memory so the caller sees the new state immediately
            scheme.conquestInfo.state = nextState;
            scheme.phaseEndTime = nextPhaseEnd;

            var filter = Builders<ConqeustScheme>.Filter.Eq(x => x.GuildId, scheme.GuildId);
            var update = Builders<ConqeustScheme>.Update
                .Set(x => x.conquestInfo.state, nextState)
                .Set(x => x.phaseEndTime, nextPhaseEnd);

            DatabaseCollection.UpdateOne(filter, update);
        }

        private static ConquestInfo DefaultConquestInfo()
        {
            ConquestInfo info = new()
            {
                state = EConquestState.None,
                remain = 0,
                sign = 0,
                join = 0,
                side = "R",
                prev = new()
                {
                    standbyList = [],
                    exdt = 0,
                    isWin = 0,
                    pointData = new() { win = [], lose = [] },
                    userList = [],
                },
            };

            return info;
        }

        private static ConquestTroopInfoScheme DefaultTroopInfo()
        {
            ConquestTroopInfoScheme scheme = new()
            {
                squard = [],
                slot = [0, 1, 2],
                enemyGuild = new(),
            };

            return scheme;
        }
    }
}
