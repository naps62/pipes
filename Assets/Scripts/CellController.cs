using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    void OnMouseDown() {
        GetComponent<Animator>().SetTrigger("Active");
        transform.Rotate(Vector3.forward * 90);
    }
}
