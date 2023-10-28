using System;
using System.Collections.Generic;

namespace RoomDecorator.Data
{
	public class RoDormitoryRoom
	{
		private Dictionary<string, RoCharacter> masterCharacters
		{
			get
			{
				if (!isMasterRoom)
				{
					return null;
				}
				return RemoteObjectManager.instance.localUser.dormitory.characters;
			}
		}

		public void Set(Protocols.Dormitory.FloorDetailInfo data, bool isMasterUser)
		{
			characters = new Dictionary<string, RoCharacter>();
			fno = data.fno;
			name = data.name;
			isMasterRoom = isMasterUser;
			wallpaper = data.wallpaperId;
			decos = data.decos;
			foreach (KeyValuePair<string, Protocols.Dormitory.FloorCharacterInfo> keyValuePair in data.characters)
			{
				AddCharacter(keyValuePair.Value);
			}
		}

		public void AddCharacter(Protocols.Dormitory.FloorCharacterInfo data)
		{
			if (data.fno != fno)
			{
				return;
			}
			RoCharacter roCharacter = ((!isMasterRoom) ? RoCharacter.Create(data.id) : masterCharacters[data.id]);
			roCharacter.Set(data);
			characters.Add(data.id, roCharacter);
		}

		public void AddCharacter(RoCharacter data)
		{
			characters.Add(data.id, data);
		}

		public void RemoveCharacter(string id)
		{
			characters.Remove(id);
		}

		public bool ContainsCharacter(string id)
		{
			return characters.ContainsKey(id);
		}

		public string fno;

		public string name;

		public string wallpaper;

		public List<Protocols.Dormitory.FloorDecoInfo> decos;

		public Dictionary<string, RoCharacter> characters;

		private bool isMasterRoom;
	}
}
