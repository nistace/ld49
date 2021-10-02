using UnityEngine;
using Utils.Libraries;

public class App : MonoBehaviour {
	private void Start() {
		AudioClips.LoadLibrary(Resources.Load<AudioClipLibrary>("Libraries/Audio"));
	}
}