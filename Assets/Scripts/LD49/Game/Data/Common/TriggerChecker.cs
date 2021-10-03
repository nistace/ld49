using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LD49.Game {
	public class TriggerChecker : MonoBehaviour {
		public  Collider          any                { get; set; }
		private HashSet<Collider> collidersInChecker { get; } = new HashSet<Collider>();
		public  bool              check              => collidersInChecker.Count > 0;

		private float doubleCheckTime { get; set; }

		private void OnTriggerEnter(Collider other) {
			collidersInChecker.Add(other);
			any = other;
		}

		private void OnTriggerExit(Collider other) {
			collidersInChecker.Remove(other);
			if (any == other) any = collidersInChecker.FirstOrDefault();
		}

		public void Clear() {
			any = null;
			collidersInChecker.Clear();
		}

		private void Update() {
			if (Time.time < doubleCheckTime) return;
			if (!check) return;
			collidersInChecker.RemoveWhere(t => !t || !t.enabled);
			doubleCheckTime = Time.time + 1;
		}
	}
}