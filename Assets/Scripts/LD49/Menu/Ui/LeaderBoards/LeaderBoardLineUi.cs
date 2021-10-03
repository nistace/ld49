using TMPro;
using UnityEngine;

namespace LD49.Menu.Ui.LeaderBoards {
	public class LeaderBoardLineUi : MonoBehaviour {
		[SerializeField] protected TMP_Text _order;
		[SerializeField] protected TMP_Text _name;
		[SerializeField] protected TMP_Text _score;

		public void Set(int order, string name, int score) {
			_order.text = $"{order}";
			_name.text = name;
			_score.text = $"{score}";
		}
	}
}