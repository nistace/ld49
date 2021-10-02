using System;
using UnityEngine.InputSystem;

namespace LD49.Input {
	public static class Inputs {
		public static Controls controls { get; } = new Controls();

		public enum PlayerAction {
			None        = 0,
			Left        = 1,
			Right       = 2,
			Jump        = 3,
			Shoot       = 4,
			Telekinesis = 5
		}

		public static InputAction GetPlayerAction(PlayerAction action) {
			switch (action) {
				case PlayerAction.Jump: return controls.Player.Jump;
				case PlayerAction.Left: return controls.Player.Left;
				case PlayerAction.Right: return controls.Player.Right;
				case PlayerAction.Shoot: return controls.Player.Fire;
				case PlayerAction.Telekinesis: return controls.Player.Telekinesis;
				case PlayerAction.None: return null;
				default: throw new ArgumentOutOfRangeException(nameof(action), action, null);
			}
		}
	}
}