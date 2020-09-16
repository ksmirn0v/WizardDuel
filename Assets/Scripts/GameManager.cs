using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks {

    [SerializeField] private Transform[] spawnPositions;

    private GameObject player;

    private void Start() {
        if (!PhotonNetwork.IsConnected) {
            PhotonNetwork.LoadLevel("Launcher");
            return;
        }

        if (PlayerManager.localInstance == null) {
            if (PhotonNetwork.IsMasterClient) {
                player = PhotonNetwork.Instantiate("Wizard", spawnPositions[0].position, spawnPositions[0].rotation);
            } else {
                player = PhotonNetwork.Instantiate("Wizard", spawnPositions[1].position, spawnPositions[1].rotation);
                
            }
            Debug.Log("The player " + PhotonNetwork.LocalPlayer.NickName + " is in the room.");
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
