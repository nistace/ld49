using UnityEngine;

namespace LD49.Game.Data.Level {
	[RequireComponent(typeof(EnvironmentObject))]
	public class DamageableEnvironmentObject : MonoBehaviour, IDamageable {
		[SerializeField] protected EnvironmentObject _environmentObject;

		private void Reset() => _environmentObject = GetComponent<EnvironmentObject>();

		public void Damage(Vector3 force, float damageAmount) {
			_environmentObject.SetDamaged();
			_environmentObject.rigidbody.AddForce(force);
			_environmentObject.PlayAudio();
		}

		public void Damage(Vector3 origin, float force, float radius, float damageAmount) {
			_environmentObject.SetDamaged();
			_environmentObject.rigidbody.AddExplosionForce(force, origin, radius);
			_environmentObject.PlayAudio();
		}
	}
}