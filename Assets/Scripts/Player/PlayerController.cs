using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Cube[] cubes;

	// Use this for initialization
	void Start () {
		cubes = FindObjectsOfType<Cube>();
	}
	
	void Update () {
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		if (Mathf.Abs(horizontal) > Mathf.Epsilon) {
			foreach(Cube cube in cubes) {
				cube.Move(Vector3.right * Mathf.Sign(horizontal));
			}
		} else if (Mathf.Abs(vertical) > Mathf.Epsilon) {
			foreach(Cube cube in cubes) {
				cube.Move(Vector3.forward * Mathf.Sign(vertical));
			}
		}
	}
}
