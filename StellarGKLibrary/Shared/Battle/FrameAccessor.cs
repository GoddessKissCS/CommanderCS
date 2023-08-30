namespace StellarGKLibrary.Shared.Battle
{
    public class FrameAccessor
    {
        //public Simulator simulator { get; set; }

        public Frame frame { get; set; }

        public int unitIndex { get; set; }

        public Unit unit { get; set; }

        //public UnitDataRow unitDr { get; set; }

        public int skillIndex { get; set; }

        public Skill skill { get; set; }

        //public SkillDataRow skillDr { get; set; }

        //public UnitMotionDataRow unitMotionDr { get; set; }

        public int firePointIndex { get; set; }

        public int firePointSubIndex { get; set; }

        public FirePoint firePoint { get; set; }

        public int projectileIndex { get; set; }

        public Projectile projectile { get; set; }

        //public ProjectileDataRow projectileDr { get; set; }

        public IList<int> statusEffectDrs { get; set; }

        public int projectileMotionDuration { get; set; }

        public int projectileFireTime { get; set; }

        public int projectileHitTime { get; set; }

        public int projectileHitDelayTime { get; set; }

        public bool isMissedProjectile { get; set; }

        //internal bool _AccessFrame(Simulator simulator, Frame frame)
        //{
        //	simulator = simulator;
        //	frame = frame;
        //	return OnFrameAccessStart();
        //}

        public virtual bool OnFrameAccessStart()
        {
            return true;
        }

        public virtual void OnFrameAccessEnd()
        {
        }

        //internal bool _AccessUnit(int index, Unit unit)
        //{
        //	Regulation regulation = simulator.regulation;
        //	unitIndex = index;
        //	unit = unit;
        //	unitDr = regulation.unitDtbl[unit.dri];
        //	return OnUnitAccessStart();
        //}

        public virtual bool OnUnitAccessStart()
        {
            return true;
        }

        public virtual void OnUnitAccessEnd()
        {
        }

        //internal bool _AccessSkill(int index, Skill skill)
        //{
        //	Regulation regulation = simulator.regulation;
        //	skillIndex = index;
        //	skill = skill;
        //	skillDr = regulation.skillDtbl[skill.dri];
        //	unitMotionDr = regulation.unitMotionDtbl[skill.unitMotionDri];
        //	projectileHitDelayTime = 0;
        //	if (skill.FireActionDr != null)
        //	{
        //		FireActionDataRow.TimeSet timeSet = skill.FireActionDr.GetTimeSet(simulator.CanEnableFireAction(unit));
        //		projectileHitDelayTime = timeSet.hitDelayTime;
        //	}
        //	return OnSkillAccessStart();
        //}

        public virtual bool OnSkillAccessStart()
        {
            return true;
        }

        public virtual void OnSkillAccessEnd()
        {
        }

        //internal bool _AccessFirePoint(int index, FirePoint firePoint)
        //{
        //	Regulation regulation = simulator.regulation;
        //	firePointIndex = index;
        //	firePointSubIndex = firePoint.subIdx;
        //	firePoint = firePoint;
        //	projectileDr = regulation.projectileDtbl[firePoint.projectileDri];
        //	statusEffectDrs = firePoint.statusEffectDris;
        //	return OnFirePointAccessStart();
        //}

        public virtual bool OnFirePointAccessStart()
        {
            return true;
        }

        public virtual void OnFirePointAccessEnd()
        {
        }

        //internal void _AccessProjectile(int index, Projectile projectile)
        //{
        //	Regulation regulation = simulator.regulation;
        //	DataTable<ProjectileMotionPhaseDataRow> projectileMotionPhaseDtbl = regulation.projectileMotionPhaseDtbl;
        //	int num = projectile.id / 100000;
        //	int num2 = projectile.id % 10000;
        //	ProjectileMotionPhaseDataRow projectileMotionPhaseDataRow = projectileMotionPhaseDtbl[num];
        //	ProjectileMotionPhaseDataRow projectileMotionPhaseDataRow2 = projectileMotionPhaseDtbl[num2];
        //	projectileIndex = index;
        //	projectile = projectile;
        //	projectileMotionDuration = projectileMotionPhaseDataRow.duration + projectileMotionPhaseDataRow2.duration + projectileHitDelayTime;
        //	projectileFireTime = projectileMotionPhaseDataRow.eventTime;
        //	projectileHitTime = projectileMotionPhaseDataRow.eventTime + projectileMotionPhaseDataRow2.eventTime + projectileHitDelayTime;
        //	string text = projectileMotionPhaseDataRow2.key.Split(new char[] { '/' })[1];
        //	isMissedProjectile = text == "MissPhase";
        //	OnProjectileAccessStart();
        //}

        public virtual void OnProjectileAccessStart()
        {
        }

        public virtual void OnProjectileAccessEnd()
        {
        }
    }
}
