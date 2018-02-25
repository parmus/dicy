using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Door : Triggerable {
	private Animator animator;
	private bool open = false;

	void Start() {
		animator = GetComponent<Animator>();
		open = animator.GetBool("isOpen");
	}

    public override void Trigger() {
		open = !open;
		animator.SetBool("isOpen", open);
    }
}
