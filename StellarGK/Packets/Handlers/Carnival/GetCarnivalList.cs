using System.Text.Json.Serialization;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Carnival
{
    [Command(Id = CommandId.GetCarnivalList)]
    public class GetCarnivalList : BaseCommandHandler<GetCarnivalListRequest>
    {

        public override object Handle(GetCarnivalListRequest @params)
        {

            ResponsePacket response = new();

            CarnivalList CLlist = new CarnivalList();

            Dictionary<string, CarnivalList.CarnivaTime> carnivalList = new Dictionary<string, CarnivalList.CarnivaTime>();
            Dictionary<string, Dictionary<string, CarnivalList.ProcessData>> carnivalProcessList = new Dictionary<string, Dictionary<string, CarnivalList.ProcessData>>();
            List<RewardInfo.RewardData> rewardList = new List<RewardInfo.RewardData>();

            return "{}";
        }


    }

    public class GetCarnivalListRequest
    {
        [JsonPropertyName("cctype")]
        public int cctype { get; set; }
        [JsonPropertyName("eidx")]
        public int eidx { get; set; }
    }
}