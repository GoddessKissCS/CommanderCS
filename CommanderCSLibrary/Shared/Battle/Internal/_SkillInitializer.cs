namespace CommanderCSLibrary.Shared.Battle.Internal
{
    public class _SkillInitializer : FrameAccessor
    {
        private Random _random;

        private Regulation.Regulation _reg;

        internal _SkillInitializer(Random random)
        {
            _random = random;
        }

        public override bool OnFrameAccessStart()
        {
            _reg = simulator.regulation;
            return true;
        }

        public override bool OnSkillAccessStart()
        {
            if (simulator.option.playMode == Option.PlayMode.RealTime && skillIndex == 0)
            {
                skill._sp = _random.Next(0, skillDr.maxSp);
            }
            return false;
        }
    }
}