using System.Text;
using Newtonsoft.Json;
using StellarGKLibrary.Cryptography;


namespace StellarGKLibrary.BattleSimulator
{
    internal class BattleSimEntry
    {
        public static Regulation regulation { get; set; }


        public static void SetupRegulation()
        {
            regulation = Regulation.Create();
        }


        public static Dictionary<string, List<string>> fileInfo { get; set; } = new();
        public static List<string> arrDBFileName { get; set; } = new();


        public static void LoadDBlist()
        {

            string fileContent = File.ReadAllText("C:\\Users\\Zenith\\Desktop\\Test_Patch_DB_2\\DBList.txt");
            string text = Crypto.JSON_Decrypt(fileContent);
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            string @string = Encoding.UTF8.GetString(Prune(bytes));
            fileInfo = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(@string);


            if (fileInfo != null)
            {
                foreach (KeyValuePair<string, List<string>> keyValuePair in fileInfo)
                {
                    string key = keyValuePair.Key;
                    if (!arrDBFileName.Contains(key))
                    {
                        arrDBFileName.Add(key);
                    }

                }
            }


            for (int i = 0; i < arrDBFileName.Count; i++)
            {
               LoadDBFile(arrDBFileName[i]);
            }


        }

        public static void LoadDBFile(string filename)
        {
            string key = filename.Substring(0, 1);
            key = key.ToLower();
            key += filename.Substring(1);
            key = key.Replace("DataTable.json", string.Empty);
            key = key.Replace(".json", string.Empty);

            if (!string.IsNullOrEmpty(key))
            {
                var text = Crypto.JSON_Decrypt(filename);
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                string @string = Encoding.UTF8.GetString(Prune(bytes));
                Regulation.RegulationFile.Add(key, @string);
                regulation.SetFromLocalResources(key, @string);
            }


        }

        private static byte[] Prune(byte[] bytes)
        {
            if (bytes.Length == 0)
            {
                return bytes;
            }
            int num = bytes.Length - 1;
            while (bytes[num] == 0)
            {
                num--;
            }
            byte[] array = new byte[num + 1];
            Array.Copy(bytes, array, num + 1);
            return array;
        }


    }


}
