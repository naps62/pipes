using UnityEngine;

namespace FieldN {
  public class Field {
    public int width, height;
    public bool[, ] rightGates;
    public bool[, ] downGates;
    public enum Direction { NONE, UP, DOWN, LEFT, RIGHT }

    public Field(int width, int height) {
      this.width = width;
      this.height = height;
      this.rightGates = new bool[width - 1, height];
      this.downGates = new bool[width, height - 1];
    }

    public bool GetGate(int x, int y, Direction direction) {
      if (!checkGateBounds(x, y, direction)) {
        return false;
      }

      (var list, var gateX, var gateY) = gateAccessor(x, y, direction);

      return list[gateX, gateY];
    }

    public void SetGate(int x, int y, Direction direction, bool value) {
      if (!checkGateBounds(x, y, direction)) {
        return;
      }

      (var list, var gateX, var gateY) = gateAccessor(x, y, direction);

      list[gateX, gateY] = value;
    }

    private bool checkGateBounds(int x, int y, Direction direction) {
      if (x < 0 || y < 0) { return false; }
      if (x >= width || y >= height) { return false; }

      switch (direction) {
      case Direction.UP:
        if (y <= 0) { return false; }
        break;
      case Direction.DOWN:
        if (y >= width - 1) { return false; }
        break;
      case Direction.LEFT:
        if (x <= 0) { return false; }
        break;
      case Direction.RIGHT:
        if (x >= height - 1) { return false; }
        break;
      }

      return true;
    }

    private(bool[, ] list, int x, int y) gateAccessor(int x, int y, Direction direction) {
      int gateX = x, gateY = y;
      bool[, ] gateList = null;

      switch (direction) {
      case Direction.UP:
        --gateY;
        break;
      case Direction.LEFT:
        --gateX;
        break;
      }

      switch (direction) {
      case Direction.LEFT:
      case Direction.RIGHT:
        gateList = rightGates;
        break;
      case Direction.UP:
      case Direction.DOWN:
        gateList = downGates;
        break;
      }

      return (gateList, gateX, gateY);
    }
  }
}