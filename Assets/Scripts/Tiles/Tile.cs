using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Tile : MonoBehaviour {
	virtual public void Enter(CubeSideType cubeSideType) {}
}
