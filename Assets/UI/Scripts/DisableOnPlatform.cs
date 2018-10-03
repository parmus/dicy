using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnPlatform : MonoBehaviour {
	[SerializeField] RuntimePlatform Platform;

	void OnEnable() {
		if (Application.platform == Platform) {
			gameObject.SetActive(false);
		}
	}
}
