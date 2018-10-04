using UnityEngine;
using UnityEngine.UI;

public class EndCredits : MonoBehaviour {
	[SerializeField] float ScrollSpeed = 50f;
	[SerializeField] float StartOffset = 25f;
	[SerializeField] SceneFader SceneFader;

	private RectTransform rectTransform;

	private float position;
	private float height;

	void Start() {
		rectTransform = GetComponent<RectTransform>();

		float parentHeight = transform.parent.GetComponent<RectTransform>().rect.height;
		position = -(parentHeight + StartOffset);
		height = rectTransform.rect.height;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			SceneFader.LoadMainMenu();
		}

		scrollCredits();
	}

	private void scrollCredits() {
		if (position > height) mainMenu();

		position += ScrollSpeed * Time.deltaTime;

		Vector2 offsetMax = rectTransform.offsetMax;
		offsetMax.y = position;
		rectTransform.offsetMax = offsetMax;

		Vector2 offsetMin = rectTransform.offsetMin;
		offsetMin.y = offsetMax.y - height;
		rectTransform.offsetMin = offsetMin;
	}

	private void mainMenu() {
		SceneFader.LoadMainMenu();
	}
}
