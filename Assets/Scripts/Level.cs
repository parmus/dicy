#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Level : MonoBehaviour {

	#region Scene view editor 
	private List<GameObject> tilePrefabs = new List<GameObject>();

	void OnEnable () {
		if (!Application.isPlaying) {
			LoadTileButtons();
			SceneView.onSceneGUIDelegate -= OnSceneGUI;
			SceneView.onSceneGUIDelegate += OnSceneGUI;
		}
	}

	void OnDisable() {
			SceneView.onSceneGUIDelegate -= OnSceneGUI;
	}

	void OnSceneGUI(SceneView sceneView) {
		Rect rect = new Rect(20,50,70,100);
		GUILayout.Window(0, rect, CreateButtonsWindow, "Level editor");
	}

	void CreateButtonsWindow(int windowID) {
		GUILayout.Label("Create tiles");

		foreach(GameObject prefab in tilePrefabs) {
			if (GUILayout.Button(prefab.name)) {
				GameObject newTile = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
				newTile.transform.parent = transform;
				Selection.activeGameObject = newTile;
			}
		}

		GUILayout.Label("Camera controls");

		if (GUILayout.Button("Top view")) {
			SceneView.lastActiveSceneView.LookAt(transform.position, Quaternion.Euler(90, 0, 0), 10f, true);
		}
		
		if (GUILayout.Button("Level view")) {
			SceneView.lastActiveSceneView.orthographic = false;
			SceneView.lastActiveSceneView.AlignViewToObject(Camera.main.transform);
		}
	}

	public void LoadTileButtons() {
		tilePrefabs.Clear();
		string[] guids = AssetDatabase.FindAssets("t:Object");
		foreach(string guid in guids) {
			string path = AssetDatabase.GUIDToAssetPath(guid);
			Object obj = AssetDatabase.LoadMainAssetAtPath(path);
			if (obj == null) continue;
			if (PrefabUtility.GetPrefabType(obj) != PrefabType.Prefab) continue;
			GameObject gameObject = obj as GameObject;
			if (gameObject.GetComponent<Tile>() == null) continue;
			tilePrefabs.Add(gameObject);
		}

		tilePrefabs.Sort((o1,o2)=>o1.name.CompareTo(o2.name));
	}
	#endregion

	#region NameByCoordinate
	void LateUpdate () {
		foreach(Tile tile in GetComponentsInChildren(typeof(Tile))) {
			string prefix = tile.GetType().Name;
			tile.gameObject.name = System.String.Format("{0} ({1}, {2})", prefix, tile.transform.position.x, tile.transform.position.z);
		}
	}
	#endregion
}
#endif