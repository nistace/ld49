using System;
using System.Collections;
using System.Text;
using Menu;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace LD49.Game.Data.Scoring {
	public class LeaderBoardManager : MonoBehaviour {
		private static LeaderBoardManager instance { get; set; }

		private static string scoresUrl => Application.isEditor || Debug.isDebugBuild ? "http://localhost/ld49/scores" : "https://nathanistace.be/ludumdare49/scores";

		private void Awake() {
			instance = this;
		}

		public static void GetAllScores(UnityAction<ScoreList> callback, UnityAction errorCallback) => instance.StartCoroutine(DoGetAllScores(callback, errorCallback));

		private static IEnumerator DoGetAllScores(UnityAction<ScoreList> callback, UnityAction errorCallback) {
			using (var webRequest = UnityWebRequest.Get(scoresUrl)) {
				yield return webRequest.SendWebRequest();
				if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError) {
					Debug.Log(webRequest.error);
					errorCallback?.Invoke();
					yield break;
				}
				try {
					var data = JsonUtility.FromJson<ScoreList>(webRequest.downloadHandler.text);
					callback?.Invoke(data);
				}
				catch (Exception e) {
					Debug.LogError(e);
					errorCallback?.Invoke();
				}
			}
		}

		public static void SubmitScore(string nameInputValue, UnityAction<bool> callback) => instance.StartCoroutine(DoSubmitScore(
			new ScoreEntry(nameInputValue, ScoringManager.GetPacifistScore(), ScoringManager.GetWarmongerScore()), callback));

		private static IEnumerator DoSubmitScore(ScoreEntry data, UnityAction<bool> callback) {
			using (var webRequest = new UnityWebRequest(scoresUrl, "POST")) {
				webRequest.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(JsonUtility.ToJson(data)));
				webRequest.downloadHandler = new DownloadHandlerBuffer();
				webRequest.SetRequestHeader("Content-Type", "application/json");
				yield return webRequest.SendWebRequest();
				if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError) {
					Utils.Debugging.Debug.Log($"Error : {webRequest.downloadHandler.text}");
					callback.Invoke(false);
				}
				else callback.Invoke(true);
			}
		}
	}
}