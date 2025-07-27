namespace CommanderCS.Library.Packets.Structure
{
    public class GetWaveDuelDefenderInfoResponse
    {
        public Dictionary<string, Dictionary<string, string>> decks { get; set; }
    }

    public class GetWaveDuelDefenderInfoRequest
    {
    }
}