using System;

namespace RoomDecorator.Data
{
	public class RoCharacter
	{
		public static RoCharacter Create(string id)
		{
			return new RoCharacter
			{
				id = id,
				remain = new TimeData()
			};
		}

		public static RoCharacter Create(RoCommander data)
		{
			RoCharacter roCharacter = RoCharacter.Create(data.id);
			roCharacter.commanderData = data;
			return roCharacter;
		}

		public void Set(Protocols.Dormitory.FloorCharacterInfo data)
		{
			fno = data.fno;
			head = new RoDormitory.Item(EDormitoryItemType.CostumeHead, data.headId);
			body = new RoDormitory.Item(EDormitoryItemType.CostumeBody, data.bodyId);
			remain.SetByDuration(data.remain);
		}

		public RoCharacter Clone()
		{
			return new RoCharacter
			{
				id = id,
				fno = fno,
				commanderData = commanderData,
				head = head.Clone(),
				body = body.Clone(),
				remain = remain
			};
		}

		public string id;

		public string fno;

		public RoCommander commanderData;

		public RoDormitory.Item head;

		public RoDormitory.Item body;

		public TimeData remain;
	}
}
