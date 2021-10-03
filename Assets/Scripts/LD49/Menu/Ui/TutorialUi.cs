using UnityEngine;
using UnityEngine.UI;
using Utils.Extensions;

public class TutorialUi : MonoBehaviour {
	[SerializeField] protected Button    _backToMenuButton;
	[SerializeField] protected Button    _continueButton;
	[SerializeField] protected Transform _content;

	private int step { get; set; }

	private void Start() {
		_continueButton.onClick.AddListenerOnce(NextPage);
		_backToMenuButton.onClick.AddListenerOnce(Hide);
	}

	public void Hide() => gameObject.SetActive(false);

	private void NextPage() {
		if (step + 1 >= _content.childCount) Hide();
		else ShowPage(step + 1);
	}

	public void Show() {
		gameObject.SetActive(true);
		ShowPage(0);
	}

	private void ShowPage(int step) {
		this.step = step;
		for (var i = 0; i < _content.childCount; ++i) {
			_content.GetChild(i).gameObject.SetActive(i == step);
		}
	}
}