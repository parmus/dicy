using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileTile : Tile {
  private Animator animator;

  void Start () {
	animator = GetComponent<Animator>();
  }

  override public void Leave(Player player) {
	  animator.SetTrigger("Break");
  }
}