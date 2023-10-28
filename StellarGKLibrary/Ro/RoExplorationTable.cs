using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Shared.Regulation;

public class RoExplorationTable : IEnumerable<RoExploration>, IEnumerable
{
	public void Init()
	{
		_dataRows = new List<RoExploration>();
		_indexMap = new Dictionary<string, int>();
		Regulation regulation = RemoteObjectManager.instance.regulation;
		for (int i = 0; i < regulation.explorationDtbl.length; i++)
		{
			ExplorationDataRow explorationDataRow = regulation.explorationDtbl[i];
			if (!_indexMap.ContainsKey(explorationDataRow.worldMap))
			{
				RoExploration roExploration = new RoExploration();
				roExploration.mapIdx = _dataRows.Count;
				roExploration.types.Add(explorationDataRow);
				int num = int.Parse(roExploration.mapID);
				roExploration.worldMap = RemoteObjectManager.instance.localUser.worldMapList[num];
				_indexMap.Add(explorationDataRow.worldMap, _dataRows.Count);
				_dataRows.Add(roExploration);
			}
			else
			{
				int num2 = _indexMap[explorationDataRow.worldMap];
				_dataRows[num2].types.Add(explorationDataRow);
			}
		}
	}

	public bool hasCompleteState
	{
		get
		{
			for (int i = 0; i < length; i++)
			{
				if (this[i].state == EExplorationState.Complete)
				{
					return true;
				}
			}
			return false;
		}
	}

	public RoExploration this[int index]
	{
		get
		{
			return _dataRows[index];
		}
	}

	public RoExploration this[string key]
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

	public IEnumerator<RoExploration> GetEnumerator()
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

	public void ForEach(Action<RoExploration> action)
	{
		_dataRows.ForEach(action);
	}

	public RoExploration Find(Predicate<RoExploration> match)
	{
		return _dataRows.Find(match);
	}

	public List<RoExploration> FindAll(Predicate<RoExploration> match)
	{
		return _dataRows.FindAll(match);
	}

	public void RemoveDispatchCommanders()
	{
		for (int i = 0; i < _dataRows.Count; i++)
		{
			_dataRows[i].RemoveDispatchCommanders();
		}
	}

	private List<RoExploration> _dataRows;

	private Dictionary<string, int> _indexMap;
}
