using LD49.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils.Extensions;

namespace LD49.Game.Player {
	public class PlayerShooter : MonoBehaviour {
		[SerializeField] protected Transform          _armsAxis;
		[SerializeField] protected PlayerShooterGun[] _guns;
		[SerializeField] protected float              _fireDelay = .1f;

		private bool  firing        { get; set; }
		private float _nextFireTime { get; set; }

		private void OnEnable() => Inputs.controls.Player.Fire.AddAnyListenerOnce(HandleInputChanged);
		private void OnDisable() => Inputs.controls.Player.Fire.RemoveAnyListener(HandleInputChanged);

		private void HandleInputChanged(InputAction.CallbackContext obj) => firing = obj.performed;

		private void Update() {
			UpdateAxisRotation();
			UpdateFiring();
		}

		private void UpdateFiring() {
			if (!firing) return;
			if (!(Time.time >= _nextFireTime)) return;
			_guns.ForEach(t => t.Trigger());
			_nextFireTime = Time.time + _fireDelay;
		}

		private void UpdateAxisRotation() => _armsAxis.forward = (PlayerPointerHit.hitPoint - _armsAxis.position).With(z: 0);
	}
}