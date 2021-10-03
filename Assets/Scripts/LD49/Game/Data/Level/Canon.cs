using LD49.Game;
using LD49.Game.Common;
using LD49.Game.Data.Level;
using UnityEngine;
using Utils.Extensions;

[RequireComponent(typeof(EnvironmentObject))]
public class Canon : MonoBehaviour {
	[SerializeField] protected EnvironmentObject _environmentObject;
	[SerializeField] protected ShooterGun        _gun;
	[SerializeField] protected TriggerChecker    _playerChecker;
	[SerializeField] protected Vector3           _aimOffset = new Vector3(0, 1.5f, 0);

	private bool attackPlayer { get; set; }

	private void Reset() {
		_environmentObject = GetComponent<EnvironmentObject>();
	}

	private void Start() {
		if (_environmentObject.category.faction.behaviourTowardsPlayer == Faction.BehaviourTowardsPlayer.AlwaysAttack) attackPlayer = true;
		else if (_environmentObject.category.faction.behaviourTowardsPlayer == Faction.BehaviourTowardsPlayer.Retaliate) {
			attackPlayer = false;
			EnvironmentObjectCategory.onObjectTookFirstDamage.AddListenerOnce(RetaliateIfSameFaction);
		}
	}

	private void RetaliateIfSameFaction(EnvironmentObjectCategory other) => attackPlayer |= other.faction == _environmentObject.category.faction;

	private void Update() {
		if (!attackPlayer) return;
		if (!_playerChecker.check) return;
		_gun.AimAt(_playerChecker.any.transform.position + _aimOffset);
		_gun.UpdateFiring();
	}
}