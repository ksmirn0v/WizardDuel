using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks {

    [SerializeField] private WizardModel wizardModelLeft;
    [SerializeField] private WizardModel wizardModelRight;

    private GameObject player;

    private void Start() {
        if (!PhotonNetwork.IsConnected) {
            PhotonNetwork.LoadLevel("Launcher");
            return;
        }

        if (PlayerManager.localInstance == null) {
            if (PhotonNetwork.IsMasterClient) {
                player = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
                wizardModelLeft.isOwned = true;
            } else {
                player = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
                wizardModelRight.isOwned = true;

            }
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            LeaveRoom();
        }
    }

    public void LeaveRoom() {
        Debug.Log(PhotonNetwork.NickName + " left the game.");
        PhotonNetwork.Destroy(player);
        PhotonNetwork.LoadLevel("Launcher");
        PhotonNetwork.LeaveRoom();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer) {
        Debug.Log(otherPlayer.NickName + " left the game.");
        PhotonNetwork.Destroy(player);
        PhotonNetwork.LoadLevel("Launcher");
        PhotonNetwork.LeaveRoom();
    }
}
