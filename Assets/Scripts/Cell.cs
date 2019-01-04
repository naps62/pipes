using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class Cell : MonoBehaviour {
  private static IEnumerable<(string id, string spritePath)> types = new List<(string, string)>() {
    ("baila", "Sprites/baila"),
    ("moonz", "Sprites/moonz")
    };

  void Awake() {
    var type = shuffle(types).ElementAt(0);

    Sprite sprite = Resources.Load<Sprite>(type.spritePath);

    this.GetComponent<SpriteRenderer>().sprite = sprite;
  }

  void Start() {
    transform.localScale = (Vector2)transform.localScale / GetComponent<SpriteRenderer>().sprite.bounds.size;
  }

  private IEnumerable<T> shuffle<T>(IEnumerable<T> list) {
    return list.OrderBy(x => Guid.NewGuid());
  }
}
