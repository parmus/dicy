using UnityEngine;

public class MainMenu : MonoBehaviour {
	[SerializeField] SceneFader SceneFader;

	public void StartGame() {
		SceneFader.LoadNextScene();
	}

	public void Quit() {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}
