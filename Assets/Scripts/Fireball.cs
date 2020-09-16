using Photon.Pun;
using UnityEngine;

public class Fireball : MonoBehaviour, IPunObservable {

    [SerializeField] private GameObject hitVFX;

    private Transform transformComponent;
    private Rigidbody2D rigidBody;

    private void Awake() {
        transformComponent = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D target) {
        var livesComponent = target.GetComponent<Lives>();
        if (livesComponent) {
            livesComponent.SubtractLives();
        }
        GameObject visualEffectObject = Instantiate(hitVFX, transform.position, transform.rotation);
        Destroy(visualEffectObject, 1f);
        Destroy(gameObject);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting) {
            stream.SendNext(transformComponent.position);
            stream.SendNext(transformComponent.localScale);
            stream.SendNext(rigidBody.velocity);
        } else {
            transform.position = (Vector3)stream.ReceiveNext();
            transform.localScale = (Vector3)stream.ReceiveNext();
            rigidBody.velocity = (Vector2)stream.ReceiveNext();
        }
    }
}
