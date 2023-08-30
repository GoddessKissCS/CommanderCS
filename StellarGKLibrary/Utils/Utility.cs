using Newtonsoft.Json;
using StellarGKLibrary.Cryptography;
using StellarGKLibrary.Shared.Regulation;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StellarGKLibrary.Utils
{
    public class Utility
    {
        public static Regulation regulation { get; set; }

        public static DateTime ConvertToDateTime(string yyyymmddFormatString)
        {
            if (string.IsNullOrEmpty(yyyymmddFormatString) || yyyymmddFormatString.Length != 8)
            {
                return default(DateTime);
            }
            string text = yyyymmddFormatString.Substring(0, 4);
            string text2 = yyyymmddFormatString.Substring(4, 2);
            string text3 = yyyymmddFormatString.Substring(6, 2);
            int num = 0;
            if (!int.TryParse(text, out num))
            {
                return default(DateTime);
            }
            int num2 = 0;
            if (!int.TryParse(text2, out num2))
            {
                return default(DateTime);
            }
            int num3 = 0;
            if (!int.TryParse(text3, out num3))
            {
                return default(DateTime);
            }
            return new DateTime(num, num2, num3);
        }

        public static void LoadRegulation()
        {
            regulation = Regulation.Create();
            Dictionary<string, List<string>> fileInfo = null;
            List<string> arrDBFileName = new List<string>();

            string dblist = Crypto.JSON_Decrypt($"FileCDN\\Test_Patch_DB\\DBList.txt");
            fileInfo = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(dblist);
            if (fileInfo != null)
            {
                foreach (KeyValuePair<string, List<string>> keyValuePair in fileInfo)
                {
                    string key = keyValuePair.Key;
                    double datetime = double.Parse(keyValuePair.Value[0].ToString());
                    int fileSize = int.Parse(keyValuePair.Value[1].ToString());

                    if (!key.EndsWith(".txt"))
                    {
                        arrDBFileName.Add(key);
                    }

                    //string key = keyValuePair.Key;
                    //if (!arrDBFileName.Contains(key))
                    //{
                    //    arrDBFileName.Add(key);
                    //}
                }
            }

            for (int i = 0; i < arrDBFileName.Count; i++)
            {
                LoadDBFile(arrDBFileName[i]);
            }
        }
        private static void LoadDBFile(string filename)
        {
            string key = filename.Substring(0, 1);
            key = key.ToLower();
            key += filename.Substring(1);
            key = key.Replace("DataTable.json", string.Empty);
            key = key.Replace(".json", string.Empty);
            string filePath = $"FileCDN\\Test_Patch_DB\\" + filename;
            if (regulation.HasTable(key))
            {
                if (regulation.GetTable(key) == null)
                {
                    regulation.SetTable(key, Crypto.Object_DecryptFromFile(filePath));
                }
            }
            else
            {
                string text = File.ReadAllText($"FileCDN\\Test_Patch_DB\\" + filename);
                if (!string.IsNullOrEmpty(text))
                {
                    text = Crypto.JSON_Decrypt(text);
                    Regulation.RegulationFile.Add(key, text);
                    regulation.SetFromLocalResources(key, text);
                }
            }
        }
    }
}
