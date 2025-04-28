using CommanderCS.Library.Shared.Enum;
using Newtonsoft.Json;
using System.Reflection;

namespace CommanderCS.Host.Handlers.UserTerm
{
    [Packet(Id = Method.GetBadWordList)]
    public class GetBadWordList : BaseMethodHandler<GetBadWordListRequest>
    {
        public override object Handle(GetBadWordListRequest @params)
        {
            BadWordListResponse badWord = new()
            {
                word = []
            };

            badWord.word.Add("en", ["fuck"]);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = badWord
            };

            return response;
        }

        private class BadWordListResponse
        {
            [JsonProperty("word")]
            public Dictionary<string, List<string>> word { get; set; }
        }

        public static List<string> ReadBadWordsFromFile(string fileName)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string fileContent = $"{path}//Resources//BadWordList//{fileName}.txt";

            // Initialize a list to hold the processed lines from the file
            List<string> linesList = [];

            // Check if the file exists
            if (File.Exists(fileContent))
            {
                var file = File.ReadLines(fileContent);

                // Read each line from the file
                foreach (string line in file)
                {
                    // Split the line at the '#' character
                    string[] parts = line.Split('#');

                    // Add the part before the '#' character to the list
                    if (parts.Length > 0)
                    {
                        linesList.Add(parts[0].Trim());
                    }
                }
            }

            return linesList;
        }
    }

    public class GetBadWordListRequest
    {
        public List<string> lang { get; set; }
    }
}