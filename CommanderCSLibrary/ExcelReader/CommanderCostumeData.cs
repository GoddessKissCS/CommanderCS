using CommanderCS.Protocols;
using CommanderCS.Utils;
using Newtonsoft.Json;

namespace CommanderCS.ExcelReader
{
    public class CommanderCostumeData : BaseExcelReader<CommanderCostumeData, CommanderCostumeExcel>
    {
        public override string FileName
        { get { return "CommanderCostumeDataTable.json"; } }

        public CommanderCostumeExcel? FromId(int idx)
        {
            return All.Where(avatar => avatar.cid == idx).FirstOrDefault();
        }

        public CommanderCostumeExcel? FromId(string idx)
        {
            return All.Where(avatar => avatar.cid == int.Parse(idx)).FirstOrDefault();
        }

        public CommanderCostumeExcel? FromCostumeId(int idx)
        {
            return All.Where(costume => costume.ctid == idx).FirstOrDefault();
        }

        public Dictionary<string, UserInformationResponse.Commander> GetAllCommandersWithDefaultValue()
        {
            Dictionary<string, UserInformationResponse.Commander> commanderDataDict = [];

            string path = File.ReadAllText($"Resources\\ExcelOutputAsset\\{FileName}");

            List<CommanderCostumeExcel> items = JsonConvert.DeserializeObject<List<CommanderCostumeExcel>>(path);

            foreach (var item in items)
            {
                string cid = item.cid.ToString();
                int medl = item.cid;

                if (!commanderDataDict.ContainsKey(cid))
                {
                    UserInformationResponse.Commander commanderData = new()
                    {
                        state = "N",
                        __skv1 = "1",
                        __skv2 = "1",
                        __skv3 = "1",
                        __skv4 = "1",
                        favorRewardStep = 0,
                        favorStep = 0,
                        currentCostume = item.ctid,
                        equipItemInfo = [],
                        equipWeaponInfo = [],
                        eventCostume = [],
                        favorPoint = new() { },
                        favr = 0,
                        fvrd = 0,
                        haveCostume = [item.ctid],
                        id = "" + cid,
                        marry = 0,
                        medl = medl,
                        role = "A",
                        transcendence = [0, 0, 0, 0],
                        __cls = "1",
                        __exp = "0",
                        __level = "1",
                        __rank = "1",
                    };

                    commanderDataDict.Add(cid.ToString(), commanderData);
                }
            }

            return commanderDataDict;
        }

        public Dictionary<string, UserInformationResponse.Commander> AddSpecificCommander(int commanderID)
        {
            Dictionary<string, UserInformationResponse.Commander> commanderDataDict = new();

            string path = File.ReadAllText($"Resources\\ExcelOutputAsset\\{FileName}");

            List<CommanderCostumeExcel> items = JsonConvert.DeserializeObject<List<CommanderCostumeExcel>>(path);

            CommanderCostumeExcel item = items.Where(c => c.cid == commanderID).FirstOrDefault();

            UserInformationResponse.Commander commanderData = new()
            {
                state = "N",
                __skv1 = "1",
                __skv2 = "1",
                __skv3 = "1",
                __skv4 = "1",
                favorRewardStep = 0,
                favorStep = 0,
                currentCostume = item.ctid,
                equipItemInfo = [],
                equipWeaponInfo = [],
                eventCostume = [],
                favorPoint = new() { },
                favr = 0,
                fvrd = 0,
                haveCostume = [item.ctid],
                id = "" + commanderID,
                marry = 0,
                medl = 0,
                role = "A",
                transcendence = [0, 0, 0, 0],
                __cls = "1",
                __exp = "0",
                __level = "1",
                __rank = "1",
            };

            commanderDataDict.Add(commanderID.ToString(), commanderData);

            return commanderDataDict;
        }

        public Dictionary<string, UserInformationResponse.Commander> AddSpecificCommander(Dictionary<string, UserInformationResponse.Commander> commanderDict, int commanderID)
        {
            string path = File.ReadAllText($"Resources\\ExcelOutputAsset\\{FileName}");

            List<CommanderCostumeExcel> items = JsonConvert.DeserializeObject<List<CommanderCostumeExcel>>(path);

            CommanderCostumeExcel item = items.Where(c => c.cid == commanderID).FirstOrDefault();

            UserInformationResponse.Commander commanderData = new()
            {
                state = "N",
                __skv1 = "1",
                __skv2 = "1",
                __skv3 = "0",
                __skv4 = "0",
                favorRewardStep = 0,
                favorStep = 0,
                currentCostume = item.ctid,
                equipItemInfo = [],
                equipWeaponInfo = [],
                eventCostume = [],
                favorPoint = new() { },
                favr = 0,
                fvrd = 0,
                haveCostume = [item.ctid],
                id = "" + commanderID,
                marry = 0,
                medl = 0,
                role = "A",
                transcendence = [0, 0, 0, 0],
                __cls = "1",
                __exp = "0",
                __level = "1",
                __rank = "1",
            };

            commanderDict.Add(commanderID.ToString(), commanderData);

            return commanderDict;
        }

        public Dictionary<string, int> GetAllCommandersMedalsWithDefaultValue()
        {
            Dictionary<string, int> commanderDataDict = new();

            string path = File.ReadAllText($"Resources\\ExcelOutputAsset\\{FileName}");

            List<CommanderCostumeExcel> items = JsonConvert.DeserializeObject<List<CommanderCostumeExcel>>(path);

            foreach (var item in items)
            {
                int cid = item.cid;

                // Check if the cid already exists in the dictionary to avoid duplicates
                if (!commanderDataDict.ContainsKey(cid.ToString()))
                {
                    // Add the new entry to the dictionary with cid as the key and CommanderData as the value
                    commanderDataDict.Add(cid.ToString(), cid);
                }
            }

            return commanderDataDict;
        }

        public Dictionary<string, int> AddSpecificCommanderMedals(int commanderId)
        {
            Dictionary<string, int> commanderDataDict = [];

            string path = File.ReadAllText($"Resources\\ExcelOutputAsset\\{FileName}");

            List<CommanderCostumeExcel> items = JsonConvert.DeserializeObject<List<CommanderCostumeExcel>>(path);

            commanderDataDict.Add("" + commanderId, 1);

            return commanderDataDict;
        }
    }

    public class CommanderCostumeExcel
    {
        [JsonProperty("ctid")]
        public int ctid { get; set; }

        [JsonProperty("cid")]
        public int cid { get; set; }

        [JsonProperty("name")]
        public int name { get; set; }

        [JsonProperty("Desc")]
        public int Desc { get; set; }

        [JsonProperty("sell")]
        public int sell { get; set; }

        [JsonProperty("gid")]
        public int gid { get; set; }

        [JsonProperty("sellPrice")]
        public int sellPrice { get; set; }

        [JsonProperty("atlasNumber")]
        public int atlasNumber { get; set; }

        [JsonProperty("skinName")]
        public int skinName { get; set; }

        [JsonProperty("order")]
        public int order { get; set; }

        [JsonProperty("statType1")]
        public int statType1 { get; set; }

        [JsonProperty("stat1")]
        public int stat1 { get; set; }

        [JsonProperty("statType2")]
        public int statType2 { get; set; }

        [JsonProperty("stat2")]
        public int stat2 { get; set; }

        [JsonProperty("statType3")]
        public int statType3 { get; set; }

        [JsonProperty("stat3")]
        public int stat3 { get; set; }
    }
}