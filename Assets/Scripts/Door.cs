using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Triggerable {
	[SerializeField][Range(0.1f, 0.5f)] float Speed = 0.3f;
	[SerializeField] GameObject graphics;
	private bool open = false;

    public override void Trigger() {
		if (!open) {
			StartCoroutine(IOpen());
		}
    }

	private IEnumerator IOpen(){
		open = true;
		Vector3 start = transform.position;
		Vector3 end = start + Vector3.down;

		float elapsed_time = 0;
		while(elapsed_time < Speed) {
			elapsed_time += Time.deltaTime;
			float delta = Mathf.Clamp(elapsed_time / Speed, 0f, 1f);

			graphics.transform.position = Vector3.Lerp(start, end, delta);
			yield return new WaitForEndOfFrame();
		}
	}
}
