using UnityEngine;

[SelectionBase]
public class BridgeTile : Triggerable {
	private bool isOpen = true;
	private Animator animator;

    void Start () {
		animator = GetComponent<Animator>();
	}

    public override void Trigger() {
		isOpen = !isOpen;
		animator.SetBool("isOpen", isOpen);
    }
}
