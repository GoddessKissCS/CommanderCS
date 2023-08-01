namespace StellarGK.Host.Handlers.Guild
{
    [Command(Id = CommandId.GuildMemberList)]
    public class GuildMemberList : BaseCommandHandler<GuildMemberListRequest>
    {
        public override string Handle(GuildMemberListRequest @params)
        {
            throw new NotImplementedException();
        }
    }
    public class GuildMemberListRequest
    {

    }
}
