using StellarGK.Logic.Enums;

namespace StellarGK.Logic.Protocols
{
    public class NavigatorInfo
    {
        public NavigatorInfo(ENavigatorType type, int position)
        {
            this.type = type;
            stageIdx = position;
        }

        public ENavigatorType type;

        public int stageIdx;
    }
}
