using System;

namespace BattleSimulator.Battle.Internal
{
	public class _StatusEffectCleaner : FrameAccessor
	{
		internal _StatusEffectCleaner()
		{
		}

		public override bool OnUnitAccessStart()
		{
			base.unit._playingActionIndex = -1;
			base.unit._takenDamage = 0L;
			base.unit._takenCriticalDamage = 0L;
			base.unit._takenHealing = 0L;
			base.unit._takenCriticalHealing = 0L;
			base.unit._takenDamageRecovery = 0L;
			base.unit._dealtDamage = 0L;
			base.unit._takenRevival = false;
			base.unit._avoidanceCount = 0;
			return false;
		}
	}
}
