using System;
using System.Collections.Generic;
using Shared.Regulation;

public class RoExploration
{
	public RoExploration()
	{
		idx = 0;
		_state = EExplorationState.Idle;
		commanders = new List<RoCommander>();
		types = new List<ExplorationDataRow>();
	}

	public string mapID
	{
		get
		{
			return Dr.worldMap;
		}
	}

	public ExplorationDataRow Dr
	{
		get
		{
			return types[idx];
		}
	}

	public EExplorationState state
	{
		get
		{
			if (_state == EExplorationState.Exploring && data.remainTime == 0.0)
			{
				_state = EExplorationState.Complete;
			}
			return _state;
		}
		set
		{
			if (_state == value)
			{
				return;
			}
			_state = value;
			if (_state == EExplorationState.Complete && OnComplete != null)
			{
				OnComplete();
			}
		}
	}

	public bool isOpen
	{
		get
		{
			int num = int.Parse(mapID);
			int num2 = (RemoteObjectManager.instance.localUser.lastClearStage - ConstValue.tutorialMaximumStage) / 20;
			return num2 >= num;
		}
	}

	public string mapName
	{
		get
		{
			return worldMap.name;
		}
	}

	public void Set(Protocols.ExplorationData info)
	{
		if (data != null)
		{
			for (int i = 0; i < commanders.Count; i++)
			{
				commanders[i].isExploration = false;
			}
		}
		data = info;
		if (data != null)
		{
			commanders = new List<RoCommander>();
			if (data.remainTime > 0.0)
			{
				_state = EExplorationState.Exploring;
			}
			else
			{
				_state = EExplorationState.Complete;
			}
			for (int j = 0; j < data.cids.Count; j++)
			{
				RoCommander roCommander = RemoteObjectManager.instance.localUser.FindCommander(data.cids[j]);
				if (roCommander != null)
				{
					roCommander.isExploration = true;
					commanders.Add(roCommander);
				}
			}
			idx = types.FindIndex((ExplorationDataRow x) => x.idx == info.idx);
		}
		else
		{
			_state = EExplorationState.Idle;
			for (int k = 0; k < commanders.Count; k++)
			{
				commanders[k].isExploration = false;
			}
		}
	}

	public void RemoveDispatchCommanders()
	{
		if (_state != EExplorationState.Idle)
		{
			return;
		}
		List<RoCommander> list = new List<RoCommander>();
		for (int i = 0; i < commanders.Count; i++)
		{
			if (!commanders[i].isDispatch)
			{
				list.Add(commanders[i]);
			}
		}
		commanders = list;
	}

	public void RemoveCommander(RoCommander target)
	{
		if (state != EExplorationState.Idle)
		{
			return;
		}
		int num = commanders.FindIndex((RoCommander commander) => commander.id == target.id);
		if (num < 0)
		{
			return;
		}
		commanders.RemoveAt(num);
	}

	public void RemoveCommanders(List<RoCommander> target)
	{
		if (target == null)
		{
			return;
		}
		if (state != EExplorationState.Idle)
		{
			return;
		}
		for (int i = 0; i < target.Count; i++)
		{
			RemoveCommander(target[i]);
		}
	}

	public int mapIdx;

	public int idx;

	private EExplorationState _state;

	public Protocols.ExplorationData data;

	public RoWorldMap worldMap;

	public List<RoCommander> commanders;

	public List<ExplorationDataRow> types;

	public Action OnComplete;
}
