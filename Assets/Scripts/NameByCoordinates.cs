using UnityEngine;

[ExecuteInEditMode]
public class NameByCoordinates : MonoBehaviour {
#if (UNITY_EDITOR)
	void LateUpdate () {
		foreach(Tile tile in GetComponentsInChildren(typeof(Tile))) {
			string prefix = tile.GetType().Name;
			tile.gameObject.name = System.String.Format("{0} ({1}, {2})", prefix, tile.transform.position.x, tile.transform.position.z);
		}
	}
#endif
}
