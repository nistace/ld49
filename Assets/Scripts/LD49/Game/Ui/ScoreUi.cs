using LD49.Game.Data.Scoring;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils.Extensions;

namespace LD49.Game.Ui {
	public class ScoreUi : MonoBehaviour {
		[SerializeField] protected Image         _pacifistBar;
		[SerializeField] protected Image         _aggressiveBar;
		[SerializeField] protected TMP_Text      _pacifistScore;
		[SerializeField] protected TMP_Text      _aggressiveScore;
		[SerializeField] protected RectTransform _cursorAnchor;
		[SerializeField] protected Image         _cursor;

		private void Update() {
			var pacifistScore = ScoringManager.GetPacifistScore();
			var aggressiveScore = ScoringManager.GetWarmongerScore();
			var pacifistRatio = (float) pacifistScore / Mathf.Max(pacifistScore + aggressiveScore, 1);
			_pacifistBar.fillAmount = pacifistRatio.Clamp(0, 1);
			_aggressiveBar.fillAmount = 1 / pacifistRatio;
			_aggressiveScore.text = $"{aggressiveScore}";
			_pacifistScore.text = $"{pacifistScore}";
			_cursorAnchor.anchorMin = new Vector2(pacifistRatio, 0);
			_cursorAnchor.anchorMax = new Vector2(pacifistRatio, 0);
			_cursorAnchor.offsetMin = Vector2.zero;
			_cursorAnchor.offsetMax = Vector2.zero;
			_cursor.color = Color.Lerp(_aggressiveBar.color, _pacifistBar.color, pacifistRatio);
		}
	}
}