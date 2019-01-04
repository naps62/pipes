using UnityEngine;
using System;
using static System.Linq.Enumerable;

public class PipeGrid : MonoBehaviour {
  public int rows;
  public int cols;
  public GameObject cellPrefab;
  public Vector2 gridSize;

  void Start() {
    InitCells();
  }

  void OnDrawGizmos() {
    Gizmos.DrawWireCube(transform.position, gridSize);
  }

  public void InitCells() {
    var cellSize = gridSize / new Vector2(cols, rows);
    var offset = - gridSize / 2 + cellSize / 2;

    foreach(var row in Range(0, rows)) {
      foreach(var col in Range(0, cols)) {
        var position = new Vector3(col, row, 0) * cellSize + offset + (Vector2)transform.position;

        var cell = Instantiate(cellPrefab, position, Quaternion.identity);
        cell.transform.localScale = cellSize;
        cell.transform.parent = transform;
      }
    }
  }
}
