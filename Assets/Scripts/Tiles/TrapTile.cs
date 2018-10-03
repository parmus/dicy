using UnityEngine;

[SelectionBase]
public class TrapTile : Tile {
	[SerializeField] CubeColor TrapColor;
	[SerializeField] ParticleSystem Skulls;

    public override void Enter(Player player) {
		if (player.BottomColor == TrapColor) {
			player.Electricte();
		}
    }

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
}
