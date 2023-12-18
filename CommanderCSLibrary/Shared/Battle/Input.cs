using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Battle;

[JsonObject(MemberSerialization.OptIn)]
public class Input
{
    [JsonProperty("uidx")]
    internal int _unitIndex;

    [JsonProperty("sidx")]
    internal int _skillIndex;

    [JsonProperty("tidx")]
    internal int _targetIndex;

    [JsonIgnore]
    internal bool _result;

    public int unitIndex => _unitIndex;

    public int skillIndex => _skillIndex;

    public int targetIndex => _targetIndex;

    public bool result => _result;

    internal Input()
    {
    }

    public Input(int unitIndex, int skillIndex, int targetIndex)
    {
        _unitIndex = unitIndex;
        _skillIndex = skillIndex;
        _targetIndex = targetIndex;
        _result = false;
    }

    public static Input Copy(Input src)
    {
        Input input = new()
        {
            _unitIndex = src._unitIndex,
            _skillIndex = src._skillIndex,
            _targetIndex = src._targetIndex,
            _result = src._result
        };

        return input;
    }

    public static bool IsSame(Input f1, Input f2)
    {
        if (f1 == f2)
        {
            return true;
        }
        if (f1.unitIndex != f2.unitIndex)
        {
            return false;
        }
        if (f1.skillIndex != f2.skillIndex)
        {
            return false;
        }
        if (f1.targetIndex != f2.targetIndex)
        {
            return false;
        }
        if (f1._result != f2._result)
        {
            return false;
        }
        return true;
    }
}