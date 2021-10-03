using System;
using System.Collections;
using LD49.Game.Player;
using LD49.Input;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils.Extensions;

namespace LD49.Game.Ui {
	public class PlayerUnstableUi : MonoBehaviour {
		[SerializeField] protected PlayerUnstable _playerPlayerUnstable;
		[SerializeField] protected Image          _progressNextSwitchUnstableImage;
		[SerializeField] protected Color          _unstableColor;
		[SerializeField] protected Color          _stableColor;
		[SerializeField] protected TMP_Text       _unstableActionText;
		[SerializeField] protected TMP_Text       _stableCircuitsText;
		[SerializeField] protected TMP_Text       _centerScreenMessage;
		[SerializeField] protected AnimationCurve _centerScreenMessageSize;
		[SerializeField] protected AnimationCurve _centerScreenMessageOpacity;
		[SerializeField] protected float          _centerScreenMessageTime;

		private void Start() {
			_playerPlayerUnstable.onUnstableActionChanged.AddListenerOnce(ShowCenterScreenMessage);
		}

		private void ShowCenterScreenMessage() {
			_centerScreenMessage.enabled = true;
			_centerScreenMessage.text = GetStabilityStatus(out var color);
			_centerScreenMessage.color = color;
			StartCoroutine(DoShowCenterScreenMessage());
		}

		private IEnumerator DoShowCenterScreenMessage() {
			var progress = 0f;
			while (progress < 1) {
				var size = _centerScreenMessageSize.Evaluate(progress);
				_centerScreenMessage.rectTransform.anchorMin = new Vector2(.5f - size, .5f - size);
				_centerScreenMessage.rectTransform.anchorMax = new Vector2(.5f + size, .5f + size);
				_centerScreenMessage.rectTransform.offsetMin = Vector2.zero;
				_centerScreenMessage.rectTransform.offsetMax = Vector2.zero;
				_centerScreenMessage.color = _centerScreenMessage.color.With(a: _centerScreenMessageOpacity.Evaluate(progress));
				progress += Time.deltaTime / _centerScreenMessageTime;
				yield return null;
			}
			_centerScreenMessage.enabled = false;
		}

		private void Update() {
			_progressNextSwitchUnstableImage.fillAmount = _playerPlayerUnstable.unstableProgressRatio;
			_unstableActionText.text = GetStabilityStatus(out var color);
			_progressNextSwitchUnstableImage.color = color;
			_stableCircuitsText.text = $"{_playerPlayerUnstable.stableCircuitsCount}";
		}

		private string GetStabilityStatus(out Color color) {
			color = _stableColor;
			if (_playerPlayerUnstable.stable) return "Stable";
			color = _unstableColor;
			switch (_playerPlayerUnstable.unstablePlayerAction) {
				case Inputs.PlayerAction.Left: return "Unstable: Left Movement";
				case Inputs.PlayerAction.Right: return "Unstable: Right Movement";
				case Inputs.PlayerAction.Jump: return "Unstable: Jump";
				case Inputs.PlayerAction.Shoot: return "Unstable: Shoot";
				case Inputs.PlayerAction.Telekinesis: return "Unstable: Telekinesis";
				case Inputs.PlayerAction.SwitchCamera: return "Unstable: Change Camera";
				case Inputs.PlayerAction.None:
				default: throw new ArgumentOutOfRangeException();
			}
		}
	}
}