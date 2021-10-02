using UnityEngine;
using UnityEngine.Events;

namespace LD49.Game.Data.Level {
	[CreateAssetMenu(menuName = "Environment Object Category")]
	public class EnvironmentObjectCategory : ScriptableObject {
		public class Event : UnityEvent<EnvironmentObjectCategory> { }

		public enum BehaviourOnHit {
			SetDynamic   = 0,
			SetKinematic = 1,
			Switch       = 2,
			NoChange     = 3
		}

		[SerializeField] protected BehaviourOnHit _behaviourOnHit;
		[SerializeField] protected string         _audioOnHit;
		[SerializeField] protected float          _audioCooldown = 2;
		[SerializeField] protected int            _aggressiveScore;
		[SerializeField] protected int            _pacifistScore;

		public int            aggressiveScore => _aggressiveScore;
		public int            pacifistScore   => _pacifistScore;
		public BehaviourOnHit behaviourOnHit  => _behaviourOnHit;
		public string         audioOnHit      => _audioOnHit;
		public float          audioCooldown   => _audioCooldown;

		public static Event onObjectTookFirstDamage { get; } = new Event();
		
	}
}