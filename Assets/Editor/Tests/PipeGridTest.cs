using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
  public class PipeGridTest {
    [UnityTest]
    public IEnumerator CellsAreInitializedCorrectly() {
      var obj = this.buildPipeGrid();
      var grid = obj.GetComponent<PipeGrid>();

      grid.width = 5;
      grid.height = 5;
      grid.gridSize = new Vector2(10, 10);

      grid.InitCells();

      // we have the expected number of cells
      Assert.AreEqual(obj.transform.childCount, 25);

      // all cells are in different positions
      var positions = new HashSet<Vector3>();
      foreach (Transform child in obj.transform) {
        positions.Add(child.transform.position);
      }
      Assert.AreEqual(positions.Count, 25);

      yield return null;
    }

    private GameObject buildPipeGrid() {
      var obj = new GameObject();

      obj.AddComponent<PipeGrid>();

      PipeGrid grid = obj.GetComponent<PipeGrid>();
      grid.cellPrefab = new GameObject();
      grid.cellPrefab.AddComponent<CellInitializer>();
      grid.width = 5;
      grid.height = 5;

      var texture = new Texture2D(4, 4, TextureFormat.DXT1, false);

      return obj;
    }
  }
}