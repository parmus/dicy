using UnityEngine;

public class VolumeSlider : MonoBehaviour {
	[SerializeField] AudioVolumeController AudioVolumeController;

	private	UnityEngine.UI.Slider slider;

	void Start() {
		slider = GetComponent<UnityEngine.UI.Slider>();

		UnityEngine.UI.Slider.SliderEvent onValueChanged = new UnityEngine.UI.Slider.SliderEvent();
		onValueChanged.AddListener(SetVolume);
		slider.onValueChanged = onValueChanged;		

		updateSlider();
	}

	void OnEnable(){
		updateSlider();
	}

	private void updateSlider() {
		if (slider != null) {
			slider.value = AudioVolumeController.Volume;
		}
	}

	void SetVolume(float value) {
		AudioVolumeController.Volume = value;
	}
}
