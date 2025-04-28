namespace CommanderCS.Library.Shared.Regulation.DataRows
{
    [Serializable]
    public class SkillDamagePatternTable
    {
        private Dictionary<int, SkillDamagePattern> _datas;

        public void Init(Regulation rg)
        {
            _datas = new Dictionary<int, SkillDamagePattern>();
            for (int i = 0; i < rg.skillDamagePatternDtbl.length; i++)
            {
                SkillDamagePatternDataRow skillDamagePatternDataRow = rg.skillDamagePatternDtbl[i];
                if (!_datas.ContainsKey(skillDamagePatternDataRow.key))
                {
                    _datas.Add(skillDamagePatternDataRow.key, new SkillDamagePattern());
                }
                _datas[skillDamagePatternDataRow.key].Add(skillDamagePatternDataRow);
            }
        }

        public SkillDamagePattern Get(int key)
        {
            if (!_datas.ContainsKey(key))
            {
                return null;
            }
            return _datas[key];
        }

        public SkillDamagePatternDataRow Get(int key, int hpRate)
        {
            return Get(key)?.Get(hpRate);
        }
    }
}