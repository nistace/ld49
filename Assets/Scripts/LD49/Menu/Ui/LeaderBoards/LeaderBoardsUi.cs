using System;
using System.Linq;
using LD49.Game.Data.Scoring;
using UnityEngine;
using Utils.Extensions;

namespace LD49.Menu.Ui.LeaderBoards {
	public class LeaderBoardsUi : MonoBehaviour {
		[SerializeField] protected LeaderBoardLineUi _pacifistLinePrefab;
		[SerializeField] protected Transform         _pacifistLinesContainer;
		[SerializeField] protected LeaderBoardLineUi _warmongerLinePrefab;
		[SerializeField] protected Transform         _warmongerLinesContainer;

		protected private void Start() {
			LeaderBoardManager.GetAllScores(HandleAllScoresReceived, HandleError);
		}

		private void HandleAllScoresReceived(ScoreList scoreList) {
			FillInLeaderBoard(scoreList, _pacifistLinesContainer, _pacifistLinePrefab, t => t.pacifist);
			FillInLeaderBoard(scoreList, _warmongerLinesContainer, _warmongerLinePrefab, t => t.warmonger);
		}

		private static void FillInLeaderBoard(ScoreList scoreList, Transform container, LeaderBoardLineUi prefab, Func<ScoreEntry, int> scoreFunc) {
			container.ClearChildren();
			scoreList.entries.OrderByDescending(scoreFunc).ToList().ForEach((t, i) => Instantiate(prefab, container).Set(i + 1, t.name, scoreFunc(t)));
		}

		private void HandleError() {
			_pacifistLinesContainer.ClearChildren();
			Instantiate(_pacifistLinePrefab, _pacifistLinesContainer).Set(0, "An error occured...", 0);
			_warmongerLinesContainer.ClearChildren();
			Instantiate(_warmongerLinePrefab, _warmongerLinesContainer).Set(0, "An error occured...", 0);
		}
	}
}