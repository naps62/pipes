using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour {
    public float duration;
    public int initialRotation;
    private bool rotating = false;
    private static Vector3 direction = Vector3.forward * 90;

    void Awake() {
        initialRotation = Random.Range(0, 4);

        StartCoroutine(Rotate(this.transform, direction * initialRotation, 0));
    }

    void OnMouseDown() {
        if (!rotating) {
            StartCoroutine(Rotate(transform, direction, duration));
        }
    }

    private IEnumerator Rotate(Transform transform, Vector3 angles, float duration) {
        this.rotating = true;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;

        for (float t = 0; t < this.duration; t += Time.deltaTime) {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            yield return null;
        }

        transform.rotation = endRotation;
        rotating = false;
    }
}