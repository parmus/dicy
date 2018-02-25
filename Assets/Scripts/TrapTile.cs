using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[SelectionBase]
public class TrapTile : Tile {
	[SerializeField] CubeSideType TrapColor;
	[SerializeField] ParticleSystem Skulls;

    public override void Trigger(CubeSideType cubeSideType) {
		if (cubeSideType == TrapColor) {
			Debug.Log("Player died!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
    }

	void OnDrawGizmos() {
		if (TrapColor == null) {
			Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
			Gizmos.DrawCube(transform.position, new Vector3(1f,1f,1f));
		}
	}

	void OnValidate() {
		if (TrapColor != null) {
			var main = Skulls.main;
			main.startColor = TrapColor.material.color;
		}
	}
}
