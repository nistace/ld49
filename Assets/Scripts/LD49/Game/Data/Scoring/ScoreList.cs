using System;
using JetBrains.Annotations;
using UnityEngine;

// ReSharper disable InconsistentNaming
// ReSharper disable UnassignedField.Global
namespace LD49.Game.Data.Scoring {
	[UsedImplicitly]
	[Serializable]
	public class ScoreList {
		[SerializeField] protected ScoreEntry[] _entries;

		public ScoreEntry[] entries => _entries;
	}
}