using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCreditMenu : MonoBehaviour {

	public void MainMenu() {
		SceneManager.LoadScene(0);
	}

	public void Quit() {
		Application.Quit();
	}
}
