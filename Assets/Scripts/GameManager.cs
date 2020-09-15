using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks {

    public GameObject playerObject;
    public static GameManager instance;

    private void Start() {
        instance = this;
        if (PlayerManager.localInstance == null) {
            PhotonNetwork.Instantiate(this.playerObject.name, new Vector3(0, 0, 0), Quaternion.identity, 0);
            Debug.LogFormat("Instantiating a new player object.");
        } else {
            Debug.Log("There is already an object on the scene.");
        }
    }

    public override void OnLeftRoom() {
        SceneManager.LoadScene(0);
    }

    public void LeaveRoom() {
        Debug.LogFormat("The player {0} is leaving room. Is master - {1}.", PhotonNetwork.NickName, PhotonNetwork.IsMasterClient);
        PhotonNetwork.LeaveRoom();
    }

    private void LoadRoom() {
        if (!PhotonNetwork.IsMasterClient) {
            Debug.LogError("Trying to load room while being not a master client!");
        }
        Debug.Log("Loading the room.");
        PhotonNetwork.LoadLevel("Room");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) {
        Debug.LogFormat("OnPlayerEnteredRoom() is called by {0}.", newPlayer.NickName);
        if (PhotonNetwork.IsMasterClient) {
            Debug.Log("Master Client is going to load a room.");
            LoadRoom();
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer) {
        Debug.LogFormat("OnPlayerLeftRoom() is called by {0}.", otherPlayer.NickName);
        if (PhotonNetwork.IsMasterClient) {
            Debug.Log("Master Client is going to load a room.");
            LoadRoom();
        }
    }
}
