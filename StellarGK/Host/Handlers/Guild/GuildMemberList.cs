namespace StellarGK.Host.Handlers.Guild
{
    [Command(Id = CommandId.GuildMemberList)]
    public class GuildMemberList : BaseCommandHandler<GuildMemberListRequest>
    {
        public override object Handle(GuildMemberListRequest @params)
        {
            return "{}";
        }
    }
    public class GuildMemberListRequest
    {

    }
}
