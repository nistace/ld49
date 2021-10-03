using UnityEngine;
using Utils.Audio;
using Utils.Extensions;

namespace LD49.Game.Common {
	public class ShooterGun : MonoBehaviour {
		[SerializeField] protected Bullet    _bulletPrefab;
		[SerializeField] protected float     _force = 100;
		[SerializeField] protected string    _audioOnTrigger;
		[SerializeField] protected float     _fireDelay = .15f;
		[SerializeField] protected Transform _mouth;

		private new Transform transform    => base.transform;
		private     float     nextFireTime { get; set; }

		public void Trigger() {
			BulletPool.Instantiate(_bulletPrefab, _mouth.position, _mouth.forward * _force);
			if (!string.IsNullOrEmpty(_audioOnTrigger)) AudioManager.Sfx.PlayRandom(_audioOnTrigger);
		}

		public void UpdateFiring() {
			if (!(Time.time >= nextFireTime)) return;
			Trigger();
			nextFireTime = Time.time + _fireDelay;
		}

		public void AimAt(Vector3 worldPosition) => transform.forward = (worldPosition - transform.position).With(z: 0);
	}
}