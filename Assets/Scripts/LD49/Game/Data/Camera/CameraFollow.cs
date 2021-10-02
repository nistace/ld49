using UnityEngine;

namespace LD49.Game {
	public class CameraFollow : MonoBehaviour {
		[SerializeField] protected Transform _target;
		[SerializeField] protected Vector3   _offset;
		[SerializeField] protected float     _smooth;
		[SerializeField] protected Vector3   _currentVelocity;

		private void FixedUpdate() {
			transform.position = Vector3.SmoothDamp(transform.position, _target.position + _offset, ref _currentVelocity, _smooth);
		}
	}
}