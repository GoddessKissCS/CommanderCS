namespace CommanderCSLibrary.Shared.Battle.Internal
{
    public class _StatusEffectCleaner : FrameAccessor
    {
        internal _StatusEffectCleaner()
        {
        }

        public override bool OnUnitAccessStart()
        {
            unit._playingActionIndex = -1;
            unit._takenDamage = 0L;
            unit._takenCriticalDamage = 0L;
            unit._takenHealing = 0L;
            unit._takenCriticalHealing = 0L;
            unit._takenDamageRecovery = 0L;
            unit._dealtDamage = 0L;
            unit._takenRevival = false;
            unit._avoidanceCount = 0;
            return false;
        }
    }
}