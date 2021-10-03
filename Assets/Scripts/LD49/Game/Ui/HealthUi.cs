using LD49.Game.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils.Extensions;

public class HealthUi : MonoBehaviour {
	[SerializeField] protected PlayerController _player;
	[SerializeField] protected Image            _barImage;
	[SerializeField] protected TMP_Text         _valueText;

	private void Update() {
		_barImage.fillAmount = (_player.health / _player.maxHealth).Clamp(0, 1);
		_valueText.text = $"{_player.health:0} / {_player.maxHealth:0}";
	}
}