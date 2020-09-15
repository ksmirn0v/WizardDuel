using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        collision.transform.parent.transform.parent = transform;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        collision.transform.parent.transform.parent = null;
    }
}
