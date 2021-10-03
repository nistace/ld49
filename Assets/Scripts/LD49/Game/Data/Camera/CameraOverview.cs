using LD49.Game;
using UnityEngine;

public class CameraOverview : MonoBehaviour, ICameraBehaviour {
	public static              Vector3 target { get; set; }
	[SerializeField] protected float   _smooth;
	[SerializeField] protected Vector3 _currentVelocity;

	private void FixedUpdate() {
		transform.position = Vector3.SmoothDamp(transform.position, target, ref _currentVelocity, _smooth);
	}

	[ContextMenu("Attach")] public void Attach() => transform.position = target;
	[ContextMenu("Save Position")] public void SavePosition() => target = transform.position;
}