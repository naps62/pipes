using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellModel : MonoBehaviour {
  public int x, y;

  public void Initialize(int x, int y) {
    this.x = x;
    this.y = y;
  }
}