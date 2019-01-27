using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellInitializer : MonoBehaviour {
  private enum Type { LINE, T, CROSS, TURN, END }

  private Type type;

  void Start() {
    var bounds = transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.bounds.size;

    // scale down the element according to the sprite size
    transform.localScale = (Vector2) transform.localScale / bounds;
    GetComponent<BoxCollider2D>().size = bounds;
  }

  public void SetGates((bool up, bool right, bool down, bool left) gates) {
    if (gates.up) transform.Find("Cell_End_Up").gameObject.SetActive(true);
    if (gates.right) transform.Find("Cell_End_Right").gameObject.SetActive(true);
    if (gates.down) transform.Find("Cell_End_Down").gameObject.SetActive(true);
    if (gates.left) transform.Find("Cell_End_Left").gameObject.SetActive(true);
  }
}