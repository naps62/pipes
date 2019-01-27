using System;
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
      UnityEngine.Random.InitState(43);
      var width = 10;
      var height = 10;

      var field = Generator.GenerateWithRecursiveBacktracking(width, height);

      var visited = new bool[width, height];
      var stack = new Stack < (int x, int y) > ();

      var x = UnityEngine.Random.Range(0, width);
      var y = UnityEngine.Random.Range(0, height);

      // flood the field again
      visited[x, y] = true;
      var visitedCount = 1;
      int previousX = x, previousY = y;
      var i = 1;

      while (visitedCount < width * height && i < 200) {
        ++i;
        (x, y) = getUnvisitedNeighbour(field, visited, previousX, previousY, width, height);

        if (x == -1) {
          (previousX, previousY) = stack.Pop();
        } else {
          stack.Push((previousX, previousY));
          visited[x, y] = true;
          previousX = x;
          previousY = y;
          visitedCount++;
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

      foreach ((int x, int y, Field.Direction direction) option in options) {
        if (field.GetGate(x, y, option.direction) && !visited[option.x, option.y]) {
          return (option.x, option.y);
        }
      }

      return (-1, -1);
    }
  }
}