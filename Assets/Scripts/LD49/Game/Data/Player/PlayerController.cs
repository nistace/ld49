using LD49.Input;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Utils.Extensions;

namespace LD49.Game.Player {
	public class PlayerController : MonoBehaviour, IDamageable {
		[SerializeField] protected Rigidbody     _rigidbody;
		[SerializeField] protected GroundChecker _groundChecker;
		[SerializeField] protected float         _movementSpeed = 2;
		[SerializeField] protected float         _jumpForce     = 4;

		public UnityEvent onRestarted { get; } = new UnityEvent();

		private void Start() => Restart();

		public void Restart() {
			_groundChecker.Clear();
			onRestarted.Invoke();
		}

		private void OnEnable() {
			Inputs.controls.Player.Enable();
			Inputs.controls.Player.Jump.AddPerformListenerOnce(HandleJump);
		}

		private void OnDisable() {
			Inputs.controls.Player.Disable();
			Inputs.controls.Player.Jump.RemovePerformListener(HandleJump);
		}

		private void HandleJump(InputAction.CallbackContext obj) {
			if (!_groundChecker.check) return;
			_rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
		}

		private void Update() {
			var movementInput = Inputs.controls.Player.Right.ReadValue<float>() - Inputs.controls.Player.Left.ReadValue<float>();
			_rigidbody.velocity = _rigidbody.velocity.With(x: movementInput * _movementSpeed);
			if (movementInput < 0) transform.forward = Vector3.left;
			if (movementInput > 0) transform.forward = Vector3.right;
		}

		public void Damage(Vector3 force, float damageAmount) => _rigidbody.AddForce(force);

		public void Damage(Vector3 origin, float force, float radius, float damageAmount) => _rigidbody.AddExplosionForce(force, origin, radius);
	}
}