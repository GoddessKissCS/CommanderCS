using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace CommanderCSLibrary.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class ProjectileMotionPhaseDataRow : DataRow
    {
        public const string PrefabHome = "Assets/Resources/Prefabs/Cache/Projectiles";

        public string key { get; private set; }

        public bool isHeader { get; private set; }

        public int patternCount { get; private set; }

        public int duration { get; private set; }

        public int eventTime { get; private set; }

        private ProjectileMotionPhaseDataRow()
        {
        }

        public string GetKey()
        {
            return key;
        }

        public static string MakeKey(string assetPath)
        {
            int num = assetPath.LastIndexOf('/', assetPath.Length - 1);
            num = assetPath.LastIndexOf('/', num - 1);
            num = assetPath.LastIndexOf('/', num - 1);
            string text = assetPath.Substring(num + 1);
            Regex regex = new Regex("(.+)\\.[^\\.]+$");
            Match match = regex.Match(text);
            if (match.Success)
            {
                text = match.Groups[1].ToString();
            }
            return text;
        }

        public static string MakeHeaderKey(string key)
        {
            int val = key.LastIndexOf("/");
            return key.Substring(0, Math.Max(0, val));
        }

        public static string MakeAssetPath(string key)
        {
            return "Assets/Resources/Prefabs/Cache/Projectiles/" + key + ".prefab";
        }

        public static ProjectileMotionPhaseDataRow Create(string assetPath, int duration, int eventTime)
        {
            ProjectileMotionPhaseDataRow projectileMotionPhaseDataRow = new ProjectileMotionPhaseDataRow();
            projectileMotionPhaseDataRow.key = MakeKey(assetPath);
            projectileMotionPhaseDataRow.isHeader = false;
            projectileMotionPhaseDataRow.duration = duration;
            projectileMotionPhaseDataRow.eventTime = eventTime;
            if (projectileMotionPhaseDataRow.eventTime == -1)
            {
                projectileMotionPhaseDataRow.eventTime = projectileMotionPhaseDataRow.duration;
            }
            if (projectileMotionPhaseDataRow.duration < projectileMotionPhaseDataRow.eventTime)
            {
                projectileMotionPhaseDataRow.duration = projectileMotionPhaseDataRow.eventTime;
            }
            projectileMotionPhaseDataRow.patternCount = -1;
            return projectileMotionPhaseDataRow;
        }

        public static ProjectileMotionPhaseDataRow CreateHeader(string key, int patternCount)
        {
            ProjectileMotionPhaseDataRow projectileMotionPhaseDataRow = new ProjectileMotionPhaseDataRow();
            projectileMotionPhaseDataRow.key = key;
            projectileMotionPhaseDataRow.isHeader = true;
            projectileMotionPhaseDataRow.duration = 0;
            projectileMotionPhaseDataRow.eventTime = -1;
            projectileMotionPhaseDataRow.patternCount = patternCount;
            return projectileMotionPhaseDataRow;
        }
    }
}