  using Photon.Pun;
using UnityEngine;

public class Platform : MonoBehaviour {

    //private Transform transformComponent;
    //private Rigidbody2D rigidBody;

    private void OnTriggerEnter2D(Collider2D collision) {
        collision.transform.parent.transform.parent = transform;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        collision.transform.parent.transform.parent = null;
    }

    /**public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting) {
            stream.SendNext(transformComponent.position);
            stream.SendNext(transformComponent.localScale);
            stream.SendNext(rigidBody.velocity);
        } else {
            transform.position = (Vector3)stream.ReceiveNext();
            transform.localScale = (Vector3)stream.ReceiveNext();
            rigidBody.velocity = (Vector2)stream.ReceiveNext();
        }
    }**/
}
