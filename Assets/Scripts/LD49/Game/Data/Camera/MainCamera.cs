using UnityEngine;

public class MainCamera : MonoBehaviour {
	[SerializeField] protected Camera _camera;

	private static MainCamera instance { get; set; }

	public static Camera cam => instance ? instance._camera : null;

	private void Reset() => _camera = GetComponent<Camera>();

	private void Awake() {
		instance = this;
	}
}