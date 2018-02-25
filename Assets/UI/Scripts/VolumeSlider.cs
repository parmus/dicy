using UnityEngine;

public class VolumeSlider : MonoBehaviour {
	[SerializeField] UnityEngine.Audio.AudioMixer AudioMixer;
	[SerializeField] string ExposedParameterName;

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
			float value;
			AudioMixer.GetFloat(ExposedParameterName, out value);
			slider.value = value;
		}
	}

	void SetVolume(float value) {
		AudioMixer.SetFloat(ExposedParameterName, value);
	}
}
