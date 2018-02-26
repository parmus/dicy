using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AutoSelect : MonoBehaviour {
	void OnEnable() {
		StartCoroutine(selectFirst());
	}

	private IEnumerator selectFirst() {
		Selectable firstSelectable = GetComponentInChildren<Selectable>();
		if (firstSelectable) {
			EventSystem.current.SetSelectedGameObject(null);
			yield return null;
			firstSelectable.Select();
		}
	}
}
