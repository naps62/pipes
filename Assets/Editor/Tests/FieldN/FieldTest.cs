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
  }
}