using StellarGKLibrary.Enums;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonConverter(typeof(DataTableConverter))]
	[Serializable]
	public class DataTable<T> : IEnumerable<T>, IEnumerable where T : DataRow
	{
		public DataTable(JsonSerializer serializer, JsonReader reader)
		{
			_dataRows = serializer.Deserialize<List<T>>(reader);
			_indexMap = new Dictionary<string, int>();
			int num = -1;
			try
			{
				for (int i = 0; i < _dataRows.Count; i++)
				{
					num = i;
					Dictionary<string, int> indexMap = _indexMap;
					T t = _dataRows[i];
					indexMap.Add(t.GetKey(), i);
				}
			}
			catch (Exception ex)
			{
				object[] array = new object[6];
				array[0] = "throw : ";
				int num2 = 1;
				T t2 = _dataRows[num];
				array[num2] = t2.GetType().Name;
				array[2] = " ";
				int num3 = 3;
				T t3 = _dataRows[num];
				array[num3] = t3.GetKey();
				array[4] = " index:";
				array[5] = num;
			}
		}

		public T this[int index]
		{
			get
			{
				return _dataRows[index];
			}
		}

		public T this[string key]
		{
			get
			{
				return _dataRows[FindIndex(key)];
			}
		}

		public int length
		{
			get
			{
				return _dataRows.Count;
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _dataRows.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public bool ContainsKey(string key)
		{
			return FindIndex(key) >= 0;
		}

		public bool ContainsKey(int key)
		{
			return FindIndex(key.ToString()) >= 0;
		}

		public int FindIndex(string key)
		{
			int num;
			if (!_indexMap.TryGetValue(key, out num))
			{
				return -1;
			}
			return num;
		}

		public bool IsValidIndex(int idx)
		{
			return idx >= 0 && idx < _dataRows.Count;
		}

		public JArray ToJsonArray()
		{
			return JArray.FromObject(_dataRows);
		}

		public void ForEach(Action<T> action)
		{
			_dataRows.ForEach(action);
		}

		public T Find(Predicate<T> match)
		{
			return _dataRows.Find(match);
		}

		public List<T> FindAll(Predicate<T> match)
		{
			return _dataRows.FindAll(match);
		}

		private List<T> _dataRows;

		private Dictionary<string, int> _indexMap;
	}
}
