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

            stages = stageList.ToDictionary(stage => "" + stage.worldMapId, _ => 0);

            return stages;
        }
    }

    public class WorldMapStageDataExcel
    {
        public int id { get; set; }
        public int worldMapId { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }
        public int typeId { get; set; }
        public int bullet { get; set; }
        public int terrain { get; set; }
        public int order { get; set; }
        public int favorup { get; set; }
        public int enemyId { get; set; }
        public int title { get; set; }
        public int description { get; set; }
        public string battlemap { get; set; }
        public string enemymap { get; set; }
        public int turn1 { get; set; }
        public int turn2 { get; set; }
        public int turn3 { get; set; }
        public int commanderexp { get; set; }
    }
}