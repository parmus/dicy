using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {
	private CanvasGroup canvasGroup;

	void Start () {
		canvasGroup = GetComponentInChildren<CanvasGroup>();

		canvasGroup.alpha = 1f;
		StartCoroutine(fadeIn());
	}

	public void LoadMainMenu() {
		LoadScene(0);
	}

	public void ReloadScene() {
		LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void LoadNextScene() {
		LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void LoadScene(int sceneId) {
		StartCoroutine(fadeToLevel(sceneId));
	}

	private IEnumerator fadeToLevel(int sceneId) {
		while(canvasGroup.alpha < 1.0f) {
			canvasGroup.alpha += Time.deltaTime;
			yield return new WaitForFixedUpdate();
		}

		SceneManager.LoadScene(sceneId);
	}

	private IEnumerator fadeIn() {
		while(canvasGroup.alpha > 0.0f) {
			canvasGroup.alpha -= Time.deltaTime;
			yield return new WaitForFixedUpdate();
		}
	}
}
