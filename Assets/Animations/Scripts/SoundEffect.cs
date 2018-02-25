using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : StateMachineBehaviour {
	[SerializeField] AudioClip AudioClip;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.gameObject.GetComponent<AudioSource>().PlayOneShot(AudioClip);	
	}
}
