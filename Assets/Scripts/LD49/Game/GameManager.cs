using LD49.Game.Common;
using LD49.Game.Data.Level;
using LD49.Game.Data.Scoring;
using LD49.Game.Player;
using LD49.Game.Ui;
using LD49.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Utils.Audio;
using Utils.Extensions;

namespace LD49.Game {
	public class GameManager : MonoBehaviour {
		[SerializeField] protected Texture2D[]      _levels;
		[SerializeField] protected int              _currentLevelIndex;
		[SerializeField] protected LevelGenerator   _levelGenerator;
		[SerializeField] protected PlayerController _player;
		[SerializeField] protected PeaceOrWarUi     _peaceOrWarUi;
		[SerializeField] protected Faction          _humanFaction;
		[SerializeField] protected AudioClip        _warAudio;
		[SerializeField] protected GameOverUi       _gameOverUi;

		private void Start() {
			_levelGenerator.ParseLevelImage(_levels[_currentLevelIndex]);
			Inputs.controls.Game.Enable();
			Inputs.controls.Game.RestartLevel.AddPerformListenerOnce(RestartLevel);
			LevelExit.onPlayerExitLevel.AddListenerOnce(StartNextLevel);
			ScoringManager.ResetGlobal();
			_peaceOrWarUi.SetPeace(true);
			EnvironmentObjectCategory.onObjectTookFirstDamage.AddListenerOnce(HandleObjectTookDamage);
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
			if (_currentLevelIndex >= _levels.Length) GameOver();
			else {
				_player.Restart(false);
				BulletPool.PoolAll();
				_levelGenerator.ParseLevelImage(_levels[_currentLevelIndex]);
				_peaceOrWarUi.SetPeace(true);
				EnvironmentObjectCategory.onObjectTookFirstDamage.AddListenerOnce(HandleObjectTookDamage);
			}
		}

		private void GameOver() {
			ScoringManager.StopTimer();
			_player.enabled = false;
			Inputs.controls.Game.Disable();
			_gameOverUi.Show();
			_gameOverUi.onSubmitScoreClicked.AddListenerOnce(SubmitScore);
		}

		private void SubmitScore() {
			_gameOverUi.DisableSubmit();
			LeaderBoardManager.SubmitScore(_gameOverUi.nameInputValue, HandleScoreSubmitted);
		}

		private void HandleScoreSubmitted(bool success) {
			_gameOverUi.ShowContinue(success ? "Score submitted! Thanks for playing!" : "An error occurred :( ... Thanks for playing!");
			_gameOverUi.onContinueClicked.AddListenerOnce(GoToMenu);
		}

		private static void GoToMenu() => SceneManager.LoadScene("Menu");

		private void RestartLevel(InputAction.CallbackContext obj) {
			_player.Restart(true);
			_levelGenerator.ParseLevelImage(_levels[_currentLevelIndex]);
			BulletPool.PoolAll();
			ScoringManager.ResetForLevel();
			_peaceOrWarUi.SetPeace(true);
			EnvironmentObjectCategory.onObjectTookFirstDamage.AddListenerOnce(HandleObjectTookDamage);
		}

		private void HandleObjectTookDamage(EnvironmentObjectCategory category) {
			if (category.faction != _humanFaction) return;
			_peaceOrWarUi.SetPeace(false);
			EnvironmentObjectCategory.onObjectTookFirstDamage.RemoveListener(HandleObjectTookDamage);
			AudioManager.Sfx.Play(_warAudio);
		}
	}
}