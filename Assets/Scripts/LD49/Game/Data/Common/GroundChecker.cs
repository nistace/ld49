using System.Collections.Generic;
using UnityEngine;

namespace LD49.Game {
	public class GroundChecker : MonoBehaviour {
		private HashSet<Collider> collidersInChecker { get; } = new HashSet<Collider>();
		public  bool              check              => collidersInChecker.Count > 0;

		private void OnTriggerEnter(Collider other) => collidersInChecker.Add(other);

		private void OnTriggerExit(Collider other) => collidersInChecker.Remove(other);

		public void Clear() {
			collidersInChecker.Clear();
		}
	}
}