using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CommanderCS.Packets.Handlers.Guild
{

    [Packet(Id = Method.GetGuildRanking)]
    public class GetGuildRanking : BaseMethodHandler<GetGuildRankingRequest>
    {
        public override object Handle(GetGuildRankingRequest @params)
        {
            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = true,
            };

			List<CommanderCSLibrary.Shared.Protocols.GuildRankingInfo> test = [];

			response.Result = test;

            return response;
        }
    }
	public class GetGuildRankingRequest
	{
		[JsonProperty("type")]
		public int type { get; set; }
	}
}

/*	// Token: 0x06006084 RID: 24708 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7515", true, true)]
	public void GetGuildRanking(int type)
	{
	}

	// Token: 0x06006085 RID: 24709 RVA: 0x001B0708 File Offset: 0x001AE908
	private IEnumerator GetGuildRankingResult(JsonRpcClient.Request request, List<Protocols.GuildRankingInfo> result)
	{
		int num = int.Parse(this._FindRequestProperty(request, "type"));
		if (UIManager.instance.world.guild.isActive)
		{
			UIManager.instance.world.guild.CreateConquestHistoryPopup(num, result);
		}
		yield break;
	}*/