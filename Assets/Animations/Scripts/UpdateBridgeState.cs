using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBridgeState : StateMachineBehaviour {
	[SerializeField] bool Enable;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.gameObject.GetComponentInParent<Collider>().enabled = Enable;
	}
}
