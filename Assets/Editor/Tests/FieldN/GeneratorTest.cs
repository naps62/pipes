using System.Collections;
using System.Collections.Generic;
using FieldN;
using NUnit.Framework;
using UnityEngine;

namespace Tests {
  public class GeneratorTest {
    [Test]
    public void FullyOpenField1x1() {
      var field = Generator.GenerateFullyOpenField(1, 1);

      Assert.AreEqual(field.width, 1);
      Assert.AreEqual(field.height, 1);

      Assert.False(field.GetGate(0, 0, Field.Direction.DOWN));
      Assert.False(field.GetGate(0, 0, Field.Direction.RIGHT));
      Assert.False(field.GetGate(0, 0, Field.Direction.UP));
      Assert.False(field.GetGate(0, 0, Field.Direction.LEFT));
    }

    [Test]
    public void FullyOpenField2x2() {
      var field = Generator.GenerateFullyOpenField(2, 2);

      // check inner gates are all open
      Assert.True(field.GetGate(0, 0, Field.Direction.DOWN));
      Assert.True(field.GetGate(0, 0, Field.Direction.RIGHT));
      Assert.True(field.GetGate(1, 0, Field.Direction.DOWN));
      Assert.True(field.GetGate(1, 0, Field.Direction.LEFT));
      Assert.True(field.GetGate(0, 1, Field.Direction.RIGHT));
      Assert.True(field.GetGate(0, 1, Field.Direction.UP));
      Assert.True(field.GetGate(1, 1, Field.Direction.LEFT));
      Assert.True(field.GetGate(1, 1, Field.Direction.UP));

      // check borders are closed
      Assert.False(field.GetGate(0, 0, Field.Direction.UP));
      Assert.False(field.GetGate(0, 0, Field.Direction.LEFT));
      Assert.False(field.GetGate(1, 0, Field.Direction.UP));
      Assert.False(field.GetGate(1, 0, Field.Direction.RIGHT));
      Assert.False(field.GetGate(0, 1, Field.Direction.LEFT));
      Assert.False(field.GetGate(0, 1, Field.Direction.DOWN));
      Assert.False(field.GetGate(1, 1, Field.Direction.RIGHT));
      Assert.False(field.GetGate(1, 1, Field.Direction.DOWN));
    }

    [Test, Timeout(2000)]
    public void RecursiveBacktrackingFillsAllCells() {
      var width = 3;
      var height = 3;

      var field = Generator.GenerateWithRecursiveBacktracking(width, height);

      var visited = new bool[width, height];
      var stack = new Stack < (int x, int y) > ();

      var x = UnityEngine.Random.Range(0, width);
      var y = UnityEngine.Random.Range(0, height);

      // flood the field again
      visited[x, y] = true;
      var visitedCount = 1;
      stack.Push((x, y));

          Debug.Log("checking " + x + ", " + y);
      while (visitedCount < width * height) {
        (x, y) = getUnvisitedNeighbour(field, visited, x, y, width, height);

        if (x == -1) {
          (x, y) = stack.Pop();
          Debug.Log("backtracking to " + x + ", " + y);
        } else {
          Debug.Log("checking " + x + ", " + y);
          visited[x, y] = true;
          visitedCount++;
          stack.Push((x, y));
        }
      }

      Assert.AreEqual(width * height, visitedCount);
    }

    private(int, int) getUnvisitedNeighbour(Field field, bool[, ] visited, int x, int y, int width, int height) {

      IEnumerable < (int, int, Field.Direction) > options = new List < (int, int, Field.Direction) > () {
        (x, y - 1, Field.Direction.UP),
        (x, y + 1, Field.Direction.DOWN),
        (x - 1, y, Field.Direction.LEFT),
        (x + 1, y, Field.Direction.RIGHT)
      };

      foreach((int x, int y, Field.Direction direction) option in options) {
        Debug.Log("trying " + option.x + ", " + option.y + " " + option.direction + " " + field.GetGate(x, y, option.direction));
        if (field.GetGate(x, y, option.direction) && !visited[option.x, option.y]) {
          return (option.x, option.y);
        }
      }
    
      return (-1, -1);
    }
  }
}