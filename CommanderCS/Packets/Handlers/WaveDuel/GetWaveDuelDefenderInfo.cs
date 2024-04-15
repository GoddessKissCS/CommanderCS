using CommanderCS.Host;
using CommanderCSLibrary.Shared.Enum;

namespace CommanderCS.Packets.Handlers.WaveDuel
{
    [Packet(Id = Method.GetWaveDuelDefenderInfo)]
    public class GetWaveDuelDefenderInfo : BaseMethodHandler<GetWaveDuelDefenderInfoRequest>
    {
        public override object Handle(GetWaveDuelDefenderInfoRequest @params)
        {
            var user = GetUserGameProfile();

            GetWaveDuelDefenderInfoResponse defenderInfoResponse = new() { decks = user.DefenderDeck.WaveDuelDefenderDecks };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = defenderInfoResponse
            };

            return response;
        }
    }

    public class GetWaveDuelDefenderInfoResponse
    {
        public Dictionary<string, Dictionary<string, string>> decks { get; set; }
    }

    public class GetWaveDuelDefenderInfoRequest
    {
    }
}