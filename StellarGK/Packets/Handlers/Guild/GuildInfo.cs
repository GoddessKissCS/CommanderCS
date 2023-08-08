namespace StellarGK.Host.Handlers.Guild
{
    [Command(Id = CommandId.GuildInfo)]
    public class GuildInfo : BaseCommandHandler<GuildInfoRequest>
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
