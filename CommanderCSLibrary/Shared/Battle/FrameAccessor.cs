using CommanderCSLibrary.Shared.Regulation;
using CommanderCSLibrary.Shared.Regulation.DataRows;

namespace CommanderCSLibrary.Shared.Battle
{
    public class FrameAccessor
    {
        public Simulator simulator { get; private set; }

        public Frame frame { get; private set; }

        public int unitIndex { get; private set; }

        public Unit unit { get; private set; }

        public UnitDataRow unitDr { get; private set; }

        public int skillIndex { get; private set; }

        public Skill skill { get; private set; }

        public SkillDataRow skillDr { get; private set; }

        public UnitMotionDataRow unitMotionDr { get; private set; }

        public int firePointIndex { get; private set; }

        public int firePointSubIndex { get; private set; }

        public FirePoint firePoint { get; private set; }

        public int projectileIndex { get; private set; }

        public Projectile projectile { get; private set; }

        public ProjectileDataRow projectileDr { get; private set; }

        public IList<int> statusEffectDrs { get; private set; }

        public int projectileMotionDuration { get; private set; }

        public int projectileFireTime { get; private set; }

        public int projectileHitTime { get; private set; }

        public int projectileHitDelayTime { get; private set; }

        public bool isMissedProjectile { get; private set; }

        internal bool _AccessFrame(Simulator simulator, Frame frame)
        {
            this.simulator = simulator;
            this.frame = frame;
            return OnFrameAccessStart();
        }

        public virtual bool OnFrameAccessStart()
        {
            return true;
        }

        public virtual void OnFrameAccessEnd()
        {
        }

        internal bool _AccessUnit(int index, Unit unit)
        {
            Regulation.Regulation regulation = simulator.regulation;
            unitIndex = index;
            this.unit = unit;
            unitDr = regulation.unitDtbl[unit.dri];
            return OnUnitAccessStart();
        }

        public virtual bool OnUnitAccessStart()
        {
            return true;
        }

        public virtual void OnUnitAccessEnd()
        {
        }

        internal bool _AccessSkill(int index, Skill skill)
        {
            Regulation.Regulation regulation = simulator.regulation;
            skillIndex = index;
            this.skill = skill;
            skillDr = regulation.skillDtbl[skill.dri];
            unitMotionDr = regulation.unitMotionDtbl[skill.unitMotionDri];
            projectileHitDelayTime = 0;
            if (skill.FireActionDr is not null)
            {
                FireActionDataRow.TimeSet timeSet = skill.FireActionDr.GetTimeSet(simulator.CanEnableFireAction(unit));
                projectileHitDelayTime = timeSet.hitDelayTime;
            }
            return OnSkillAccessStart();
        }

        public virtual bool OnSkillAccessStart()
        {
            return true;
        }

        public virtual void OnSkillAccessEnd()
        {
        }

        internal bool _AccessFirePoint(int index, FirePoint firePoint)
        {
            Regulation.Regulation regulation = simulator.regulation;
            firePointIndex = index;
            firePointSubIndex = firePoint.subIdx;
            this.firePoint = firePoint;
            projectileDr = regulation.projectileDtbl[firePoint.projectileDri];
            statusEffectDrs = firePoint.statusEffectDris;
            return OnFirePointAccessStart();
        }

        public virtual bool OnFirePointAccessStart()
        {
            return true;
        }

        public virtual void OnFirePointAccessEnd()
        {
        }

        internal void _AccessProjectile(int index, Projectile projectile)
        {
            Regulation.Regulation regulation = simulator.regulation;
            DataTable<ProjectileMotionPhaseDataRow> projectileMotionPhaseDtbl = regulation.projectileMotionPhaseDtbl;
            int index2 = projectile.id / 100000;
            int index3 = projectile.id % 10000;
            ProjectileMotionPhaseDataRow projectileMotionPhaseDataRow = projectileMotionPhaseDtbl[index2];
            ProjectileMotionPhaseDataRow projectileMotionPhaseDataRow2 = projectileMotionPhaseDtbl[index3];
            projectileIndex = index;
            this.projectile = projectile;
            projectileMotionDuration = projectileMotionPhaseDataRow.duration + projectileMotionPhaseDataRow2.duration + projectileHitDelayTime;
            projectileFireTime = projectileMotionPhaseDataRow.eventTime;
            projectileHitTime = projectileMotionPhaseDataRow.eventTime + projectileMotionPhaseDataRow2.eventTime + projectileHitDelayTime;
            string text = projectileMotionPhaseDataRow2.key.Split('/')[1];
            isMissedProjectile = text == "MissPhase";
            OnProjectileAccessStart();
        }

        public virtual void OnProjectileAccessStart()
        {
        }

        public virtual void OnProjectileAccessEnd()
        {
        }
    }
}