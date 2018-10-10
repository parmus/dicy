using System.Collections;
using UnityEngine;

[SelectionBase]
public class Tile : MonoBehaviour {
	virtual public IEnumerator Enter(Cube cube) { yield return null; }
	virtual public void Leave(Cube cube) {}
}
