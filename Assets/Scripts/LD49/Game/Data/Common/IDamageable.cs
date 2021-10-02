using UnityEngine;

namespace LD49.Game {
	public interface IDamageable {
		void Damage(Vector3 force, float damageAmount);

		void Damage(Vector3 origin, float force, float radius, float damageAmount);
		Transform transform { get; }
	}
}