using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTile : Tile {
	[SerializeField] AnimationCurve AnimationCurve = new AnimationCurve(new Keyframe(0,0), new Keyframe(1, 1));
	[SerializeField] float RotationSpeed = 0.3f;

	override public IEnumerator Enter(Cube cube) {
		Transform cubeGraphics = cube.Graphics;

		Quaternion startRotation = cubeGraphics.localRotation;
		Quaternion endRotation = Quaternion.Euler(Vector3.up * 90f) * startRotation;

		float elapsed_time = 0;
		while(elapsed_time < RotationSpeed) {
			elapsed_time += Time.deltaTime;
			float delta = AnimationCurve.Evaluate(Mathf.Clamp(elapsed_time / RotationSpeed, 0f, 1f));
			cubeGraphics.localRotation = Quaternion.LerpUnclamped(startRotation, endRotation, delta);

			yield return new WaitForEndOfFrame();
		}
	}
}
