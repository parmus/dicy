using UnityEngine;

[ExecuteInEditMode]
public class NameByCoordinates : MonoBehaviour {
	[SerializeField] string Prefix = "";

	void LateUpdate () {
		gameObject.name = System.String.Format("{0} ({1}, {2})", Prefix, transform.position.x, transform.position.z);
	}
}
