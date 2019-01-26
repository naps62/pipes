using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

/* Self-Avoiding Walk generator */
public class SAW {

  public static void Generate(int rows, int cols) {
    var path = GenerateSeedPath(rows, cols);
  }

  private static IEnumerable<Point> GenerateSeedPath(int rows, int cols) {
    var startCol = Random.Range(0, cols);
    var endCol = Random.Range(0, cols);
    var points = new List<Point>();

    // travel from top to bottom
    for (int i = 0; i < cols; ++i) {
      points.Add(new Point(startCol, i));
    }

    // on the bottom, travel to the end column
    var direction = (endCol > startCol) ? -1 : 1;
    for (int i = endCol; i != startCol; i += direction) {
      points.Add(new Point(i, cols - 1));
    }

    DebugPoints(points);
    return points;
  }

  private static void DebugPoints(IEnumerable<Point> points) {
    foreach (Point p in points) {
      Debug.Log(p);
    }
  }
}