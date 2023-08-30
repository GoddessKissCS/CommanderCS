using StellarGKLibrary.Enums;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class ProjectileMotionPhaseDataRow : DataRow
	{
		private ProjectileMotionPhaseDataRow()
		{
		}

		public string key { get; set; }

		public bool isHeader { get; set; }

		public int patternCount { get; set; }

		public int duration { get; set; }

		public int eventTime { get; set; }

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
			int num = key.LastIndexOf("/");
			return key.Substring(0, Math.Max(0, num));
		}

		public static string MakeAssetPath(string key)
		{
			return "Assets/Resources/Prefabs/Cache/Projectiles/" + key + ".prefab";
		}

		public static ProjectileMotionPhaseDataRow Create(string assetPath, int duration, int eventTime)
		{
			ProjectileMotionPhaseDataRow projectileMotionPhaseDataRow = new ProjectileMotionPhaseDataRow();
			projectileMotionPhaseDataRow.key = ProjectileMotionPhaseDataRow.MakeKey(assetPath);
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
			return new ProjectileMotionPhaseDataRow
			{
				key = key,
				isHeader = true,
				duration = 0,
				eventTime = -1,
				patternCount = patternCount
			};
		}

		public const string PrefabHome = "Assets/Resources/Prefabs/Cache/Projectiles";
	}
}
