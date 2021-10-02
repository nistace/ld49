using UnityEngine;
using Utils.Audio;

namespace LD49.Game.Player {
	public class PlayerShooterGun : MonoBehaviour {
		[SerializeField] protected Bullet _bulletPrefab;
		[SerializeField] protected float  _force = 100;
		[SerializeField] protected string _audioOnTrigger;

		private new Transform transform => base.transform;

		public void Trigger() {
			BulletPool.Instantiate(_bulletPrefab, transform.position, transform.forward * _force);
			if (!string.IsNullOrEmpty(_audioOnTrigger)) AudioManager.Sfx.PlayRandom(_audioOnTrigger);
		}
	}
}