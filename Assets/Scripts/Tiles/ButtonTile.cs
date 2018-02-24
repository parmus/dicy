using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class ButtonTile : Tile {
	[SerializeField] CubeSideType TriggerCubeSideType;
	[SerializeField] Triggerable Triggerable;

  public override void Trigger(CubeSideType cubeSideType) {
		if (TriggerCubeSideType == cubeSideType) {
			Triggerable.Trigger();
    }
	}

	void OnDrawGizmos() {
		if (TriggerCubeSideType == null || Triggerable == null) {
			Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
			Gizmos.DrawCube(transform.position, new Vector3(1f,1f,1f));
		}
	}

	void OnDrawGizmosSelected() {
		if (Triggerable) {
			Gizmos.color = new Color(0f, 1f, 0f, 0.3f);
			Gizmos.DrawCube(Triggerable.transform.position, new Vector3(1f,1f,1f));
			Gizmos.DrawRay(Triggerable.transform.position, Vector3.up);
		}
	}

	void OnValidate() {
		MeshRenderer button = transform.GetChild(0).GetComponent<MeshRenderer>();
		if (TriggerCubeSideType != null) {
			button.material = TriggerCubeSideType.material;
		} else {
			button.material = null;
		}
	}
}
