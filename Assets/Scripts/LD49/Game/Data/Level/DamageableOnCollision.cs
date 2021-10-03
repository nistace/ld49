using UnityEngine;

namespace LD49.Game.Data.Level {
	[RequireComponent(typeof(EnvironmentObject))]
	public class DamageableOnCollision : MonoBehaviour {
		[SerializeField] protected EnvironmentObject _environmentObject;
		[SerializeField] protected float             _minSqrCollisionVelocity = 50;

		private void Reset() => _environmentObject = GetComponent<EnvironmentObject>();

		private void OnCollisionEnter(Collision other) {
			if (other.gameObject.layer == LayerMask.NameToLayer("Bullet")) return;
			if (other.gameObject.layer != LayerMask.NameToLayer("Player") && !(other.relativeVelocity.sqrMagnitude >= _minSqrCollisionVelocity)) return;
			_environmentObject.SetDamaged(other.relativeVelocity.sqrMagnitude * .1f);
			_environmentObject.PlayAudio();
		}
	}
}