using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSide : MonoBehaviour {
	public CubeSideType CubeSideType;

	void OnValidate() {
		if (CubeSideType != null) {
			GetComponent<MeshRenderer>().material = CubeSideType.material;
		}	
	}
}
