using UnityEngine;

[ExecuteInEditMode]
public class NameByCoordinates : MonoBehaviour {
#if (UNITY_EDITOR)
	void LateUpdate () {
		foreach(Tile tile in GetComponentsInChildren(typeof(Tile))) {
			string prefix = tile.GetType().Name;
			tile.gameObject.name = System.String.Format("{0} ({1}, {2})", prefix, tile.transform.position.x, tile.transform.position.z);
		}
		foreach(Triggerable triggerable in GetComponentsInChildren(typeof(Triggerable))) {
			string prefix = triggerable.GetType().Name;
			triggerable.gameObject.name = System.String.Format("{0} ({1}, {2})", prefix, triggerable.transform.position.x, triggerable.transform.position.z);
		}
	}
#endif
}
