using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : Tile {
    public override IEnumerator Enter(Cube cube) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        yield return null;
    }
}
