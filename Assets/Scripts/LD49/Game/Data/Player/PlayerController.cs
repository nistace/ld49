using LD49.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils.Events;
using Utils.Extensions;

namespace LD49.Game.Player {
	public class PlayerController : MonoBehaviour, IDamageable {
		[SerializeField] protected float          _maxHealth = 500;
		[SerializeField] protected Rigidbody      _rigidbody;
		[SerializeField] protected TriggerChecker _groundChecker;
		[SerializeField] protected float          _movementSpeed = 2;
		[SerializeField] protected float          _jumpForce     = 4;
		[SerializeField] protected float          _damageTaken;
		[SerializeField] protected ParticleSystem _particlesOnDestroyed;
		[SerializeField] protected Renderer[]     _renderersToHideOnDestroyed;

		public BoolEvent onRestarted { get; } = new BoolEvent();

		private float saveDamageTaken { get; set; }
		public  float health          => (_maxHealth - _damageTaken).Clamp(0, maxHealth);
		public  float maxHealth       => _maxHealth;

		private void Start() => Restart(false);

		public void Restart(bool revertValues) {
			if (revertValues) _damageTaken = saveDamageTaken;
			else saveDamageTaken = _damageTaken;
			_groundChecker.Clear();
			Inputs.controls.Player.Enable();
			SetDestroyed(false);
			onRestarted.Invoke(revertValues);
		}

		private void OnEnable() {
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

		public void Damage(Vector3 force, float damageAmount) {
			_rigidbody.AddForce(force);
			Damage(damageAmount);
		}

		public void Damage(Vector3 origin, float force, float radius, float damageAmount) {
			_rigidbody.AddExplosionForce(force, origin, radius);
			Damage(damageAmount);
		}

		private void Damage(float damageAmount) {
			_damageTaken += damageAmount;
			if (_damageTaken < _maxHealth) return;
			SetDestroyed(true);
			_particlesOnDestroyed.Play();
			Inputs.controls.Player.Disable();
		}

		private void SetDestroyed(bool destroyed) {
			_renderersToHideOnDestroyed.ForEach(t => t.enabled = !destroyed);
			GetComponent<Collider>().enabled = !destroyed;
			_rigidbody.isKinematic = destroyed;
		}

		public void Heal(float heal) => _damageTaken = Mathf.Max(0, _damageTaken - heal);
	}
}