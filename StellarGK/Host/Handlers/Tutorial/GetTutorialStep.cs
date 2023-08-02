using StellarGK.Database;
using StellarGK.Logic.Protocols;


namespace StellarGK.Host.Handlers.Tutorial
{
    [Command(Id = CommandId.GetTutorialStep)]
    public class GetTutorialStep : BaseCommandHandler<GetTutorialStepRequest>
    {

        public override object Handle(GetTutorialStepRequest @params)
        {
            UserInformationResponse.TutorialData TData = RequestTutorialData(BasePacket.Session);

            TutorialStep tutorialStep = new()
            {
                ttrl = TData
            };

            ResponsePacket response = new()
            {
                result = tutorialStep,
                id = BasePacket.Id
            };

            return response;
        }


        private static UserInformationResponse.TutorialData RequestTutorialData(string sess)
        {
            var user = DatabaseManager.Account.FindBySession(sess);

            return new UserInformationResponse.TutorialData() { skip = user.skip, step = user.step };
        }

        public class TutorialStep
        {
            public UserInformationResponse.TutorialData ttrl { get; set; }
        }
    }

    public class GetTutorialStepRequest
    {

    }
}