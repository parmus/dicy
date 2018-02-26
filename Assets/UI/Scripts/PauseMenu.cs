using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    [SerializeField] GameObject PauseMenuUI;

    public static bool IsPaused { get { return paused; } }

    private static bool paused = false;

    void Start () {
		Resume();		
	}
	
	void Update () {
		if (Input.GetButtonDown("Cancel")) {
			if (paused) {
				Resume();
			} else {
				Pause();				
			}
		}		
	}

	public void Pause() {
		Time.timeScale = 0;
		paused = true;
		PauseMenuUI.SetActive(true);
	}

	public void Resume() {
		Time.timeScale = 1f;
		paused = false;
		PauseMenuUI.SetActive(false);
	}

	public void MainMenu() {
		Resume();
		SceneManager.LoadScene(0);
	}

	public void RestartLevel() {
		Resume();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
