using FieldN;
using UnityEngine;

namespace FieldN {
  public class Generator {
    public static Field GenerateFullyOpenField(int width, int height) {
      var field = new Field(width, height);

      fillAllInnerGates(field);

      return field;
    }

    private static void fillAllInnerGates(Field field) {
      for (int i = 0; i < field.width; ++i) {
        for (int j = 0; j < field.height; ++j) {
          field.SetGate(i, j, Field.Direction.RIGHT, true);
          field.SetGate(i, j, Field.Direction.DOWN, true);
        }
      }
    }
  }
}