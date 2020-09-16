using Photon.Pun;
using UnityEngine;

public class PlayerManager : MonoBehaviourPunCallbacks {

    public static GameObject localInstance;
    public GameObject playerUIPrefab;

    private void Awake() {
        if (photonView.IsMine) {
            PlayerManager.localInstance = this.gameObject;
        }
    }

    private void Start() {
        if (playerUIPrefab != null) {
            GameObject playerUIObject = Instantiate(playerUIPrefab);
            playerUIObject.GetComponent<PlayerUI>().SetTarget(this);
        } else {
            Debug.LogWarning("Missing playerUIPrefab reference.");
        }
    }

    private void OnLevelWasLoaded(int level) {
        GameObject playerUIObject = Instantiate(this.playerUIPrefab);
        playerUIObject.GetComponent<PlayerUI>().SetTarget(this);
    }
}
