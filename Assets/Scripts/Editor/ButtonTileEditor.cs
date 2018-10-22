using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ButtonTile))]
public class ButtonTileEditor : Editor {

	private List<TriggerableTile> triggerables = new List<TriggerableTile>();
	private ButtonTile buttonTile;

	void OnEnable(){
		buttonTile = target as ButtonTile;

		triggerables.Clear();
		foreach(TriggerableTile triggerable in FindObjectsOfType(typeof(TriggerableTile))) {
			triggerables.Add(triggerable);
		}

		SceneView.onSceneGUIDelegate += DrawConnectionButtons;
		if (SceneView.lastActiveSceneView != null) SceneView.lastActiveSceneView.Repaint();
	}

	void OnDisable() {
		SceneView.onSceneGUIDelegate -= DrawConnectionButtons;
	}

	void DrawConnectionButtons(SceneView sceneView) {
		Vector2 buttonSize = new Vector2(40, 20);

		Handles.BeginGUI();
		foreach(TriggerableTile triggerable in triggerables) {
			Vector3 screenPoint = sceneView.camera.WorldToScreenPoint(triggerable.transform.position);
			Vector2 buttonPosition = new Vector2(
				screenPoint.x - buttonSize.x / 2,
				 sceneView.position.size.y - screenPoint.y - buttonSize.y
			);
			if (buttonTile.Triggerables.Contains(triggerable)) {
				if (GUI.Button(new Rect(buttonPosition, buttonSize), "╠═╣")) {
					buttonTile.Triggerables.Remove(triggerable);
				};
			} else {
				if (GUI.Button(new Rect(buttonPosition, buttonSize), "║ ║")) {
					buttonTile.Triggerables.Add(triggerable);
				};
			}
			
		}
		Handles.EndGUI();
	}
}
