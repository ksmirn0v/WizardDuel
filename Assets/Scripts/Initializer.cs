using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Initializer : MonoBehaviourPunCallbacks {

    [SerializeField] private GameObject controlPanel;
    [SerializeField] private GameObject progressLabel;
    [SerializeField] private byte maxPlayersPerRoom = 2;

    private string gameVersion = "1.0.0";
    private bool isConnecting = false;

    private void Awake() {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start() {
        controlPanel.SetActive(true);
        progressLabel.SetActive(false);
    }

    public void Connect() {
        controlPanel.SetActive(false);
        progressLabel.SetActive(true);
        if (PhotonNetwork.IsConnected) {
            PhotonNetwork.JoinRandomRoom();
        } else {
            isConnecting = PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }

    public override void OnConnectedToMaster() {
        if (isConnecting) {
            Debug.Log("OnConnectedToMaster() is called.");
            PhotonNetwork.JoinRandomRoom();
            isConnecting = false;
        }
    }

    public override void OnDisconnected(DisconnectCause cause) {
        controlPanel.SetActive(true);
        progressLabel.SetActive(false);
        Debug.Log("OnDisconnected() is called. Reason - " + cause);
        isConnecting = false;
    }

    public override void OnJoinRandomFailed(short returnCode, string message) {
        Debug.Log("OnJoinRandomFailed() is called. Reason - " + message);
        PhotonNetwork.CreateRoom(null, new RoomOptions {MaxPlayers = maxPlayersPerRoom} );
    }

    public override void OnJoinedRoom() {
        Debug.LogFormat("OnJoinedRoom() is called. Player Count = {0}", PhotonNetwork.CurrentRoom.PlayerCount);
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1) {
            Debug.Log("Time to load a room.");
            PhotonNetwork.LoadLevel("Room");
        }
    }
}
