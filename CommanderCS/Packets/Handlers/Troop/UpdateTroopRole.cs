using CommanderCS.Host;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Troop
{
    [Packet(Id = CommanderCS.Library.Shared.Enum.Method.UpdateTroopRole)]
    public class UpdateTroopRole : BaseMethodHandler<UpdateTroopRoleRequest>
    {
        public override object Handle(UpdateTroopRoleRequest @params)
        {
            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = true,
            };

            return response;
        }
    }

    public class UpdateTroopRoleRequest
    {
        [JsonProperty("cid")]
        public int cid { get; set; }

        [JsonProperty("role")]
        public string role { get; set; }
    }
}

/*	// Token: 0x06005F8D RID: 24461 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "5219", true, true)]
	public void UpdateTroopRole(int cid, string role)
	{
	}

	// Token: 0x06005F8E RID: 24462 RVA: 0x001AF270 File Offset: 0x001AD470
	private IEnumerator UpdateTroopRoleResult(JsonRpcClient.Request request, bool result)
	{
		if (result)
		{
			string cid = this._FindRequestProperty(request, "cid");
			string role = this._FindRequestProperty(request, "role");
			this.localUser.commanderList.ForEach(delegate(RoCommander commander)
			{
				if (string.Equals(commander.role, role) || string.Equals(commander.id, cid))
				{
					commander.role = ((!commander.id.Equals(cid)) ? "N" : role);
				}
			});
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}*/