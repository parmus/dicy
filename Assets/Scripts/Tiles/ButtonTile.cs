using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTile : Tile {
	[SerializeField] CubeSideType TriggerCubeSideType;
	[SerializeField] Triggerable Triggerable;

  public override void Trigger(CubeSideType cubeSideType) {
		if (TriggerCubeSideType == cubeSideType) {
			Triggerable.Trigger();
    }
	}
}
