using UnityEngine;

[SelectionBase]
public class ButtonTile : Tile {
	[SerializeField] CubeColor TriggerColor;
	[SerializeField] Triggerable Triggerable;
	[SerializeField] MeshRenderer Indicator;

	[Header("Sounds")]
	[SerializeField] AudioClip TriggerSound;
	[SerializeField] AudioClip WrongColorSound;

	private AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource>();
	}

	public override void Enter(Player player) {
		if (player.BottomColor == TriggerColor) {
			audioSource.PlayOneShot(TriggerSound);
			Triggerable.Trigger();
    	} else {
			audioSource.PlayOneShot(WrongColorSound);
		}
	}

	void OnDrawGizmos() {
		if (TriggerColor == null || Triggerable == null) {
			Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
			Gizmos.DrawCube(transform.position, new Vector3(1f,1f,1f));
		}
	}

	void OnDrawGizmosSelected() {
		if (Triggerable) {
			Gizmos.color = new Color(0f, 1f, 0f, 0.3f);
			Gizmos.DrawCube(Triggerable.transform.position, new Vector3(1f,1f,1f));
			Gizmos.DrawRay(Triggerable.transform.position, Vector3.up);
		}
	}

	void OnValidate() {
		if (TriggerColor != null) {
			Indicator.material = TriggerColor.material;
		} else {
			Indicator.material = null;
		}
	}
}
