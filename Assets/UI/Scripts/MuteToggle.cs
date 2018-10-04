using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour {
	[SerializeField] AudioVolumeController AudioVolumeController;

	void Start () {
		Toggle toggle = GetComponent<Toggle>();
		toggle.isOn = AudioVolumeController.Muted;
		toggle.onValueChanged.AddListener(this.Muted);
	}

	public void Muted(bool muted) {
		AudioVolumeController.Muted = muted;
	}
}
