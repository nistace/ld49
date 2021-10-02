using LD49.Game.Data.Level;
using LD49.Input;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Utils.Audio;
using Utils.Extensions;

namespace LD49.Game.Player {
	public class PlayerUnstable : MonoBehaviour {
		[SerializeField] protected bool                _stableOnStart = true;
		[SerializeField] protected Transform           _unstableOrigin;
		[SerializeField] protected float               _radius          = 5;
		[SerializeField] protected float               _explosionForce  = 5;
		[SerializeField] protected float               _explosionRadius = 5;
		[SerializeField] private   Inputs.PlayerAction _unstablePlayerAction;
		[SerializeField] protected LayerMask           _hitMask;
		[SerializeField] protected ParticleSystem      _shockWaveParticles;
		[SerializeField] protected float               _maxDamage    = 50;
		[SerializeField] protected float               _delaySwitch  = 10;
		[SerializeField] protected int                 _warningBeeps = 3;
		[SerializeField] protected AudioClip           _beepAudioClip;
		[SerializeField] protected AudioClip           _switchUnstableAudioClip;
		[SerializeField] protected AudioClip           _stableAudioClip;
		[SerializeField] protected int                 _stableCircuitsCount = 3;

		private int                 lastBeepPlayed             { get; set; }
		private float               nextTimeSwitchUnstable     { get; set; }
		private float               progressNextSwitchUnstable { get; set; }
		public  float               unstableProgressRatio      => progressNextSwitchUnstable / nextTimeSwitchUnstable;
		public  Inputs.PlayerAction unstablePlayerAction       => _unstablePlayerAction;
		private InputAction         currentUnstableAction      { get; set; }
		public  bool                stable                     => unstablePlayerAction == Inputs.PlayerAction.None;
		public  int                 stableCircuitsCount        => _stableCircuitsCount;

		public UnityEvent onUnstableActionChanged { get; } = new UnityEvent();

		private Collider[] collidersInRange { get; } = new Collider[128];

		private void Start() {
			Restart();
			GetComponent<PlayerController>().onRestarted.AddListenerOnce(Restart);
			BonusEnvironmentObject.onGatheredByPlayer.AddListenerOnce(HandleBonusGathered);
		}

		private void HandleBonusGathered(BonusEnvironmentObject.Type type) {
			if (type == BonusEnvironmentObject.Type.StableCircuit) _stableCircuitsCount++;
		}

		private void Restart() {
			if (_stableOnStart) SetStable();
			else SetUnstableAction(_unstablePlayerAction);
		}

		private void OnEnable() {
			Inputs.controls.Player.UseStableCircuit.AddPerformListenerOnce(HandleStableCircuit);
		}

		private void HandleStableCircuit(InputAction.CallbackContext obj) {
			if (_stableCircuitsCount <= 0) return;
			_stableCircuitsCount--;
			SetStable();
		}

		private void RollUnstableAction(bool resetDelaySwitch = true) {
			SetUnstableAction(EnumUtils.Values<Inputs.PlayerAction>().Random(t => t.In(Inputs.PlayerAction.None) ? 0 : 1));
			if (resetDelaySwitch) ResetDelay();
			AudioManager.Sfx.Play(_switchUnstableAudioClip);
		}

		private void SetUnstableAction(Inputs.PlayerAction action) {
			if (action == _unstablePlayerAction) return;
			currentUnstableAction?.RemovePerformListener(Boom);
			_unstablePlayerAction = action;
			currentUnstableAction = Inputs.GetPlayerAction(action);
			currentUnstableAction?.AddPerformListenerOnce(Boom);
			onUnstableActionChanged.Invoke();
		}

		private void SetStable(bool resetDelaySwitch = true) {
			SetUnstableAction(Inputs.PlayerAction.None);
			if (resetDelaySwitch) ResetDelay();
			AudioManager.Sfx.Play(_stableAudioClip);
		}

		private void ResetDelay() {
			nextTimeSwitchUnstable = _delaySwitch;
			progressNextSwitchUnstable = 0;
			lastBeepPlayed = Mathf.CeilToInt(_delaySwitch);
		}

		private void Update() {
			progressNextSwitchUnstable += Time.deltaTime;
			if (progressNextSwitchUnstable >= nextTimeSwitchUnstable) RollUnstableAction();
			UpdateAudio();
		}

		private void UpdateAudio() {
			if ((int) (nextTimeSwitchUnstable - progressNextSwitchUnstable) >= lastBeepPlayed) return;
			lastBeepPlayed = (int) (nextTimeSwitchUnstable - progressNextSwitchUnstable);
			if (lastBeepPlayed <= _warningBeeps) AudioManager.Sfx.Play(_beepAudioClip);
		}

		private void Boom(InputAction.CallbackContext obj) {
			_shockWaveParticles.Play();
			var hitCollidersCount = Physics.OverlapSphereNonAlloc(transform.position, _radius, collidersInRange, _hitMask);
			var unstableOriginPosition = _unstableOrigin.position;
			for (var i = 0; i < hitCollidersCount; ++i) {
				if (!collidersInRange[i].gameObject.TryGetComponent<IDamageable>(out var hitDamageable)) continue;
				hitDamageable.Damage(unstableOriginPosition, _explosionForce, _explosionRadius,
					Mathf.Lerp(0, _maxDamage, 1 - Vector3.Distance(unstableOriginPosition, hitDamageable.transform.position) / _radius));
			}
		}

#if UNITY_EDITOR
		private void OnDrawGizmos() {
			Gizmos.DrawWireSphere(transform.position, _radius);
		}
#endif
	}
}