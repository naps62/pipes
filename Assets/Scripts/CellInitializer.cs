using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class CellInitializer : MonoBehaviour {
  private static IEnumerable<(string id, string spritePath)> tiles = new List<(string, string)>() {
    ("line", "Sprites/pipe_line"),
    ("t", "Sprites/pipe_t"),
    ("cross", "Sprites/pipe_cross"),
    ("turn", "Sprites/pipe_turn"),
    ("end", "Sprites/pipe_end")
    };

  void Awake() {
    // get a random tile
    var tile = shuffle(tiles).ElementAt(0);

    this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(tile.spritePath);
  }

  void Start() {
    // scale down the element according to the sprite size
    transform.localScale = (Vector2)transform.localScale / GetComponent<SpriteRenderer>().sprite.bounds.size;
    
    // set the box collider size
    GetComponent<BoxCollider2D>().size = GetComponent<SpriteRenderer>().sprite.bounds.size;
  }

  private IEnumerable<T> shuffle<T>(IEnumerable<T> list) {
    return list.OrderBy(x => Guid.NewGuid());
  }

  public void OnDrawGizmos() {

    var renderer = this.GetComponent<SpriteRenderer>();

    var pos = transform.position;
    var halfWidth = renderer.bounds.size.x * Vector3.left / 2 * 0.9f;
    var halfHeight = renderer.bounds.size.y * Vector3.up / 2 * 0.9f;

    var topLeft = transform.position - halfWidth - halfHeight;
    var topRight = transform.position + halfWidth - halfHeight;
    var bottomLeft = transform.position - halfWidth + halfHeight;
    var bottomRight = transform.position + halfWidth + halfHeight;

    Gizmos.color = Color.red;
    Gizmos.DrawLine(topLeft, topRight);
    Gizmos.color = Color.blue;
    Gizmos.DrawLine(topRight, bottomRight);
    Gizmos.color = Color.green;
    Gizmos.DrawLine(bottomRight, bottomLeft);
    Gizmos.color = Color.yellow;
    Gizmos.DrawLine(bottomLeft, topLeft);
  }
}
