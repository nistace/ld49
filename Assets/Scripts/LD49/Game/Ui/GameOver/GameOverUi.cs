using System.Linq;
using LD49.Game.Data.Scoring;
using LD49.Input;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utils.Extensions;

namespace LD49.Game.Ui {
	public class GameOverUi : MonoBehaviour {
		[SerializeField] protected Transform           _statsContainer;
		[SerializeField] protected GameOverStatsItemUi _statsItemPrefab;
		[SerializeField] protected TMP_Text            _pacifistScore;
		[SerializeField] protected TMP_Text            _warmongerScore;
		[SerializeField] protected TMP_Text            _playTime;
		[SerializeField] protected GameObject          _submitGameObject;
		[SerializeField] protected TMP_InputField      _nameInput;
		[SerializeField] protected Button              _submitButton;
		[SerializeField] protected GameObject          _continueGameObject;
		[SerializeField] protected TMP_Text            _continueText;
		[SerializeField] protected Button              _continueButton;

		public string nameInputValue => _nameInput.text;

		public UnityEvent onSubmitScoreClicked => _submitButton.onClick;
		public UnityEvent onContinueClicked    => _continueButton.onClick;

		private void Start() {
			_nameInput.onValueChanged.AddListenerOnce(HandleNameInputValueChanged);
		}

		private void HandleNameInputValueChanged(string value) => _submitButton.interactable = !string.IsNullOrEmpty(value);

		public void Show() {
			ScoringManager.allObjectsDestroyed.OrderByDescending(t => t.Value).ForEach(t => Instantiate(_statsItemPrefab, _statsContainer).Set(t.Key, t.Value));
			_pacifistScore.text = $"{ScoringManager.GetPacifistScore()}";
			_warmongerScore.text = $"{ScoringManager.GetWarmongerScore()}";
			_playTime.text = $"Playtime: {FormatPlayTime()}";
			gameObject.SetActive(true);
		}

		private static string FormatPlayTime() {
			var minutes = Mathf.CeilToInt(ScoringManager.GetTimer()) / 60;
			var seconds = Mathf.CeilToInt(ScoringManager.GetTimer()) % 60;
			return $"{minutes:00}:{seconds:00}";
		}

		public void DisableSubmit() {
			_nameInput.interactable = false;
			_submitButton.interactable = false;
		}

		public void ShowContinue(string result) {
			_continueGameObject.gameObject.SetActive(true);
			_submitGameObject.gameObject.SetActive(false);
			_continueText.text = result;
		}
	}
}