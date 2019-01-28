using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellEndCollider : MonoBehaviour {

  void OnTriggerEnter2D(Collider2D other) {
    if (other.tag != "CellEnd") {
      return;
    }

    var thisCell = transform.parent.gameObject;
    var otherCell = other.transform.parent.gameObject;

    Debug.Log($"entered: {thisCell.name} {otherCell.name}");
  }

  void OnTriggerExit2D(Collider2D other) {
    if (other.tag != "CellEnd") {
      return;
    }

    var thisCell = transform.parent.gameObject;
    var otherCell = other.transform.parent.gameObject;
    Debug.Log($"exited: {thisCell.name} {otherCell.name}");
  }
}