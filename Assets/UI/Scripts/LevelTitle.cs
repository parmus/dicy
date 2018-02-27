using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTitle : MonoBehaviour {
	void Start () {
		TMPro.TMP_Text label = GetComponent<TMPro.TMP_Text>();
		label.SetText(SceneManager.GetActiveScene().name);
		
	}
}
