using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cube : MonoBehaviour {

	[Header("Movement")]
	[SerializeField][Range(0.1f, 1f)] float RotationSpeed = 0.3f;
	[SerializeField] Transform Graphics;
	[SerializeField] float MovementDelay = 0.2f;

	[Header("Electricution")]
	[SerializeField] AudioClip ElectricutionSound;
	[SerializeField] GameObject ElectricutionVFX;
	[SerializeField][Range(0.01f, 0.1f)] float ElectricutionShake = 0.05f;

	static int CUBE_LAYER_MASK = 1 << 8;
	static int WALKABLE_LAYER_MASK = 1 << 9;

	private bool canMove = true;
	private AudioSource audioSource;

    public CubeColor BottomColor {
        get {
            RaycastHit raycastHit;
            if (Physics.Raycast(Graphics.position, Vector3.down, out raycastHit, 1f, CUBE_LAYER_MASK)) {
                CubeSide cubeSide = raycastHit.collider.gameObject.GetComponent<CubeSide>();
                if (cubeSide != null) {
                    return cubeSide.CubeColor;
                }
            }
            Debug.LogError("No bottom side found -> This really should never happen!");
            throw new NoBottomSideFound();
        }
    }

	public void LevelComplete() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void RestartLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Electricte() {
		StartCoroutine(IElectricute());
	}

	void Start() {
		audioSource = GetComponent<AudioSource>();
	}

	public void Move(Vector3 direction) {
		if (canMove) {
			StartCoroutine(IMove(direction));
		}
	}

	private IEnumerator IElectricute() {
		canMove = false;
		float duration = ElectricutionSound.length;
		audioSource.PlayOneShot(ElectricutionSound);
		ElectricutionVFX.SetActive(true);

		Vector3 startPos = Graphics.localPosition;

		float elapsed_time = 0;
		while(elapsed_time < duration) {
			elapsed_time += Time.deltaTime;

			Vector3 offset = new Vector3(
				Random.Range(-ElectricutionShake, ElectricutionShake),
				Random.Range(0, ElectricutionShake),
				Random.Range(ElectricutionShake, ElectricutionShake)
			);
			Graphics.localPosition = startPos + offset;

			yield return new WaitForEndOfFrame();
		}

		RestartLevel();
	}

	private IEnumerator IMove(Vector3 moveDirection){
		if (!isLegalMove(moveDirection)) yield break;

		canMove = false;

		Tile leavingTile = getTileBelow();
		if (leavingTile != null) {
			leavingTile.Leave(this);
		}

		Vector3 rotationAxis = Vector3.Cross(Vector3.up, moveDirection);
		Vector3 savedCubePosition = Graphics.localPosition;

		Quaternion startRotation = Graphics.localRotation;
		Quaternion endRotation = Quaternion.Euler(rotationAxis * 90f) * startRotation;

		Vector3 rotationCenter = moveDirection * 0.5f;
		float cubeDiagonal = Mathf.Sqrt(2) * 0.5f;

		float elapsed_time = 0;
		while(elapsed_time < RotationSpeed) {
			elapsed_time += Time.deltaTime;
			float delta = Mathf.Clamp(elapsed_time / RotationSpeed, 0f, 1f);

			Graphics.localRotation = Quaternion.Lerp(startRotation, endRotation, delta);

			float angle = Mathf.Lerp(3*(Mathf.PI/4f), Mathf.PI/4f, delta);
			Vector3 rotationArm = (moveDirection * Mathf.Cos(angle)) + Vector3.up * Mathf.Sin(angle);
			Graphics.localPosition = rotationCenter + rotationArm * cubeDiagonal;

			yield return new WaitForEndOfFrame();
		}

		transform.localPosition = transform.localPosition + moveDirection;
		Graphics.localPosition = savedCubePosition;

		canMove = true;

		// Enter tile below
		Tile enteringTile = getTileBelow();
		if (enteringTile != null) {
			enteringTile.Enter(this);
		}

		yield return new WaitForSeconds(MovementDelay);
	}

	private bool isLegalMove(Vector3 moveDirection) {
		return Physics.Raycast(Graphics.position + moveDirection, Vector3.down, 1f, WALKABLE_LAYER_MASK);
	}

    private Tile getTileBelow() {
		RaycastHit raycastHit;
		if (Physics.Raycast(Graphics.position, Vector3.down, out raycastHit, 1f, WALKABLE_LAYER_MASK)) {
			return raycastHit.collider.gameObject.GetComponent<Tile>();
		}
		return null;
	}

	[System.Serializable()]
	public class NoBottomSideFound : System.Exception {}
}
