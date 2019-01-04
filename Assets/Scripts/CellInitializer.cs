using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class CellInitializer : MonoBehaviour {
  private static IEnumerable<(string id, string spritePath)> tiles = new List<(string, string)>() {
    ("baila", "Sprites/baila"),
    ("moonz", "Sprites/moonz"),
    ("roberto", "Sprites/roberto"),
    ("pedro", "Sprites/pedro")
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
}
