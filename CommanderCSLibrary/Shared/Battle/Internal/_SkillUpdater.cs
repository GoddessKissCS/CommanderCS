using CommanderCSLibrary.Shared.Regulation;
using CommanderCSLibrary.Shared.Regulation.DataRows;

namespace CommanderCSLibrary.Shared.Battle.Internal
{
    public class _SkillUpdater : FrameAccessor
    {
        private Random _random;

        private List<Projectile> _newProjectiles;

        private bool _subFireFirst;

        private bool _subFireSecond;

        private Regulation.Regulation _rg;

        internal _SkillUpdater()
        {
        }

        internal _SkillUpdater(Random random)
        {
            SetRandom(random);
        }

        public void SetRandom(Random random)
        {
            _random = random;
        }

        public override bool OnFrameAccessStart()
        {
            _rg = simulator.regulation;
            frame._hasSkillActionUnit = false;
            return true;
        }

        public override bool OnUnitAccessStart()
        {
            if (!frame.IsUnitInBattle(unitIndex))
            {
                return false;
            }
            unit._hasEnabledSkill = false;
            unit._isPlayingFire = false;
            _subFireFirst = false;
            _subFireSecond = false;
            return true;
        }

        public override bool OnSkillAccessStart()
        {
            _subFireFirst = false;
            _subFireSecond = false;
            int num = skill._sp - skill._curSp;
            if (num > 0)
            {
                skill._curSp += skill._perCurSp;
                if (skill._curSp > skill._sp)
                {
                    skill._curSp = skill._sp;
                }
            }
            else if (num < 0)
            {
                skill._curSp -= skill._perCurSp;
                if (skill._curSp < skill._sp)
                {
                    skill._curSp = skill._sp;
                }
            }
            if (skill._curSp == skill._sp)
            {
                skill._activeState = true;
                if (skillIndex > 0)
                {
                    unit._hasEnabledSkill = true;
                }
            }
            if (skill._remainedReturnMotionTime > 0)
            {
                frame._isWaitingNextTurn = false;
                skill._remainedReturnMotionTime -= 66;
                unit._playingActionIndex = skillIndex;
            }
            if (skill.remainedMotionTime > 0)
            {
                if (skill._initMotionTime == skill.remainedMotionTime)
                {
                    _subFireFirst = true;
                }
                frame._isWaitingNextWave = false;
                frame._isWaitingNextTurn = false;
                if (unit.isDead)
                {
                    if (!skill.isIgnoreDeathType)
                    {
                        skill._remainedMotionTime = 0;
                        return false;
                    }
                }
                else
                {
                    if (unit.isStatusStun)
                    {
                        skill._remainedMotionTime = 0;
                        return false;
                    }
                    if (unit.isStatusSilence && skillIndex != 0)
                    {
                        skill._remainedMotionTime = 0;
                        return false;
                    }
                }
                skill._remainedMotionTime -= 66;
                unit._playingActionIndex = skillIndex;
                return true;
            }
            return false;
        }

        public bool OnMainFirePointAccessStart()
        {
            int num = skill.remainedMotionTime + 66;
            for (int i = 0; i < 20; i++)
            {
                FireEvent fireEvent = unitMotionDr.fireEvents[i];
                if (fireEvent is null)
                {
                    break;
                }
                if (fireEvent.firePointTypeIndex != firePointIndex)
                {
                    continue;
                }
                int num2 = unitMotionDr.playTime - fireEvent.time;
                if (num2 >= num)
                {
                    continue;
                }
                if (num2 < skill.remainedMotionTime)
                {
                    if (skill.isActiveSkill)
                    {
                        frame._hasSkillActionUnit = true;
                    }
                    if (i == 0)
                    {
                        unit._isPlayingFire = true;
                    }
                    continue;
                }
                if (i + 1 == unitMotionDr.totalFireCount)
                {
                    _subFireSecond = true;
                }
                if (skill.isActiveSkill)
                {
                    frame._hasSkillActionUnit = true;
                }
                if (i == 0)
                {
                    unit._isPlayingFire = true;
                }
                if (skill.targetIndex < 0)
                {
                    continue;
                }
                Projectile item = _CreateProjectile(i, skill.targetIndex);
                _ApplyFirePattern(item, skillDr.firePatterns[firePointIndex]);
                List<Projectile> list = _CreateSplashes(item, projectileDr.splashPattern);
                _newProjectiles.Add(item);
                foreach (Projectile item2 in list)
                {
                    _newProjectiles.Add(item2);
                }
            }
            return false;
        }

        public bool OnSubFirePointAccessStart()
        {
            bool result = false;
            if (_subFireFirst && firePointSubIndex == 1)
            {
                int num = frame.FindSkillTarget(_rg, unitIndex, skillIndex, firePointSubIndex);
                if (num >= 0)
                {
                    Projectile item = _CreateProjectile(0, num);
                    _ApplyFirePattern(item, firePoint.firePattern);
                    List<Projectile> list = _CreateSplashes(item, projectileDr.splashPattern);
                    _newProjectiles.Add(item);
                    foreach (Projectile item3 in list)
                    {
                        _newProjectiles.Add(item3);
                    }
                    result = true;
                }
            }
            if (_subFireSecond && firePointSubIndex == 2)
            {
                int num2 = frame.FindSkillTarget(_rg, unitIndex, skillIndex, firePointSubIndex);
                if (num2 >= 0)
                {
                    Projectile item2 = _CreateProjectile(0, num2);
                    _ApplyFirePattern(item2, firePoint.firePattern);
                    List<Projectile> list2 = _CreateSplashes(item2, projectileDr.splashPattern);
                    _newProjectiles.Add(item2);
                    foreach (Projectile item4 in list2)
                    {
                        _newProjectiles.Add(item4);
                    }
                    result = true;
                }
            }
            return result;
        }

        public override bool OnFirePointAccessStart()
        {
            _newProjectiles = [];
            if (firePointSubIndex != 0)
            {
                return OnSubFirePointAccessStart();
            }
            return OnMainFirePointAccessStart();
        }

        public override void OnFirePointAccessEnd()
        {
            if (_newProjectiles is not null && _newProjectiles.Count != 0)
            {
                firePoint._projectiles.AddRange(_newProjectiles);
            }
        }

        private Projectile _CreateProjectile(int fireEventIndex, int targetIndex)
        {
            bool flag = false;
            if (skillDr.targetJobType != 0)
            {
                Unit unit = frame._units[targetIndex];
                UnitDataRow unitDataRow = _rg.unitDtbl[unit.dri];
                flag = !Skill.IsTargetJobType(unitDataRow.job, skillDr.targetJobType);
            }
            if (!flag)
            {
                if (skillDr.coercionAccuracy > 0)
                {
                    flag = skillDr.coercionAccuracy < _random.Next(1, 101);
                }
                else if (skill.isDamageSkill(firePointSubIndex))
                {
                    Unit unit2 = frame._units[targetIndex];
                    if (unit2._fixedEvasionRate > 0)
                    {
                        flag = unit2._fixedEvasionRate > _random.Next(0, 100);
                    }
                    else
                    {
                        int accuracy = skill.accuracy;
                        int accuracyScale = projectileDr.accuracyScale;
                        int num = (unit2.luck + unit2._addLuck) * (100 + unit2.luckBonus) / 100;
                        if (num < 0)
                        {
                            num = 0;
                        }
                        int num2 = accuracy + num;
                        if (num2 <= 0)
                        {
                            num2 = 1;
                        }
                        int num3 = accuracy * accuracyScale / num2;
                        flag = num3 < _random.Next(1, 101);
                    }
                }
            }
            string motionSetId = projectileDr.motionSetId;
            DataTable<ProjectileMotionPhaseDataRow> projectileMotionPhaseDtbl = _rg.projectileMotionPhaseDtbl;
            string text = motionSetId + "/FirePhase";
            int num4 = projectileMotionPhaseDtbl.FindIndex(text);
            if (num4 == -1)
            {
                throw new ArgumentException("projectileMotionPhaseDtbl Not Found Idx : " + text);
            }
            ProjectileMotionPhaseDataRow projectileMotionPhaseDataRow = projectileMotionPhaseDtbl[num4];
            num4 += _random.Next(0, projectileMotionPhaseDataRow.patternCount) + 1;
            string text2 = motionSetId + ((!flag) ? "/HitPhase" : "/MissPhase");
            int num5 = projectileMotionPhaseDtbl.FindIndex(text2);
            if (num5 == -1)
            {
                throw new ArgumentException("projectileMotionPhaseDtbl Not Found Idx : " + text2);
            }
            ProjectileMotionPhaseDataRow projectileMotionPhaseDataRow2 = projectileMotionPhaseDtbl[num5];
            num5 += _random.Next(0, projectileMotionPhaseDataRow2.patternCount) + 1;
            string key = motionSetId + "/BeHitPhase";
            int num6 = projectileMotionPhaseDtbl.FindIndex(key);
            if (num6 >= 0)
            {
                ProjectileMotionPhaseDataRow projectileMotionPhaseDataRow3 = projectileMotionPhaseDtbl[num6];
                num6 += _random.Next(0, projectileMotionPhaseDataRow3.patternCount) + 1;
            }
            int id = num4 * 100000 + num5;
            Projectile projectile = Projectile._Create(id, targetIndex, fireEventIndex, frame.turn);
            projectile._beHitId = num6;
            projectile._fireKey = projectileMotionPhaseDtbl[num4].key;
            projectile._hitKey = projectileMotionPhaseDtbl[num5].key;
            projectile._beHitKey = (num6 < 0) ? string.Empty : projectileMotionPhaseDtbl[num6].key;
            int criticalChance = skill.criticalChance;
            int criticalChanceScale = projectileDr.criticalChanceScale;
            int num7 = criticalChance * criticalChanceScale / 100;
            projectile._isCritical = num7 > _random.Next(0, 100);
            return projectile;
        }

        private void _ApplyFirePattern(Projectile projectile, string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                return;
            }
            List<int> list = [];
            int num = projectile.targetIndex;
            int num2 = pattern.IndexOf("P");
            if (num2 < 0)
            {
                num = ((!frame.IsLhsUnitInBattle(num)) ? (frame._rhsTroopStartIndex + 4) : (frame._lhsTroopStartIndex + 4));
                num2 = 4;
            }
            int num3 = num2 % 3;
            int num4 = num2 / 3;
            int num5 = Math.Min(9, pattern.Length);
            for (int i = 0; i < num5; i++)
            {
                if (pattern[i] != '1')
                {
                    continue;
                }
                int x = i % 3 - num3;
                int z = i / 3 - num4;
                int unitIndexByOffset = simulator.GetUnitIndexByOffset(num, x, z);
                if (unitIndexByOffset >= 0)
                {
                    Unit unit = simulator.frame._units[unitIndexByOffset];
                    if (unit is not null && unit.health > 0)
                    {
                        list.Add(unitIndexByOffset);
                    }
                }
            }
            if (list.Count > 0)
            {
                _random.Shuffle(list);
                projectile._targetIndex = list[0];
            }
        }

        private List<Projectile> _CreateSplashes(Projectile projectile, string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                return [];
            }
            List<Projectile> list = [];
            int num = projectile.targetIndex;
            int num2 = pattern.IndexOf("P");
            if (num2 < 0)
            {
                num = ((!frame.IsLhsUnitInBattle(num)) ? (frame._rhsTroopStartIndex + 4) : (frame._lhsTroopStartIndex + 4));
                num2 = 12;
            }
            int num3 = num2 % 5;
            int num4 = num2 / 5;
            int length = pattern.Length;
            for (int i = 0; i < length; i++)
            {
                if (pattern[i] != '1')
                {
                    continue;
                }
                int x = i % 5 - num3;
                int z = i / 5 - num4;
                int unitIndexByOffset = simulator.GetUnitIndexByOffset(num, x, z);
                if (unitIndexByOffset >= 0 && projectile.targetIndex != unitIndexByOffset)
                {
                    Unit unit = simulator.frame._units[unitIndexByOffset];
                    if (unit is not null && unit.health > 0)
                    {
                        Projectile projectile2 = _CreateProjectile(projectile.fireEventIndex, unitIndexByOffset);
                        projectile2._isSplash = true;
                        projectile2._targetIndex = unitIndexByOffset;
                        list.Add(projectile2);
                    }
                }
            }
            return list;
        }
    }
}