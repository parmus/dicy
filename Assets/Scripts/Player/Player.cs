using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField][Range(0.1f, 1f)] float RotationSpeed = 0.3f;
	[SerializeField] GameObject Cube;

	static int CUBE_LAYER_MASK = 1 << 8;
	static int WALKABLE_LAYER_MASK = 1 << 9;

	private bool moving = false;

	void Update () {
		if (!moving){
			if (Input.GetKeyDown(KeyCode.W)){
				StartCoroutine(IMove(Vector3.forward));
			} else if (Input.GetKeyDown(KeyCode.S)){
				StartCoroutine(IMove(Vector3.back));
			} else if (Input.GetKeyDown(KeyCode.A)){
				StartCoroutine(IMove(Vector3.left));
			} else if (Input.GetKeyDown(KeyCode.D)){
				StartCoroutine(IMove(Vector3.right));
			}
		}
	}

	private IEnumerator IMove(Vector3 moveDirection){
		if (!isLegalMove(moveDirection)) yield break;

		moving = true;

		Vector3 rotationAxis = Vector3.Cross(Vector3.up, moveDirection);
		Vector3 savedCubePosition = Cube.transform.localPosition;

		Quaternion startRotation = Cube.transform.localRotation;
		Quaternion endRotation = Quaternion.Euler(rotationAxis * 90f) * startRotation;

		Vector3 rotationCenter = moveDirection * 0.5f;
		float cubeDiagonal = Mathf.Sqrt(2) * 0.5f;

		float elapsed_time = 0;
		while(elapsed_time < RotationSpeed) {
			elapsed_time += Time.deltaTime;
			float delta = Mathf.Clamp(elapsed_time / RotationSpeed, 0f, 1f);

			Cube.transform.localRotation = Quaternion.Lerp(startRotation, endRotation, delta);

			float angle = Mathf.Lerp(3*(Mathf.PI/4f), Mathf.PI/4f, delta);
			Vector3 rotationArm = (moveDirection * Mathf.Cos(angle)) + Vector3.up * Mathf.Sin(angle);
			Cube.transform.localPosition = rotationCenter + rotationArm * cubeDiagonal;

			yield return new WaitForEndOfFrame();
		}

		transform.localPosition = transform.localPosition + moveDirection;
		Cube.transform.localPosition = savedCubePosition;

		// TODO: Trigger tile below
		enterTile();

		moving = false;
	}

	private bool isLegalMove(Vector3 moveDirection) {
		return Physics.Raycast(Cube.transform.position + moveDirection, Vector3.down, 1f, WALKABLE_LAYER_MASK);
	}

	private CubeSide getCubeSide(Vector3 direction) {
		RaycastHit raycastHit;
		if (Physics.Raycast(Cube.transform.position, direction, out raycastHit, 1f, CUBE_LAYER_MASK)) {
			return raycastHit.collider.gameObject.GetComponent<CubeSide>();
		}
		return null;
	}

	private void enterTile(){
		CubeSide bottomSide = getCubeSide(Vector3.down);

		RaycastHit raycastHit;
		if (Physics.Raycast(Cube.transform.position, Vector3.down, out raycastHit, 1f, WALKABLE_LAYER_MASK)) {
			Tile tile = raycastHit.collider.gameObject.GetComponent<Tile>();
			if (tile != null) {
				tile.Enter(bottomSide.CubeSideType);
			}
		}
	
	}
}
