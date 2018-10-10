using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[SelectionBase]
public class TrapTile : Tile {
	[SerializeField] CubeColor TrapColor;
	[SerializeField] ParticleSystem Skulls;

	[Header("Electricution")]
	[SerializeField] AudioClip ElectricutionSound;
	[SerializeField] GameObject VFXPrefab;
	[SerializeField][Range(0.01f, 0.1f)] float ElectricutionShake = 0.05f;

	private AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource>();
	}

    public override IEnumerator Enter(Cube cube) {
		if (cube.BottomColor == TrapColor) {
			yield return StartCoroutine(IElectricute(cube));
		}
    }

	private IEnumerator IElectricute(Cube cube) {
		Transform cubeGraphics = cube.Graphics;

		float duration = ElectricutionSound.length;
		audioSource.PlayOneShot(ElectricutionSound);
		Instantiate(VFXPrefab, cubeGraphics.position, Quaternion.identity);

		Vector3 startPos = cubeGraphics.localPosition;

		float elapsed_time = 0;
		while(elapsed_time < duration) {
			elapsed_time += Time.deltaTime;

			Vector3 offset = new Vector3(
				Random.Range(-ElectricutionShake, ElectricutionShake),
				Random.Range(0, ElectricutionShake),
				Random.Range(ElectricutionShake, ElectricutionShake)
			);
			cubeGraphics.localPosition = startPos + offset;

			yield return new WaitForEndOfFrame();
		}

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}



	#region Editor functions

	void OnDrawGizmos() {
		if (TrapColor == null) {
			Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
			Gizmos.DrawCube(transform.position + new Vector3(0f, -0.5f, 0f), new Vector3(1f,1f,1f));
		}
	}

	void OnValidate() {
		if (TrapColor != null) {
			var main = Skulls.main;
			main.startColor = TrapColor.material.color;
		}
	}

	#endregion
}
