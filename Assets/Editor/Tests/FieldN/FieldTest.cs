using System.Collections;
using System.Collections.Generic;
using FieldN;
using NUnit.Framework;

namespace Tests {
  public class FieldTest {
    [Test]
    public void SetsDimensions() {
      var field = new Field(2, 3);

      Assert.AreEqual(field.width, 2);
      Assert.AreEqual(field.height, 3);
    }

    [Test]
    public void GatesOpenOnBothSides() {
      var field = new Field(2, 1);

      Assert.False(field.GetGate(0, 0, Field.Direction.RIGHT));
      Assert.False(field.GetGate(1, 0, Field.Direction.LEFT));

      field.SetGate(0, 0, Field.Direction.RIGHT, true);

      Assert.True(field.GetGate(0, 0, Field.Direction.RIGHT));
      Assert.True(field.GetGate(1, 0, Field.Direction.LEFT));
    }

    [Test]
    public void GatesCloseOnBothSides() {
      var field = new Field(2, 1);

      field.SetGate(0, 0, Field.Direction.RIGHT, true);

      Assert.True(field.GetGate(0, 0, Field.Direction.RIGHT));
      Assert.True(field.GetGate(1, 0, Field.Direction.LEFT));

      field.SetGate(1, 0, Field.Direction.LEFT, false);

      Assert.False(field.GetGate(0, 0, Field.Direction.RIGHT));
      Assert.False(field.GetGate(1, 0, Field.Direction.LEFT));
    }

    [Test]
    public void CannotOpenBorderGates() {
      var field = new Field(1, 1);

      Assert.False(field.GetGate(0, 0, Field.Direction.LEFT));

      field.SetGate(0, 0, Field.Direction.LEFT, false);

      Assert.False(field.GetGate(0, 0, Field.Direction.LEFT));
    }
  }
}