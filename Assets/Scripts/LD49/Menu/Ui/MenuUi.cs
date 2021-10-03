using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utils.Extensions;

namespace LD49.Menu.Ui {
	public class MenuUi : MonoBehaviour {
		[SerializeField] protected Button     _startButton;
		[SerializeField] protected Button     _tutorialButton;
		[SerializeField] protected TutorialUi _tutorial;

		public UnityEvent onStartClicked => _startButton.onClick;

		private void Start() {
			_tutorial.Hide();
			_tutorialButton.onClick.AddListenerOnce(_tutorial.Show);
		}
	}
}