using UnityEngine;
using UnityEngine.Events;
using Utils.Audio;

namespace LD49.Game.Data.Level {
	[RequireComponent(typeof(EnvironmentObject))]
	public class BonusEnvironmentObject : MonoBehaviour {
		public class TypeEvent : UnityEvent<Type> { }

		public enum Type {
			StableCircuit = 0
		}

		[SerializeField] protected AudioClip _audioOnGathered;
		[SerializeField] protected Type      _type;

		public static TypeEvent onGatheredByPlayer { get; } = new TypeEvent();

		private void OnCollisionEnter(Collision other) {
			if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
			if (_audioOnGathered) AudioManager.Sfx.Play(_audioOnGathered);
			onGatheredByPlayer.Invoke(_type);
			Destroy(gameObject);
		}
	}
}