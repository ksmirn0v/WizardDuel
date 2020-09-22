using UnityEngine;

public class PlatformCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == 10) {
            collision.transform.parent.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.layer == 10) {
            collision.transform.parent.transform.parent = null;
        }
    }
}
