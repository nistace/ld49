using LD49.Game.Data.Level;
using LD49.Game.Data.Scoring;
using LD49.Game.Player;
using LD49.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils.Extensions;

namespace LD49.Game {
	public class GameManager : MonoBehaviour {
		[SerializeField] protected Texture2D[]      _levels;
		[SerializeField] protected int              _currentLevelIndex;
		[SerializeField] protected LevelGenerator   _levelGenerator;
		[SerializeField] protected PlayerController _player;

		private void Start() {
			_levelGenerator.ParseLevelImage(_levels[_currentLevelIndex]);
			Inputs.controls.Game.Enable();
			Inputs.controls.Game.RestartLevel.AddPerformListenerOnce(RestartLevel);
			LevelExit.onPlayerExitLevel.AddListenerOnce(StartNextLevel);
			ScoringManager.ResetGlobal();
		}

		private void OnDestroy() {
			Inputs.controls.Game.Disable();
			Inputs.controls.Game.RestartLevel.RemovePerformListener(RestartLevel);
			Inputs.controls.Game.RestartLevel.RemovePerformListener(RestartLevel);
			LevelExit.onPlayerExitLevel.RemoveListener(StartNextLevel);
		}

		private void StartNextLevel() {
			ScoringManager.ValidateLevel();
			_currentLevelIndex++;
			_player.Restart();
			_levelGenerator.ParseLevelImage(_levels[_currentLevelIndex]);
		}

		private void RestartLevel(InputAction.CallbackContext obj) {
			_player.Restart();
			_levelGenerator.ParseLevelImage(_levels[_currentLevelIndex]);
			ScoringManager.ResetForLevel();
		}
	}
}