using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDebug : MonoBehaviour {
  public void OnDrawGizmos() {
    // var renderer = this.GetComponent<SpriteRenderer> ();

    // var pos = transform.position;
    // var halfWidth = renderer.bounds.size.x * Vector3.left / 2 * 0.9f;
    // var halfHeight = renderer.bounds.size.y * Vector3.up / 2 * 0.9f;

    // var topLeft = transform.position - halfWidth - halfHeight;
    // var topRight = transform.position + halfWidth - halfHeight;
    // var bottomLeft = transform.position - halfWidth + halfHeight;
    // var bottomRight = transform.position + halfWidth + halfHeight;

    // Gizmos.color = Color.red;
    // Gizmos.DrawLine (topLeft, topRight);
    // Gizmos.color = Color.blue;
    // Gizmos.DrawLine (topRight, bottomRight);
    // Gizmos.color = Color.green;

    // Gizmos.DrawLine (bottomRight, bottomLeft);
    // Gizmos.color = Color.yellow;
    // Gizmos.DrawLine(bottomLeft, topLeft);
  }
}