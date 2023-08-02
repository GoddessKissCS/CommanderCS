using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Carnival
{
    [Command(Id = CommandId.GetCarnivalList)]
    public class GetCarnivalList : BaseCommandHandler<GetCarnivalListRequest>
    {

        public override object Handle(GetCarnivalListRequest @params)
        {

            GetCarnivalListRes CL = new GetCarnivalListRes();

            CarnivalList CLlist = new CarnivalList();

            Dictionary<string, CarnivalList.CarnivaTime> carnivalList = new Dictionary<string, CarnivalList.CarnivaTime>();
            Dictionary<string, Dictionary<string, CarnivalList.ProcessData>> carnivalProcessList = new Dictionary<string, Dictionary<string, CarnivalList.ProcessData>>();
            List<RewardInfo.RewardData> rewardList = new List<RewardInfo.RewardData>();

            return "{}";
        }


        public class GetCarnivalListRes
        {
            public string id { get; set; }

            public CarnivalList result { get; set; }
        }
    }

    public class GetCarnivalListRequest
    {
        public int cctype { get; set; }

        public int eidx { get; set; }
    }
}