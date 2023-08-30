using Newtonsoft.Json;
using StellarGKLibrary.Protocols;
using StellarGKLibrary.Utils;

namespace StellarGKLibrary.ExcelReader
{
    public class CommanderCostumeData : BaseExcelReader<CommanderCostumeData, CommanderCostumeExcel>
    {
        public override string FileName { get { return "CommanderCostumeDataTable.json"; } }

        public CommanderCostumeExcel? FromId(int idx)
        {
            return All.Where(avatar => avatar.cid == idx).FirstOrDefault();
        }

        public CommanderCostumeExcel? FromId(string idx)
        {
            return All.Where(avatar => avatar.cid == int.Parse(idx)).FirstOrDefault();
        }

        public Dictionary<string, UserInformationResponse.Commander> GetAllCommandersWithDefaultValue()
        {
            Dictionary<string, UserInformationResponse.Commander> commanderDataDict = new();

            string path = File.ReadAllText($"Resources\\ExcelOutputAsset\\{FileName}");

            List<CommanderCostumeExcel> items = JsonConvert.DeserializeObject<List<CommanderCostumeExcel>>(path);

            foreach (var item in items)
            {
                int cid = item.cid;

                // Check if the cid already exists in the dictionary to avoid duplicates
                if (!commanderDataDict.ContainsKey(cid.ToString()))
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
                        equipItemInfo = new() { },
                        equipWeaponInfo = new() { },
                        eventCostume = new() { },
                        favorPoint = new() { },
                        favr = 0,
                        fvrd = 0,
                        haveCostume = new() { item.ctid },
                        id = "" + cid,
                        marry = 0,
                        medl = cid,
                        role = "A",
                        transcendence = new() { 0, 0, 0, 0 },
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
                equipItemInfo = new() { },
                equipWeaponInfo = new() { },
                eventCostume = new() { },
                favorPoint = new() { },
                favr = 0,
                fvrd = 0,
                haveCostume = new() { item.ctid },
                id = "" + commanderID,
                marry = 0,
                medl = 0,
                role = "A",
                transcendence = new() { 0, 0, 0, 0 },
                __cls = "1",
                __exp = "0",
                __level = "1",
                __rank = "1",
            };

            commanderDataDict.Add(commanderID.ToString(), commanderData);


            return commanderDataDict;
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
            Dictionary<string, int> commanderDataDict = new();

            string path = File.ReadAllText($"Resources\\ExcelOutputAsset\\{FileName}");

            List<CommanderCostumeExcel> items = JsonConvert.DeserializeObject<List<CommanderCostumeExcel>>(path);


            commanderDataDict.Add("" + commanderId, 1);

            return commanderDataDict;
        }


    }

    public class CommanderCostumeExcel
    {
        public int ctid { get; set; }
        public int cid { get; set; }
        public int name { get; set; }
        public int Desc { get; set; }
        public int sell { get; set; }
        public int gid { get; set; }
        public int sellPrice { get; set; }
        public int atlasNumber { get; set; }
        public int skinName { get; set; }
        public int order { get; set; }
        public int statType1 { get; set; }
        public int stat1 { get; set; }
        public int statType2 { get; set; }
        public int stat2 { get; set; }
        public int statType3 { get; set; }
        public int stat3 { get; set; }
    }

}
