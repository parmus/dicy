using UnityEngine;

[SelectionBase]
abstract public class Tile : MonoBehaviour {
	virtual public void Enter(Player player) {}
	virtual public void Leave(Player player) {}
}
