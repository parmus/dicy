using UnityEngine;

[SelectionBase]
public class BridgeTile : Triggerable {
	[SerializeField] bool startOpen = true;

	private Animator animator;

  void Start () {
		animator = GetComponent<Animator>();
		animator.SetBool("startOpen", startOpen);
	}

  public override void Trigger() {
		animator.SetTrigger("Toggle");
	}

	void OnDrawGizmos() {
		if (!startOpen) {
			Gizmos.color = new Color(0, 1, 0, 0.3f);
			Gizmos.DrawCube(transform.position + Vector3.up * 0.45f, new Vector3(0.99f, 0.1f, 0.99f));
		}
	}
}
