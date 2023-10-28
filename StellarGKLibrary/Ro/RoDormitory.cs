using System;
using System.Collections.Generic;
using Shared.Regulation;

namespace RoomDecorator.Data
{
	public class RoDormitory
	{
		public void Init()
		{
			config = new RoDormitory.Config();
			invenData = new RoDormitory.InventoryData();
			characters = new Dictionary<string, RoCharacter>();
			config.Init();
		}

		public void InitCommanders()
		{
			characters = new Dictionary<string, RoCharacter>();
			Regulation regulation = RemoteObjectManager.instance.regulation;
			List<RoCommander> commanderList = RemoteObjectManager.instance.localUser.commanderList;
			for (int i = 0; i < commanderList.Count; i++)
			{
				if (regulation.dormitoryHeadCostumeMap.ContainsKey(commanderList[i].id))
				{
					characters.Add(commanderList[i].id, RoCharacter.Create(commanderList[i]));
				}
			}
		}

		public void Set(Protocols.Dormitory.Info data)
		{
			config.inventoryLimit = data.info["inven"];
			SetInvenData(data);
		}

		public void Set(Dictionary<string, Protocols.Dormitory.CommanderInfo> data)
		{
			foreach (KeyValuePair<string, RoCharacter> keyValuePair in characters)
			{
				if (!data.ContainsKey(keyValuePair.Key))
				{
					Dictionary<string, RoCharacter>.Enumerator enumerator;
					KeyValuePair<string, RoCharacter> keyValuePair2 = enumerator.Current;
					keyValuePair2.Value.fno = "0";
				}
				else
				{
					Dictionary<string, RoCharacter>.Enumerator enumerator;
					KeyValuePair<string, RoCharacter> keyValuePair3 = enumerator.Current;
					RoCharacter value = keyValuePair3.Value;
					KeyValuePair<string, RoCharacter> keyValuePair4 = enumerator.Current;
					value.fno = data[keyValuePair4.Key].fno;
				}
			}
		}

		public void SetInvenData(Protocols.Dormitory.InventoryData data)
		{
			invenData.SetData(EDormitoryItemType.Normal, data.itemNormal);
			invenData.SetData(EDormitoryItemType.Advanced, data.itemAdvanced);
			invenData.SetData(EDormitoryItemType.Wallpaper, data.itemWallpaper);
			invenData.SetData(EDormitoryItemType.CostumeBody, data.costumeBody);
			invenData.SetHead(data.costumeHead);
		}

		public void UpdateInvenData(Protocols.Dormitory.InventoryData data)
		{
			UpdateInvenData(EDormitoryItemType.Normal, data.itemNormal);
			UpdateInvenData(EDormitoryItemType.Advanced, data.itemAdvanced);
			UpdateInvenData(EDormitoryItemType.Wallpaper, data.itemWallpaper);
			UpdateInvenData(EDormitoryItemType.CostumeBody, data.costumeBody);
			UpdateHeadData(data.costumeHead);
		}

		public void UpdateHeadData(Dictionary<string, List<string>> data)
		{
			invenData.UpdateHead(data);
		}

		public void UpdateInvenData(EDormitoryItemType type, Dictionary<string, int> data)
		{
			invenData.UpdateData(type, data);
		}

		public RoDormitory.Config config;

		public RoDormitory.InventoryData invenData;

		public Dictionary<string, RoCharacter> characters;

		public class User
		{
			public string uno;

			public string name;

			public int level;

			public bool isMaster;
		}

		public class Config
		{
			public void Init()
			{
				openLevel = int.Parse(RemoteObjectManager.instance.regulation.defineDtbl["SUPPLEMENT_LAND_OPEN_LEVEL"].value);
				changeRoomNameCache = int.Parse(RemoteObjectManager.instance.regulation.defineDtbl["DORMITORY_NAME_CHANGE_CASH"].value);
				maxFloorNum = int.Parse(RemoteObjectManager.instance.regulation.defineDtbl["DORMITORY_UPGRADE_MAX"].value);
				maxRoomCharacter = int.Parse(RemoteObjectManager.instance.regulation.defineDtbl["DORMITORY_PEOPLE_MAX"].value);
				inventoryLimit = int.Parse(RemoteObjectManager.instance.regulation.defineDtbl["DORMITORY_INVENTORY_LIMIT"].value);
				itemAmountLimit = int.Parse(RemoteObjectManager.instance.regulation.defineDtbl["DORMITORY_ITEM_LIMIT"].value);
				favorUserLimit = int.Parse(RemoteObjectManager.instance.regulation.defineDtbl["DORMITORY_MARK_MAX"].value);
			}

			public int openLevel;

			public int changeRoomNameCache;

			public int maxFloorNum;

			public int maxRoomCharacter;

			public int inventoryLimit;

			public int itemAmountLimit;

			public int favorUserLimit;
		}

		public class Item
		{
			public Item(EDormitoryItemType type)
			{
				type = type;
			}

			public Item(EDormitoryItemType type, string id)
			{
				type = type;
				id = id;
			}

			public virtual string id
			{
				get
				{
					return _id;
				}
				set
				{
					if (_id == value)
					{
						return;
					}
					_id = value;
					_data = null;
				}
			}

			public DataRow data
			{
				get
				{
					if (_data == null)
					{
						_data = ItemDBLoader.Load(type, _id);
					}
					return _data;
				}
			}

			public RoDormitory.Item Clone()
			{
				return new RoDormitory.Item(type, id)
				{
					_data = _data
				};
			}

			public EDormitoryItemType type = EDormitoryItemType.Normal;

			protected string _id;

			private DataRow _data;
		}

		public class InvenSlot
		{
			public InvenSlot(RoDormitory.Item item, int amount)
			{
				item = item;
				amount = amount;
			}

			public InvenSlot(EDormitoryItemType type, string id, int amount)
			{
				item = new RoDormitory.Item(type, id);
				amount = amount;
			}

			public RoDormitory.Item item;

			public int amount;
		}

		public class InventoryData
		{
			public InventoryData()
			{
				itemNormal = new Dictionary<string, RoDormitory.InvenSlot>();
				itemAdvanced = new Dictionary<string, RoDormitory.InvenSlot>();
				itemWallpaper = new Dictionary<string, RoDormitory.InvenSlot>();
				costumeBody = new Dictionary<string, RoDormitory.InvenSlot>();
				costumeHead = new Dictionary<string, Dictionary<string, RoDormitory.Item>>();
				_SetData = new Action<Dictionary<string, int>>[]
				{
					null,
					delegate(Dictionary<string, int> data)
					{
						SetData(itemNormal, data, (string id) => new RoDormitory.Item(EDormitoryItemType.Normal, id));
					},
					delegate(Dictionary<string, int> data)
					{
						SetData(itemAdvanced, data, (string id) => new RoDormitory.Item(EDormitoryItemType.Advanced, id));
					},
					delegate(Dictionary<string, int> data)
					{
						SetData(itemWallpaper, data, (string id) => new RoDormitory.Item(EDormitoryItemType.Wallpaper, id));
					},
					null,
					delegate(Dictionary<string, int> data)
					{
						SetData(costumeBody, data, (string id) => new RoDormitory.Item(EDormitoryItemType.CostumeBody, id));
					}
				};
				_UpdateData = new Action<Dictionary<string, int>>[]
				{
					null,
					delegate(Dictionary<string, int> data)
					{
						UpdateData(itemNormal, data, (string id) => new RoDormitory.Item(EDormitoryItemType.Normal, id));
					},
					delegate(Dictionary<string, int> data)
					{
						UpdateData(itemAdvanced, data, (string id) => new RoDormitory.Item(EDormitoryItemType.Advanced, id));
					},
					delegate(Dictionary<string, int> data)
					{
						UpdateData(itemWallpaper, data, (string id) => new RoDormitory.Item(EDormitoryItemType.Wallpaper, id));
					},
					null,
					delegate(Dictionary<string, int> data)
					{
						UpdateData(costumeBody, data, (string id) => new RoDormitory.Item(EDormitoryItemType.CostumeBody, id));
					}
				};
			}

			public void SetHead(Dictionary<string, List<string>> data)
			{
				costumeHead.Clear();
				UpdateHead(data);
			}

			public void UpdateHead(Dictionary<string, List<string>> data)
			{
				if (data == null)
				{
					return;
				}
				Dictionary<string, List<string>>.Enumerator enumerator = data.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Dictionary<string, Dictionary<string, RoDormitory.Item>> dictionary = costumeHead;
					KeyValuePair<string, List<string>> keyValuePair = enumerator.Current;
					if (!dictionary.ContainsKey(keyValuePair.Key))
					{
						Dictionary<string, Dictionary<string, RoDormitory.Item>> dictionary2 = costumeHead;
						KeyValuePair<string, List<string>> keyValuePair2 = enumerator.Current;
						dictionary2.Add(keyValuePair2.Key, new Dictionary<string, RoDormitory.Item>());
					}
					KeyValuePair<string, List<string>> keyValuePair3 = enumerator.Current;
					List<string> value = keyValuePair3.Value;
					for (int i = 0; i < value.Count; i++)
					{
						Dictionary<string, Dictionary<string, RoDormitory.Item>> dictionary3 = costumeHead;
						KeyValuePair<string, List<string>> keyValuePair4 = enumerator.Current;
						dictionary3[keyValuePair4.Key].Add(value[i], new RoDormitory.Item(EDormitoryItemType.CostumeHead, value[i]));
					}
				}
			}

			public void SetData(EDormitoryItemType type, Dictionary<string, int> data)
			{
				_SetData[(int)type](data);
			}

			public void UpdateData(EDormitoryItemType type, Dictionary<string, int> data)
			{
				if (data == null)
				{
					return;
				}
				_UpdateData[(int)type](data);
			}

			private void SetData(Dictionary<string, RoDormitory.InvenSlot> item, Dictionary<string, int> data, Func<string, RoDormitory.Item> creater)
			{
				item.Clear();
				foreach (KeyValuePair<string, int> keyValuePair in data)
				{
					string key = keyValuePair.Key;
					Dictionary<string, int>.Enumerator enumerator;
					KeyValuePair<string, int> keyValuePair2 = enumerator.Current;
					RoDormitory.Item item2 = creater(keyValuePair2.Key);
					KeyValuePair<string, int> keyValuePair3 = enumerator.Current;
					item.Add(key, new RoDormitory.InvenSlot(item2, keyValuePair3.Value));
				}
			}

			private void UpdateData(Dictionary<string, RoDormitory.InvenSlot> item, Dictionary<string, int> data, Func<string, RoDormitory.Item> creater)
			{
				if (item == null || data == null)
				{
					return;
				}
				foreach (KeyValuePair<string, int> keyValuePair in data)
				{
					string key = keyValuePair.Key;
					Dictionary<string, int>.Enumerator enumerator;
					KeyValuePair<string, int> keyValuePair2 = enumerator.Current;
					int value = keyValuePair2.Value;
					KeyValuePair<string, int> keyValuePair3 = enumerator.Current;
					if (item.ContainsKey(keyValuePair3.Key))
					{
						if (value > 0)
						{
							item[key].amount = value;
						}
						else
						{
							item.Remove(key);
						}
					}
					else if (value > 0)
					{
						item.Add(key, new RoDormitory.InvenSlot(creater(key), value));
					}
				}
			}

			public Dictionary<string, RoDormitory.InvenSlot> itemNormal;

			public Dictionary<string, RoDormitory.InvenSlot> itemAdvanced;

			public Dictionary<string, RoDormitory.InvenSlot> itemWallpaper;

			public Dictionary<string, RoDormitory.InvenSlot> costumeBody;

			public Dictionary<string, Dictionary<string, RoDormitory.Item>> costumeHead;

			private Action<Dictionary<string, int>>[] _SetData;

			private Action<Dictionary<string, int>>[] _UpdateData;
		}
	}
}
