using System.Collections;
using System.Collections.Generic;
using FieldN;
using NUnit.Framework;

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
  }
}