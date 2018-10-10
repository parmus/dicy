using UnityEngine;

public class LevelComplete : Tile {
    public override void Enter(Cube cube) {
        cube.LevelComplete();
    }
}
