using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    // void Update() {
    //     if (Input.GetMouseButtonDown(0)) {
    //         Debug.Log("Click");

    //         Debug.Log(transform.position.x);
    //     }
    // }

    void OnMouseDown() {
        GetComponent<Animator>().SetTrigger("Active");
    }
}
