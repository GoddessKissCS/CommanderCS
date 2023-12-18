using CommanderCSLibrary.Shared.Enum;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCSLibrary.Shared.Regulation;

[Serializable]
[JsonConverter(typeof(DataTableConverter))]
public class DataTable<T> : IEnumerable<T>, IEnumerable where T : DataRow
{
	private List<T> _dataRows;

	private Dictionary<string, int> _indexMap;

	public T this[int index] => _dataRows[index];

	public T this[string key] => _dataRows[FindIndex(key)];

	public int length => _dataRows.Count;

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
				_indexMap.Add(_dataRows[i].GetKey(), i);
			}
		}
		catch (Exception)
		{
			//Logger.Log("throw : " + _dataRows[num].GetType().Name + " " + _dataRows[num].GetKey() + " index:" + num);
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
		if (!_indexMap.TryGetValue(key, out var value))
		{
			return -1;
		}
		return value;
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
}
