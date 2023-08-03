using System.Text.Json;
using StellarGK.Logic.Protocols;
using StellarGK.Utils.ExcelReader;

namespace StellarGK.Logic.ExcelReader
{
    public class WorldMapStageData : BaseExcelReader<WorldMapStageData, WorldMapStageDataExcel>
    {
        public override string FileName { get { return "WorldMapStageDataTable_2.json"; } }

        public WorldMapStageDataExcel? FromLevel(int worldMapId)
        {
            return All.Where(avatar => avatar.worldMapId == worldMapId).FirstOrDefault();
        }

        public Dictionary<string, List<WorldMapInformationResponse>> GetStages()
        {
            Dictionary<string, List<WorldMapInformationResponse>> stages = new();

            string path = File.ReadAllText($"Resources\\ExcelOutputAsset\\{FileName}");

            var stageList = JsonSerializer.Deserialize<List<WorldMapStageDataExcel>>(path);

            foreach (var stage in stageList)
            {
                stages = stageList
                 .GroupBy(s => s.worldMapId)
                    .ToDictionary(
                g => g.Key.ToString(), // Convert the int key to string
                g => g.Select(s => new WorldMapInformationResponse
                {
                    stageId = "" + s.id,
                    clearCount = 0,
                    star = 0
                }).ToList()
            );
            }

            return stages;
        }

        public Dictionary<int, List<WorldMapInformationResponse>> RetrieveStages(Dictionary<string, List<WorldMapInformationResponse>> stages)
        {

            Dictionary<int, List<WorldMapInformationResponse>> stagesIntKeys = new();

            foreach (var kvp in stages)
            {
                if (int.TryParse(kvp.Key, out int worldMapId))
                {
                    stagesIntKeys.Add(worldMapId, kvp.Value);
                }
                else
                {
                    Console.WriteLine($"Failed to parse key: {kvp.Key} to int.");
                }
            }

            return stagesIntKeys;

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