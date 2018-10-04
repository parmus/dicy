using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName="Audio/Volume Controller")]
public class AudioVolumeController : ScriptableObject {
	public AudioMixer AudioMixer;
    public string ExposedParameterName;
    public float MinValue = -80;
    public float MaxValue = 20;
    
    private float _volumeBeforeMuted;
    private bool _muted = false;

    public float Volume
    {
        get
        {
            if (_muted) {
                return Mathf.InverseLerp(MinValue, MaxValue, _volumeBeforeMuted);
            } else {
                float value = 0;
                if (AudioMixer != null) {
                    AudioMixer.GetFloat(ExposedParameterName, out value);
                }
                return Mathf.InverseLerp(MinValue, MaxValue, _volumeBeforeMuted);
            }
        }

        set
        {
            _muted = false;
            if (AudioMixer != null) {
                AudioMixer.SetFloat(ExposedParameterName, Mathf.Lerp(MinValue, MaxValue, value));
            }
        }
    }

    public bool Muted
    {
        get
        {
            return _muted;
        }

        set
        {
            _muted = value;
            if (_muted) {
                AudioMixer.GetFloat(ExposedParameterName, out _volumeBeforeMuted);
                AudioMixer.SetFloat(ExposedParameterName, MinValue);
            } else {
                AudioMixer.SetFloat(ExposedParameterName, _volumeBeforeMuted);
            }
        }
    }

    void OnEnable() {
        _muted = false;
    }
}
