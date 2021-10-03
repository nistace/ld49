using UnityEngine;
using Utils.Libraries;

public class App : MonoBehaviour {
	private App instance { get; set; }

	private void Awake() {
		if (instance != null) {
			Destroy(gameObject);
			return;
		}
		instance = this;
		DontDestroyOnLoad(gameObject);
	}

	private void Start() {
		AudioClips.LoadLibrary(Resources.Load<AudioClipLibrary>("Libraries/Audio"));
		Particles.LoadLibrary(Resources.Load<ParticlesLibrary>("Libraries/Particles"));
	}
}