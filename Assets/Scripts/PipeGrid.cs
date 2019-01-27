using System;
using UnityEngine;
using static System.Linq.Enumerable;
using FieldN;

public class PipeGrid : MonoBehaviour {
  public int width;
  public int height;
  public GameObject cellPrefab;
  public Vector2 gridSize;

  private Field field;

  void Start() {
    InitCells();

    SAW.Generate(5, 5);
  }

  void OnDrawGizmos() {
    Gizmos.DrawWireCube(transform.position, gridSize);
  }

  public void InitCells() {
    field = FieldN.Generator.GenerateWithRecursiveBacktracking(width, height);

    var cellSize = gridSize / new Vector2(width, height);
    var offset = -gridSize / 2 + cellSize / 2;

    foreach (var y in Range(0, height)) {
      foreach (var x in Range(0, width)) {
        // var position = new Vector3(y, x, 0) * cellSize + offset + (Vector2) transform.position;
        var position = new Vector3(x, height - 1 - y, 0) * cellSize + offset + (Vector2) transform.position;

        var cell = Instantiate(cellPrefab, position, Quaternion.identity);
        cell.transform.localScale = cellSize;
        cell.transform.parent = transform;
        cell.name = $"Cell_{x}_{y}";
        cell.GetComponent<CellInitializer>().SetGates(field.GetGates(x, y));
      }
    }
  }
}