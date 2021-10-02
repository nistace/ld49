using UnityEngine;

namespace LD49.Game.Player {
	public class PlayerPointerHit : MonoBehaviour {
		public static Vector3 hitPoint { get; private set; }

		private void Update() {
			if (!MainCamera.cam) return;
			if (Physics.Raycast(MainCamera.cam.ScreenPointToRay(UnityEngine.Input.mousePosition), out var hit, 9801, LayerMask.GetMask("PointerHit"))) {
				hitPoint = hit.point;
			}
		}

#if UNITY_EDITOR
		private void OnDrawGizmos() {
			if (!Application.isPlaying) return;
			if (!MainCamera.cam) return;
			Gizmos.color = Color.magenta;
			Gizmos.DrawRay(MainCamera.cam.ScreenPointToRay(UnityEngine.Input.mousePosition));
			Gizmos.DrawSphere(hitPoint, .4f);
		}
#endif
	}
}