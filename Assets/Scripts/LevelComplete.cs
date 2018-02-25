using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : Tile {
    public override void Trigger(CubeSideType cubeSideType) {
  		Debug.Log("Win!");
      // TODO: Win animation?
		  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
