using System;
using UnityEngine;
using Utils.Audio;

namespace LD49.Game.Data.Level {
	public class EnvironmentObject : MonoBehaviour {
		[SerializeField] protected Rigidbody                 _rigidbody;
		[SerializeField] protected EnvironmentObjectCategory _category;

		private    float                     timeNextAudio { get; set; }
		private    bool                      damaged       { get; set; }
		public new Rigidbody                 rigidbody     => _rigidbody;
		public     EnvironmentObjectCategory category      => _category;

		private void Reset() {
			_rigidbody = GetComponent<Rigidbody>();
		}

		public void SetDamaged() {
			_rigidbody.isKinematic = GetKinematicOnHit();
			if (damaged) return;
			damaged = true;
			EnvironmentObjectCategory.onObjectTookFirstDamage.Invoke(_category);
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