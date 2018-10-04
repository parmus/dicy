using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AudioVolumeController))]
public class AudioVolumeControllerEditor : Editor {

	SerializedProperty audioMixerProp;
	SerializedProperty exposedParameterNameProp;
	SerializedProperty minValueProp;
	SerializedProperty maxValueProp;

	private bool _showMinMax = false;

	void OnEnable() {
		audioMixerProp = serializedObject.FindProperty("AudioMixer");
		exposedParameterNameProp = serializedObject.FindProperty("ExposedParameterName");
		minValueProp = serializedObject.FindProperty("MinValue");
		maxValueProp = serializedObject.FindProperty("MaxValue");
	}

	public override void OnInspectorGUI() {
		serializedObject.Update ();

		EditorGUILayout.PropertyField(audioMixerProp);
		EditorGUILayout.PropertyField(exposedParameterNameProp);

		_showMinMax = EditorGUILayout.Foldout(_showMinMax, "Parameter min/max values");
		if (_showMinMax) {
			EditorGUILayout.PropertyField(minValueProp);
			EditorGUILayout.PropertyField(maxValueProp);
		}

		serializedObject.ApplyModifiedProperties ();

		if (Application.isPlaying) {
			AudioVolumeController avc = target as AudioVolumeController;
			EditorGUILayout.LabelField("Volume", "" + avc.Volume);
			EditorGUILayout.LabelField("Muted", "" + avc.Muted);
		} else {
			EditorGUILayout.HelpBox("Changing volume and muting only works during runtime", MessageType.Info);
		};
	}
}
