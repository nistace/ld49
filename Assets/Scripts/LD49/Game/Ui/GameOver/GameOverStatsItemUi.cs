using LD49.Game.Data.Level;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LD49.Game.Ui {
	public class GameOverStatsItemUi : MonoBehaviour {
		[SerializeField] protected Image    _image;
		[SerializeField] protected TMP_Text _amount;

		public void Set(EnvironmentObjectCategory category, int amount) {
			_image.sprite = category.sprite;
			_amount.text = $"x{amount}";
		}
	}
}