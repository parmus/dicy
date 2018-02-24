using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeSide : MonoBehaviour {
	public CubeSideType CubeSideType;

	private MeshRenderer meshRenderer;

	// Use this for initialization
	void Start () {
		meshRenderer = GetComponent<MeshRenderer>();
	}

	void Update() {
		if (CubeSideType != null) {
			meshRenderer.material = CubeSideType.material;
		}	
	}
}
