namespace StellarGKLibrary.Shared.Battle
{
    public class FrameAccessor
    {
        //public Simulator simulator { get; private set; }

        public Frame frame { get; private set; }

        public int unitIndex { get; private set; }

        public Unit unit { get; private set; }

        //public UnitDataRow unitDr { get; private set; }

        public int skillIndex { get; private set; }

        public Skill skill { get; private set; }

        //public SkillDataRow skillDr { get; private set; }

        //public UnitMotionDataRow unitMotionDr { get; private set; }

        public int firePointIndex { get; private set; }

        public int firePointSubIndex { get; private set; }

        public FirePoint firePoint { get; private set; }

        public int projectileIndex { get; private set; }

        public Projectile projectile { get; private set; }

        //public ProjectileDataRow projectileDr { get; private set; }

        public IList<int> statusEffectDrs { get; private set; }

        public int projectileMotionDuration { get; private set; }

        public int projectileFireTime { get; private set; }

        public int projectileHitTime { get; private set; }

        public int projectileHitDelayTime { get; private set; }

        public bool isMissedProjectile { get; private set; }

        //internal bool _AccessFrame(Simulator simulator, Frame frame)
        //{
        //	this.simulator = simulator;
        //	this.frame = frame;
        //	return this.OnFrameAccessStart();
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
        //	Regulation regulation = this.simulator.regulation;
        //	this.unitIndex = index;
        //	this.unit = unit;
        //	this.unitDr = regulation.unitDtbl[unit.dri];
        //	return this.OnUnitAccessStart();
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
        //	Regulation regulation = this.simulator.regulation;
        //	this.skillIndex = index;
        //	this.skill = skill;
        //	this.skillDr = regulation.skillDtbl[skill.dri];
        //	this.unitMotionDr = regulation.unitMotionDtbl[skill.unitMotionDri];
        //	this.projectileHitDelayTime = 0;
        //	if (skill.FireActionDr != null)
        //	{
        //		FireActionDataRow.TimeSet timeSet = skill.FireActionDr.GetTimeSet(this.simulator.CanEnableFireAction(this.unit));
        //		this.projectileHitDelayTime = timeSet.hitDelayTime;
        //	}
        //	return this.OnSkillAccessStart();
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
        //	Regulation regulation = this.simulator.regulation;
        //	this.firePointIndex = index;
        //	this.firePointSubIndex = firePoint.subIdx;
        //	this.firePoint = firePoint;
        //	this.projectileDr = regulation.projectileDtbl[firePoint.projectileDri];
        //	this.statusEffectDrs = firePoint.statusEffectDris;
        //	return this.OnFirePointAccessStart();
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
        //	Regulation regulation = this.simulator.regulation;
        //	DataTable<ProjectileMotionPhaseDataRow> projectileMotionPhaseDtbl = regulation.projectileMotionPhaseDtbl;
        //	int num = projectile.id / 100000;
        //	int num2 = projectile.id % 10000;
        //	ProjectileMotionPhaseDataRow projectileMotionPhaseDataRow = projectileMotionPhaseDtbl[num];
        //	ProjectileMotionPhaseDataRow projectileMotionPhaseDataRow2 = projectileMotionPhaseDtbl[num2];
        //	this.projectileIndex = index;
        //	this.projectile = projectile;
        //	this.projectileMotionDuration = projectileMotionPhaseDataRow.duration + projectileMotionPhaseDataRow2.duration + this.projectileHitDelayTime;
        //	this.projectileFireTime = projectileMotionPhaseDataRow.eventTime;
        //	this.projectileHitTime = projectileMotionPhaseDataRow.eventTime + projectileMotionPhaseDataRow2.eventTime + this.projectileHitDelayTime;
        //	string text = projectileMotionPhaseDataRow2.key.Split(new char[] { '/' })[1];
        //	this.isMissedProjectile = text == "MissPhase";
        //	this.OnProjectileAccessStart();
        //}

        public virtual void OnProjectileAccessStart()
        {
        }

        public virtual void OnProjectileAccessEnd()
        {
        }
    }
}
