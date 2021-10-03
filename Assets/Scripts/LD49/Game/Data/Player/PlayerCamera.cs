using System;
using LD49.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils.Extensions;

namespace LD49.Game.Player {
	public class PlayerCamera : MonoBehaviour {
		protected enum Status {
			Follow   = 0,
			Overview = 1
		}

		[SerializeField] protected CameraFollow   _follow;
		[SerializeField] protected CameraOverview _overview;
		[SerializeField] protected Status         _statusOnStart = Status.Overview;

		private Status currentStatus { get; set; }

		private void Start() {
			SetStatus(_statusOnStart, true);
			GetComponent<PlayerController>().onRestarted.AddListenerOnce(Restart);
		}

		private void Restart(bool revertValues) {
			if (!revertValues) SetStatus(Status.Overview);
		}

		private void OnEnable() => Inputs.controls.Player.SwitchCamera.AddPerformListenerOnce(SwitchCamera);
		private void OnDisable() => Inputs.controls.Player.SwitchCamera.AddPerformListenerOnce(SwitchCamera);

		private void SwitchCamera(InputAction.CallbackContext obj) => SetStatus((Status) (((int) currentStatus + 1) % EnumUtils.SizeOf<Status>()));

		private ICameraBehaviour GetBehaviour(Status status) {
			switch (status) {
				case Status.Follow: return _follow;
				case Status.Overview: return _overview;
				default: throw new ArgumentOutOfRangeException();
			}
		}

		private void SetStatus(Status status, bool attach = false) {
			currentStatus = status;
			_follow.enabled = status == Status.Follow;
			_overview.enabled = status == Status.Overview;
			if (attach) GetBehaviour(status).Attach();
		}
	}
}