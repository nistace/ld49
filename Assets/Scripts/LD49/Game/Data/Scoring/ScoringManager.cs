using System.Collections.Generic;
using System.Linq;
using LD49.Game.Data.Level;
using UnityEngine;
using Utils.Extensions;

namespace LD49.Game.Data.Scoring {
	public static class ScoringManager {
		private static Dictionary<EnvironmentObjectCategory, int>          globalObjectsDestroyed { get; } = new Dictionary<EnvironmentObjectCategory, int>();
		private static Dictionary<EnvironmentObjectCategory, int>          levelObjectsDestroyed  { get; } = new Dictionary<EnvironmentObjectCategory, int>();
		public static  IReadOnlyDictionary<EnvironmentObjectCategory, int> allObjectsDestroyed    => globalObjectsDestroyed;

		private static bool  initialized     { get; set; }
		private static float timeAtStart     { get; set; }
		private static float timeAtStop      { get; set; } = -1;
		private static int   levelsRestarted { get; set; }

		private static void RefreshInit() {
			if (initialized) return;
			EnvironmentObjectCategory.onObjectTookFirstDamage.AddListenerOnce(HandleDamagedObject);
			initialized = true;
		}

		public static void ResetGlobal() {
			RefreshInit();
			globalObjectsDestroyed.Clear();
			levelObjectsDestroyed.Clear();
			levelsRestarted = 0;
			timeAtStart = Time.time;
			timeAtStop = -1;
		}

		public static void StopTimer() => timeAtStop = Time.time;

		public static float GetTimer() => (timeAtStop > 0 ? timeAtStop : Time.time) - timeAtStart;

		public static void ResetForLevel() {
			RefreshInit();
			levelsRestarted++;
			levelObjectsDestroyed.Clear();
		}

		public static void ValidateLevel() {
			foreach (var levelCount in levelObjectsDestroyed) {
				if (!globalObjectsDestroyed.ContainsKey(levelCount.Key)) globalObjectsDestroyed.Add(levelCount.Key, 0);
				globalObjectsDestroyed[levelCount.Key] += levelCount.Value;
			}
			levelObjectsDestroyed.Clear();
		}

		private static void HandleDamagedObject(EnvironmentObjectCategory objectCategory) {
			if (!levelObjectsDestroyed.ContainsKey(objectCategory)) levelObjectsDestroyed.Add(objectCategory, 0);
			levelObjectsDestroyed[objectCategory]++;
		}

		public static int GetWarmongerScore() {
			var score = 500;
			score -= Mathf.CeilToInt(GetTimer());
			score -= levelsRestarted * 5;
			score += globalObjectsDestroyed.Union(levelObjectsDestroyed).Sum(t => t.Value * t.Key.aggressiveScore);
			return score.Clamp(0, 5000);
		}

		public static int GetPacifistScore() {
			var score = 1000;
			score -= Mathf.CeilToInt(GetTimer());
			score -= levelsRestarted * 5;
			score += globalObjectsDestroyed.Union(levelObjectsDestroyed).Sum(t => t.Value * t.Key.pacifistScore);
			return score.Clamp(0, 5000);
		}
	}
}