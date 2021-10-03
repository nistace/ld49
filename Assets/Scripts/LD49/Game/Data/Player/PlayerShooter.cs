using LD49.Game.Common;
using LD49.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils.Extensions;

namespace LD49.Game.Player {
	public class PlayerShooter : MonoBehaviour {
		[SerializeField] protected ShooterGun _gun;

		private bool firing { get; set; }

		private void OnEnable() => Inputs.controls.Player.Fire.AddAnyListenerOnce(HandleInputChanged);
		private void OnDisable() => Inputs.controls.Player.Fire.RemoveAnyListener(HandleInputChanged);

		private void HandleInputChanged(InputAction.CallbackContext obj) => firing = obj.performed;

		private void Update() {
			_gun.AimAt(PlayerPointerHit.hitPoint);
			if (firing) _gun.UpdateFiring();
		}
	}
}