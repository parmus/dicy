using UnityEngine;

public class CubeSide : MonoBehaviour {
	public CubeColor CubeColor;

	void OnValidate() {
		if (CubeColor != null) {
			//GetComponent<MeshRenderer>().material = CubeColor.material;
		}	
	}
}
