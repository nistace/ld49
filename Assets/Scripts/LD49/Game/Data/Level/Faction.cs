using UnityEngine;

namespace LD49.Game.Data.Level {
	[CreateAssetMenu(menuName = "Faction")]
	public class Faction : ScriptableObject {
		public enum BehaviourTowardsPlayer {
			AlwaysAttack = 0,
			Retaliate    = 1,
			None
		}

		[SerializeField] protected BehaviourTowardsPlayer _behaviourTowardsPlayer;

		public BehaviourTowardsPlayer behaviourTowardsPlayer => _behaviourTowardsPlayer;
	}
}