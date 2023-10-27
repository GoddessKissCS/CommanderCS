using System;
using Newtonsoft.Json;
using Shared.Regulation;

[JsonObject]
public class RoPart
{
	public static RoPart Create(string id, int count)
	{
		return new RoPart
		{
			id = id,
			count = count,
			nameIdx = RemoteObjectManager.instance.regulation.partDtbl.Find((PartDataRow row) => row.type == id).name,
			descriptionIdx = RemoteObjectManager.instance.regulation.partDtbl.Find((PartDataRow row) => row.type == id).description
		};
	}

	public PartDataRow GetPartData()
	{
		return RemoteObjectManager.instance.regulation.partDtbl.Find((PartDataRow row) => row.type == id);
	}

	public int count;

	public string id;

	public string nameIdx;

	public string descriptionIdx;
}
