using System;
using UnityEngine;
using Utils.Audio;
using Utils.Libraries;

namespace LD49.Game.Data.Level {
	public class EnvironmentObject : MonoBehaviour {
		[SerializeField] protected Rigidbody                 _rigidbody;
		[SerializeField] protected EnvironmentObjectCategory _category;

		private    float                     timeNextAudio { get; set; }
		public new Rigidbody                 rigidbody     => _rigidbody;
		public     EnvironmentObjectCategory category      => _category;

		private bool  damaged     { get; set; }
		private float damageTaken { get; set; }

		private void Reset() {
			_rigidbody = GetComponent<Rigidbody>();
		}

		public void SetDamaged(float amount) {
			_rigidbody.isKinematic = GetKinematicOnHit();
			damageTaken += amount;
			if (!damaged && (category.unhappyEvenWith0Damages || amount > 0)) {
				damaged = true;
				EnvironmentObjectCategory.onObjectTookFirstDamage.Invoke(_category);
			}
			CheckDestroyed();
		}

		private void CheckDestroyed() {
			if (!category.canBeDestroyed) return;
			if (damageTaken < category.maxHealth) return;
			if (!string.IsNullOrEmpty(_category.audioOnDestroy)) AudioManager.Sfx.PlayRandom(_category.audioOnDestroy);
			if (!string.IsNullOrEmpty(_category.particlesOnDestroy)) Particles.Play(category.particlesOnDestroy, transform.position);
			Destroy(gameObject);
		}

		public void PlayAudio() {
			if (string.IsNullOrEmpty(_category.audioOnHit)) return;
			if (Time.time < timeNextAudio) return;
			AudioManager.Sfx.PlayRandom(_category.audioOnHit);
			timeNextAudio = Time.time + _category.audioCooldown;
		}

		private bool GetKinematicOnHit() {
			switch (_category.behaviourOnHit) {
				case EnvironmentObjectCategory.BehaviourOnHit.NoChange: return _rigidbody.isKinematic;
				case EnvironmentObjectCategory.BehaviourOnHit.SetKinematic: return true;
				case EnvironmentObjectCategory.BehaviourOnHit.SetDynamic: return false;
				case EnvironmentObjectCategory.BehaviourOnHit.Switch: return !_rigidbody.isKinematic;
				default: throw new ArgumentOutOfRangeException();
			}
		}
	}
}