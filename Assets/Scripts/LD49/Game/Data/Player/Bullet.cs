using UnityEngine;
using Utils.Audio;

namespace LD49.Game.Player {
	public class Bullet : MonoBehaviour {
		[SerializeField] protected TrailRenderer _trailRenderer;
		[SerializeField] protected Rigidbody     _rigidbody;
		[SerializeField] protected float         _damage;
		[SerializeField] protected float         _velocityTransferCoefficient = 10;
		[SerializeField] protected string        _audioOnHit;

		private void Reset() {
			_rigidbody = GetComponent<Rigidbody>();
		}

		public void Init(Vector3 force) {
			_trailRenderer.Clear();
			_rigidbody.velocity = Vector3.zero;
			_rigidbody.AddForce(force, ForceMode.Impulse);
		}

		private void OnCollisionEnter(Collision other) {
			if (other.gameObject.TryGetComponent<IDamageable>(out var hitDamageable)) {
				hitDamageable.Damage(_rigidbody.velocity * _velocityTransferCoefficient, _damage);
			}
			if (!string.IsNullOrEmpty(_audioOnHit)) AudioManager.Sfx.PlayRandom(_audioOnHit);
			BulletPool.Pool(this);
		}
	}
}