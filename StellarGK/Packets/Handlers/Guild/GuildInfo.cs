namespace StellarGK.Host.Handlers.Guild
{
    [Packet(Id = Method.GuildInfo)]
    public class GuildInfo : BaseMethodHandler<GuildInfoRequest>
    {
        public override object Handle(GuildInfoRequest @params)
        {
            return "{}";
        }
    }

    public class GuildInfoRequest
    {
    }
}