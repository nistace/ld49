using LD49.Menu.Ui;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.Extensions;

namespace Menu {
	public class MenuManager : MonoBehaviour {
		[SerializeField] protected MenuUi _ui;

		private void Start() {
			_ui.onStartClicked.AddListenerOnce(StartGame);
		}

		private static void StartGame() => SceneManager.LoadScene("Game");
	}
}