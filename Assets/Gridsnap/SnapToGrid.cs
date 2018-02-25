using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SnapToGrid : MonoBehaviour {
	[SerializeField] SnapGridConfiguration SnapGridConfiguration;


	void Update () {
		if (SnapGridConfiguration == null) return;

		Vector3 positionWithoutOffset = transform.position - SnapGridConfiguration.GridOffset;

		Vector3 snappedPosition = new Vector3(
			Mathf.RoundToInt(positionWithoutOffset.x / SnapGridConfiguration.GridSize.x) * SnapGridConfiguration.GridSize.x,
			Mathf.RoundToInt(positionWithoutOffset.y / SnapGridConfiguration.GridSize.y) * SnapGridConfiguration.GridSize.y,
			Mathf.RoundToInt(positionWithoutOffset.z / SnapGridConfiguration.GridSize.z) * SnapGridConfiguration.GridSize.z
		) + SnapGridConfiguration.GridOffset;		
		if (SnapGridConfiguration.LockXAxis) {
			snappedPosition.x = SnapGridConfiguration.GridOffset.x;
		}
		if (SnapGridConfiguration.LockYAxis) {
			snappedPosition.y = SnapGridConfiguration.GridOffset.y;
		}
		if (SnapGridConfiguration.LockZAxis) {
			snappedPosition.z = SnapGridConfiguration.GridOffset.z;
		}
		transform.position = snappedPosition;

		Vector3 rotation = transform.localRotation.eulerAngles;
		Vector3 snappedRotation = new Vector3(
			Mathf.RoundToInt(rotation.x / 90) * 90,
			Mathf.RoundToInt(rotation.y / 90) * 90,
			Mathf.RoundToInt(rotation.z / 90) * 90
		);
		transform.localRotation = Quaternion.Euler(snappedRotation);
	}
}
