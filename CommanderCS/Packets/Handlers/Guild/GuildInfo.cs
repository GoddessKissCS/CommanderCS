using CommanderCS.Library.Enums;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;
using System.Collections;

namespace CommanderCS.Packets.Handlers.Guild
{
    [Packet(Id = Method.GuildInfo)]
    public class GuildInfo : BaseMethodHandler<GuildInfoRequest>
    {
        public override object Handle(GuildInfoRequest request)
        {
            GameProfileScheme User = GetUserGameProfile();

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = DatabaseGetUserInformationResponse(User),
            };

            return response;
        }
    }

    public class GuildInfoRequest
    {
        [JsonProperty("type")]
        public List<string> Type { get; set; }
    }
}

/*

[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "1101", true, true)]
public void GuildInfo(List<string> type)
{
}

// Token: 0x0600279C RID: 10140 RVA: 0x0002504D File Offset: 0x0002324D
private IEnumerator GuildInfoResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
{
    bool flag = result == null || !this.localUser.IsExistGuild();
    if (flag)
    {
        this.RequestGuildList();
    }
    else
    {
        this.localUser.FromNetwork(result);
    }
    yield break;
}

*/