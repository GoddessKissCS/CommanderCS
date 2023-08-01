namespace StellarGK.Host.Handlers.UserTerm
{
    [Command(Id = CommandId.CheckChangeDeviceCode)]
    public class CheckChangeDeviceCode : BaseCommandHandler<CheckChangeDeviceCodeRequest>
    {

        public override string Handle(CheckChangeDeviceCodeRequest @params)
        {
            return "{}";
        }

    }
    public class CheckChangeDeviceCodeRequest { }

}
