using System;
using UnityEngine;
using UnityEngine.Events;

namespace LD49.Game.Data.Level {
	public class LevelExit : MonoBehaviour {
		public static UnityEvent onPlayerExitLevel { get; } = new UnityEvent();

		private void OnTriggerEnter(Collider other) {
			if (other.gameObject.layer == LayerMask.NameToLayer("Player")) onPlayerExitLevel.Invoke();
		}
	}
}