using Newtonsoft.Json;
using StellarGKLibrary.Protocols;
using StellarGKLibrary.Utils;

namespace StellarGKLibrary.ExcelReader
{
    public class WorldMapStageData : BaseExcelReader<WorldMapStageData, WorldMapStageDataExcel>
    {
        public override string FileName
        { get { return "WorldMapStageDataTable_2.json"; } }

        public WorldMapStageDataExcel? FromWorldMapId(int worldMapId)
        {
            return All.Where(avatar => avatar.worldMapId == worldMapId).FirstOrDefault();
        }

        public Dictionary<string, List<WorldMapInformationResponse>> AddAllStagesAtDefault()
        {
            Dictionary<string, List<WorldMapInformationResponse>> stages = new();

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

        public Dictionary<string, int> AddDefaultWorldMapIsRewardCollected()
        {
            Dictionary<string, int> stages = new();

            string path = File.ReadAllText($"Resources\\ExcelOutputAsset\\{FileName}");

            var stageList = JsonConvert.DeserializeObject<List<WorldMapStageDataExcel>>(path);

            foreach (var stage in stageList)
            {
                string worldMapId = "" + stage.worldMapId;
                if (!stages.ContainsKey(worldMapId))
                {
                    stages[worldMapId] = 0;
                }
            }

            return stages;
        }
    }

    public class WorldMapStageDataExcel
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