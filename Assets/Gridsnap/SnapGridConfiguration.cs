using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="SnapGrid configuration")]
public class SnapGridConfiguration : ScriptableObject {
	public Vector3 GridSize = new Vector3(1f, 1f, 1f);
	public Vector3 GridOffset;

	[Header("Lock axis")]
	public bool LockXAxis = false;
	public bool LockYAxis = false;
	public bool LockZAxis = false;
}
