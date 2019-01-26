using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellInitializer : MonoBehaviour {
  private static IEnumerable < (string id, string spritePath) > tiles = new List < (string, string) > () {
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
    transform.localScale = (Vector2) transform.localScale / GetComponent<SpriteRenderer>().sprite.bounds.size;

    // set the box collider size
    GetComponent<BoxCollider2D>().size = GetComponent<SpriteRenderer>().sprite.bounds.size;
  }

  private IEnumerable<T> shuffle<T>(IEnumerable<T> list) {
    return list.OrderBy(x => Guid.NewGuid());
  }
}