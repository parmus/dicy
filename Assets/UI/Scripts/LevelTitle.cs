using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTitle : MonoBehaviour {
	void Start () {
		Text label = GetComponent<Text>();
		label.text = SceneManager.GetActiveScene().name;
		
	}
}
