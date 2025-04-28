using CommanderCS.Library.Shared.Enum;

namespace CommanderCS.Library.Shared.Protocols
{
    public class NavigatorInfo
    {
        public NavigatorInfo(ENavigatorType type, int position)
        {
            type = type;
            stageIdx = position;
        }

        public ENavigatorType type { get; set; }

        public int stageIdx { get; set; }
    }
}