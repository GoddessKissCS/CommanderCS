
namespace CommanderCSLibrary.Shared.Battle.Internal;

public class _SkillInitializer : FrameAccessor
{
	private Random _random;

	private Shared.Regulation.Regulation _reg;

	internal _SkillInitializer(Random random)
	{
		_random = random;
	}

	public override bool OnFrameAccessStart()
	{
		_reg = base.simulator.regulation;
		return true;
	}

	public override bool OnSkillAccessStart()
	{
		if (base.simulator.option.playMode == Option.PlayMode.RealTime && base.skillIndex == 0)
		{
			base.skill._sp = _random.Next(0, base.skillDr.maxSp);
		}
		return false;
	}
}
