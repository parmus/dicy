using UnityEngine;

public class LevelComplete : Tile {
    public override void Enter(Player player) {
  		Debug.Log("Win!");
        player.LevelComplete();
    }
}
