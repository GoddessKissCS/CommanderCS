using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Battle;

[JsonObject(MemberSerialization.OptIn)]
public class Projectile
{
	[JsonProperty]
	internal int _id;

	[JsonProperty]
	internal bool _isCritical;

	[JsonProperty]
	internal bool _isSplash;

	[JsonProperty]
	internal int _targetIndex;

	[JsonProperty]
	internal int _fireEventIndex;

	[JsonProperty]
	internal int _createdTurn;

	[JsonProperty]
	internal int _elapsedTime;

	[JsonProperty]
	internal int _beHitId;

	[JsonProperty]
	internal string _fireKey;

	[JsonProperty]
	internal string _hitKey;

	[JsonProperty]
	internal string _beHitKey;

	public int id => _id;

	public bool isCritical => _isCritical;

	public bool isSplash => _isSplash;

	public int targetIndex => _targetIndex;

	public int fireEventIndex => _fireEventIndex;

	public int createdTurn => _createdTurn;

	public int elapsedTime => _elapsedTime;

	public string fireKey => _fireKey;

	public string hitKey => _hitKey;

	public string beHitKey => _beHitKey;

	internal Projectile()
	{
	}

	internal static Projectile _Create(int id, int targetIndex, int fireEventIndex, int createdTurn)
	{
		Projectile projectile = new Projectile();
		projectile._id = id;
		projectile._isCritical = false;
		projectile._isSplash = false;
		projectile._targetIndex = targetIndex;
		projectile._elapsedTime = -66;
		projectile._fireEventIndex = fireEventIndex;
		projectile._createdTurn = createdTurn;
		projectile._beHitId = -1;
		projectile._fireKey = string.Empty;
		projectile._hitKey = string.Empty;
		projectile._beHitKey = string.Empty;
		return projectile;
	}

	internal static Projectile _Copy(Projectile src)
	{
		Projectile projectile = new Projectile();
		projectile._id = src._id;
		projectile._isCritical = src._isCritical;
		projectile._isSplash = src._isSplash;
		projectile._targetIndex = src._targetIndex;
		projectile._elapsedTime = src._elapsedTime;
		projectile._fireEventIndex = src._fireEventIndex;
		projectile._createdTurn = src._createdTurn;
		projectile._beHitId = src._beHitId;
		projectile._fireKey = src._fireKey;
		projectile._hitKey = src._hitKey;
		projectile._beHitKey = src._beHitKey;
		return projectile;
	}
}
