using UnityEngine;

[SelectionBase]
public class Tile : MonoBehaviour {
	virtual public void Enter(Cube cube) {}
	virtual public void Leave(Cube cube) {}
}
