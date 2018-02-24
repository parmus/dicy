using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Tile : MonoBehaviour {
	abstract public void Trigger(CubeSideType cubeSideType);
}
