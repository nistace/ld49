using LD49.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils.Extensions;

namespace LD49.Game.Player {
	[RequireComponent(typeof(PlayerController))]
	public class PlayerTelekinesis : MonoBehaviour {
		[SerializeField] protected LayerMask _mask;
		[SerializeField] protected Color     _hitObjectMaterialColor = Color.cyan;
		[SerializeField] protected float     _speed                  = 1.5f;
		[SerializeField] protected float     _sqrRange               = 10;

		private Rigidbody currentObject { get; set; }

		private void Start() {
			GetComponent<PlayerController>().onRestarted.AddListenerOnce(Restart);
		}

		private void Restart(bool revertValues) => DropObject();

		private void OnEnable() => Inputs.controls.Player.Telekinesis.AddAnyListenerOnce(HandleInputChanged);
		private void OnDisable() => Inputs.controls.Player.Telekinesis.RemoveAnyListener(HandleInputChanged);

		private void HandleInputChanged(InputAction.CallbackContext obj) {
			if (obj.performed) GrabObject();
			else DropObject();
		}

		private void GrabObject() {
			if (!MainCamera.cam) return;
			if (!Physics.Raycast(MainCamera.cam.ScreenPointToRay(UnityEngine.Input.mousePosition), out var hit, 50, _mask)) return;
			if (Vector3.SqrMagnitude(hit.transform.position - transform.position) > _sqrRange) return;
			if (!hit.collider.TryGetComponent<Rigidbody>(out var hitRigidbody)) return;
			currentObject = hitRigidbody;
			if (currentObject.TryGetComponent<IDamageable>(out var damageable)) damageable.Damage(Vector3.zero, 0);
			currentObject.isKinematic = false;
			currentObject.useGravity = false;
			currentObject.GetComponentsInChildren<Renderer>().ForEach(t => t.material.color = _hitObjectMaterialColor);
		}

		private void DropObject() {
			if (!currentObject) return;
			currentObject.GetComponentsInChildren<Renderer>().ForEach(t => t.material.color = Color.white);
			currentObject.isKinematic = false;
			currentObject.useGravity = true;
			currentObject = null;
		}

		private void Update() {
			if (!currentObject) return;
			if (Vector3.SqrMagnitude(currentObject.transform.position - transform.position) > _sqrRange) {
				DropObject();
				return;
			}
			currentObject.velocity = _speed * (PlayerPointerHit.hitPoint - currentObject.transform.position);
		}
	}
}