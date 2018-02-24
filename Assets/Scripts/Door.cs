using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Door : Triggerable {
	[SerializeField] AudioClip MovingSound;
	[SerializeField] GameObject graphics;

	new private Collider collider;
	private AudioSource audioSource;
	private bool moving = false;
	private bool open = false;

	void Start() {
		audioSource = GetComponent<AudioSource>();
		collider = GetComponent<Collider>();
	}

    public override void Trigger() {
		if (!moving) {
			if (open) {
				StartCoroutine(IClose());
			} else {
				StartCoroutine(IOpen());
			}
		}
    }

	private IEnumerator IOpen(){
		moving = true;
		audioSource.PlayOneShot(MovingSound);
		Vector3 start = graphics.transform.position;
		Vector3 end = start + Vector3.down;

		float speed = MovingSound.length;
		float elapsed_time = 0;
		while(elapsed_time < speed) {
			elapsed_time += Time.deltaTime;
			float delta = Mathf.Clamp(elapsed_time / speed, 0f, 1f);

			graphics.transform.position = Vector3.Lerp(start, end, delta);
			yield return new WaitForEndOfFrame();
		}
		open = true;
		collider.enabled = false;
		moving = false;
	}

	private IEnumerator IClose(){
		moving = true;
		open = false;
		collider.enabled = true;

		audioSource.PlayOneShot(MovingSound);
		Vector3 start = graphics.transform.position;
		Vector3 end = start + Vector3.up;

		float speed = MovingSound.length;
		float elapsed_time = 0;
		while(elapsed_time < speed) {
			elapsed_time += Time.deltaTime;
			float delta = Mathf.Clamp(elapsed_time / speed, 0f, 1f);

			graphics.transform.position = Vector3.Lerp(start, end, delta);
			yield return new WaitForEndOfFrame();
		}
		moving = false;
	}
}
