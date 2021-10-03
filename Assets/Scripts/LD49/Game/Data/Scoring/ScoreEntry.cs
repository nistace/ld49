using System;
using JetBrains.Annotations;
using UnityEngine;

namespace LD49.Game.Data.Scoring {
	[UsedImplicitly]
	[Serializable]
	public class ScoreEntry {
		[SerializeField] protected string _name;
		[SerializeField] protected int    _pacifist;
		[SerializeField] protected int    _warmonger;

		public string name      => _name;
		public int    pacifist  => _pacifist;
		public int    warmonger => _warmonger;
		public ScoreEntry() { }

		public ScoreEntry(string name, int pacifist, int warmonger) {
			_name = name;
			_pacifist = pacifist;
			_warmonger = warmonger;
		}
	}
}