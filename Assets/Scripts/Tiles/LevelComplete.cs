using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : Tile {
    public override void Enter(Cube cube) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
