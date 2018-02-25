using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class ButtonTile : Tile {
	[SerializeField] CubeColor TriggerColor;
	[SerializeField] List<Triggerable> Triggerables = new List<Triggerable>();
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
			foreach(var triggerable in Triggerables) {
				if (triggerable) triggerable.Trigger();
			}
    	} else {
			audioSource.PlayOneShot(WrongColorSound);
		}
	}

	void OnDrawGizmos() {
		if (TriggerColor == null || Triggerables.Count == 0 || Triggerables.Exists(t => t == null)) {
			Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
			Gizmos.DrawCube(transform.position, new Vector3(1f,1f,1f));
		}
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = new Color(0f, 1f, 0f, 0.3f);
		foreach(var triggerable in Triggerables) {
			if (triggerable == null) continue;
			Gizmos.DrawCube(triggerable.transform.position, new Vector3(1f,1f,1f));
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
