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

		[SerializeField] protected bool           _canBeDestroyed = true;
		[SerializeField] protected int            _maxHealth      = 100;
		[SerializeField] protected Faction        _faction;
		[SerializeField] protected BehaviourOnHit _behaviourOnHit;
		[SerializeField] protected string         _audioOnHit;
		[SerializeField] protected string         _audioOnDestroy;
		[SerializeField] protected string         _particlesOnDestroy;
		[SerializeField] protected float          _audioCooldown = 2;
		[SerializeField] protected int            _aggressiveScore;
		[SerializeField] protected int            _pacifistScore;
		[SerializeField] protected bool           _unhappyEvenWith0Damages;
		[SerializeField] protected Sprite         _sprite;

		public int            aggressiveScore         => _aggressiveScore;
		public int            pacifistScore           => _pacifistScore;
		public BehaviourOnHit behaviourOnHit          => _behaviourOnHit;
		public string         audioOnHit              => _audioOnHit;
		public string         audioOnDestroy          => _audioOnDestroy;
		public string         particlesOnDestroy      => _particlesOnDestroy;
		public float          audioCooldown           => _audioCooldown;
		public Faction        faction                 => _faction;
		public bool           canBeDestroyed          => _canBeDestroyed;
		public int            maxHealth               => _maxHealth;
		public bool           unhappyEvenWith0Damages => _unhappyEvenWith0Damages;
		public Sprite         sprite                  => _sprite;

		public static Event onObjectTookFirstDamage { get; } = new Event();
	}
}