using System;
using System.Numerics;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using UnityEngine;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class GuildStruggleDataRow : DataRow
	{
		public string idx { get; private set; }

		public int positionx { get; private set; }

		public int positiony { get; private set; }

		public int guildpoint { get; private set; }

		public string battlemap { get; private set; }

		public string enemymap { get; private set; }

		public Vector3 position
		{
			get
			{
				return new Vector3((float)positionx, (float)positiony, 0f);
			}
		}

		public string GetKey()
		{
			return idx;
		}

	}
}
