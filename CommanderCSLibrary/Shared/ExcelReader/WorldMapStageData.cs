using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.ExcelReader
{
    public class WorldMapStageData : BaseExcelReader<WorldMapStageData, WorldMapStageDataExcel>
    {
        public override string FileName { get { return "WorldMapStageDataTable.json"; } }

        public WorldMapStageDataExcel? FromWorldMapId(string worldMapId)
        {
            return All.Where(avatar => avatar.worldMapId == worldMapId).FirstOrDefault();
        }

        public WorldMapStageDataExcel? FromStageId(int stageId)
        {
            return All.Where(avatar => avatar.id == stageId.ToString()).FirstOrDefault();
        }

        public Dictionary<string, List<WorldMapInformationResponse>> AddAllStagesAtDefault()
        {
            Dictionary<string, List<WorldMapInformationResponse>> stages = [];

            string path = File.ReadAllText($"Resources\\ExcelOutputAsset\\{FileName}");

            var stageList = JsonConvert.DeserializeObject<List<WorldMapStageDataExcel>>(path);

            foreach (var stage in stageList)
            {
                stages = stageList
                 .GroupBy(s => s.worldMapId)
                    .ToDictionary(
                g => g.Key.ToString(),
                g => g.Select(s => new WorldMapInformationResponse
                {
                    stageId = "" + s.id,
                    clearCount = 0,
                    star = 0
                }).ToList());
            }
            return stages;
        }
    }

    public class Normalized
    {
        [JsonProperty("x")]
        public double x { get; set; }

        [JsonProperty("y")]
        public double y { get; set; }

        [JsonProperty("z")]
        public double z { get; set; }

        [JsonProperty("normalized")]
        public Normalize normalized { get; set; }

        [JsonProperty("magnitude")]
        public double magnitude { get; set; }

        [JsonProperty("sqrMagnitude")]
        public double sqrMagnitude { get; set; }
    }

    public class Normalize
    {
        [JsonProperty("x")]
        public double x { get; set; }

        [JsonProperty("y")]
        public double y { get; set; }

        [JsonProperty("z")]
        public double z { get; set; }

        [JsonProperty("magnitude")]
        public double magnitude { get; set; }

        [JsonProperty("sqrMagnitude")]
        public double sqrMagnitude { get; set; }
    }

    public class Position
    {
        [JsonProperty("x")]
        public double x { get; set; }

        [JsonProperty("y")]
        public double y { get; set; }

        [JsonProperty("z")]
        public double z { get; set; }

        [JsonProperty("normalized")]
        public Normalized normalized { get; set; }

        [JsonProperty("magnitude")]
        public double magnitude { get; set; }

        [JsonProperty("sqrMagnitude")]
        public double sqrMagnitude { get; set; }
    }

    public class WorldMapStageDataExcel
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("worldMapId")]
        public string worldMapId { get; set; }

        [JsonProperty("positionX")]
        public double positionX { get; set; }

        [JsonProperty("positionY")]
        public double positionY { get; set; }

        [JsonProperty("position")]
        public Position position { get; set; }

        [JsonProperty("typeId")]
        public string typeId { get; set; }

        [JsonProperty("type")]
        public int type { get; set; }

        [JsonProperty("bullet")]
        public int bullet { get; set; }

        [JsonProperty("terrain")]
        public int terrain { get; set; }

        [JsonProperty("order")]
        public int order { get; set; }

        [JsonProperty("enemyId")]
        public string enemyId { get; set; }

        [JsonProperty("rewardGold")]
        public int rewardGold { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("favorup")]
        public int favorup { get; set; }

        [JsonProperty("battlemap")]
        public string battlemap { get; set; }

        [JsonProperty("enemymap")]
        public string enemymap { get; set; }

        [JsonProperty("turn1")]
        public int turn1 { get; set; }

        [JsonProperty("turn2")]
        public int turn2 { get; set; }

        [JsonProperty("turn3")]
        public int turn3 { get; set; }

        [JsonProperty("getStar01")]
        public int getStar01 { get; set; }

        [JsonProperty("getStar01Count")]
        public object getStar01Count { get; set; }

        [JsonProperty("getStar02")]
        public int getStar02 { get; set; }

        [JsonProperty("getStar02Count")]
        public object getStar02Count { get; set; }

        [JsonProperty("commanderexp")]
        public int commanderexp { get; set; }
    }

    public class WorldMapStageDatav1
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("worldMapId")]
        public int worldMapId { get; set; }

        [JsonProperty("positionX")]
        public int positionX { get; set; }

        [JsonProperty("positionY")]
        public int positionY { get; set; }

        [JsonProperty("typeId")]
        public int typeId { get; set; }

        [JsonProperty("bullet")]
        public int bullet { get; set; }

        [JsonProperty("terrain")]
        public int terrain { get; set; }

        [JsonProperty("order")]
        public int order { get; set; }

        [JsonProperty("favorup")]
        public int favorup { get; set; }

        [JsonProperty("enemyId")]
        public int enemyId { get; set; }

        [JsonProperty("title")]
        public int title { get; set; }

        [JsonProperty("description")]
        public int description { get; set; }

        [JsonProperty("battlemap")]
        public string battlemap { get; set; }

        [JsonProperty("enemymap")]
        public string enemymap { get; set; }

        [JsonProperty("turn1")]
        public int turn1 { get; set; }

        [JsonProperty("turn2")]
        public int turn2 { get; set; }

        [JsonProperty("turn3")]
        public int turn3 { get; set; }

        [JsonProperty("commanderexp")]
        public int commanderexp { get; set; }
    }
}