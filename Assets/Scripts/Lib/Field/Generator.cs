using System;
using System.Collections.Generic;
using System.Linq;
using FieldN;
using UnityEngine;

namespace FieldN {
  public class Generator {
    public static Field GenerateWithRecursiveBacktracking(int width, int height) {
      // based on http://weblog.jamisbuck.org/2010/12/27/maze-generation-recursive-backtracking
      var field = new Field(width, height);

      var visited = new bool[width, height];
      var stack = new Stack < (int x, int y) > ();
      var x = UnityEngine.Random.Range(0, width);
      var y = UnityEngine.Random.Range(0, height);
      int previousX, previousY;
      Field.Direction direction;

      var visitedCount = 1;
      visited[x, y] = true;
      stack.Push((x, y));

      while (visitedCount < width * height) {
        (previousX, previousY) = (x, y);
        (direction, x, y) = getRandomUnvisitedNeighbour(visited, previousX, previousY, width, height);

        if (direction == Field.Direction.NONE) {
          (x, y) = stack.Pop();
        } else {
          field.SetGate(previousX, previousY, direction, true);
          visited[x, y] = true;
          visitedCount++;
          stack.Push((x, y));
        }
      }

      return field;
    }

    public static Field GenerateFullyOpenField(int width, int height) {
      var field = new Field(width, height);

      fillAllInnerGates(field);

      return field;
    }
    public static Field GenerateFullyClosedField(int width, int height) {
      return new Field(width, height);
    }

    private static void fillAllInnerGates(Field field) {
      for (int i = 0; i < field.width; ++i) {
        for (int j = 0; j < field.height; ++j) {
          field.SetGate(i, j, Field.Direction.RIGHT, true);
          field.SetGate(i, j, Field.Direction.DOWN, true);
        }
      }
    }

    private static(Field.Direction, int, int) getRandomUnvisitedNeighbour(bool[, ] visited, int currentX, int currentY, int width, int height) {
      IEnumerable<Field.Direction> options = new List<Field.Direction>() {
        Field.Direction.UP, Field.Direction.RIGHT, Field.Direction.DOWN, Field.Direction.LEFT
      };

      var shuffledOptions = options.OrderBy(x => UnityEngine.Random.value);

      foreach (Field.Direction direction in shuffledOptions) {
        var nextX = currentX;
        var nextY = currentY;

        switch (direction) {
          case Field.Direction.UP:
            --nextY;
            break;
          case Field.Direction.RIGHT:
            ++nextX;
            break;
          case Field.Direction.DOWN:
            ++nextY;
            break;
          case Field.Direction.LEFT:
            --nextX;
            break;
        }

        if (nextX < 0 || nextX >= width || nextY < 0 || nextY >= height) {
          continue;
        }

        if (visited[nextX, nextY]) {
          continue;
        }

        return (direction, nextX, nextY);
      }

      return (Field.Direction.NONE, -1, -1);
    }
  }
}