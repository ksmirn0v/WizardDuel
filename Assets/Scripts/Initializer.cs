using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class Initializer : MonoBehaviourPunCallbacks {
    
    [Header("High Level Panels")]
    [SerializeField] private GameObject controlPanel;
    [SerializeField] private Text progressLabel;
    [SerializeField] private GameObject reconnectButton;
    [SerializeField] private GameObject backButton;

    [Header("Low Level Panels")]
    [SerializeField] private InputField playerNameInputFied;
    [SerializeField] private InputField createGameInputField;
    [SerializeField] private InputField joinGameInputField;

    [Header("Room Attributes")]
    [SerializeField] private byte maxPlayersPerRoom = 2;

    private string playerName = null;
    private string roomNameCreated = null;
    private string roomNameJoined = null;
    private string version = "0.0.1";

    public void Connect() {
        reconnectButton.SetActive(false);
        progressLabel.text = "status: connecting";
        PhotonNetwork.GameVersion = version;
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Photon is connected!");
    }

    private void Awake() {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start() {
        backButton.SetActive(false);
        reconnectButton.SetActive(false);
        if (PhotonNetwork.IsConnected) {
            controlPanel.SetActive(true);
            progressLabel.text = "status: connected";
        } else {
            progressLabel.text = "status: disconnected";
            controlPanel.SetActive(false);
            Connect();
        }
    }

    public void SetPlayerName() {
        playerName = playerNameInputFied.text;
        Debug.Log("Player is set to " + playerName);
    }

    public void SetRoomNameCreated() {
        roomNameCreated = createGameInputField.text;
        Debug.Log("The room to create is set to " + roomNameCreated);
    }

    public void SetRoomNameJoined() {
        roomNameJoined = joinGameInputField.text;
        Debug.Log("The room to join is set to " + roomNameJoined);
    }

    public override void OnConnectedToMaster() {
        controlPanel.SetActive(true);
        progressLabel.text = "status: connected";
    }

    public override void OnDisconnected(DisconnectCause cause) {
        controlPanel.SetActive(false);
        progressLabel.text = "status: disconnected";
        reconnectButton.SetActive(true);
    }

    public void CreateRoom() {
        if (playerName == null || roomNameCreated == null) {
            Debug.Log("you have to privide the player name and the room name!");
            return;
        }

        controlPanel.SetActive(false);
        backButton.SetActive(true);
        progressLabel.text = "status: waiting for other players";

        PhotonNetwork.LocalPlayer.NickName = playerName;
        RoomOptions roomOptions = new RoomOptions();
        TypedLobby typedLobby = new TypedLobby(roomNameCreated, LobbyType.Default);
        PhotonNetwork.CreateRoom(roomNameCreated, roomOptions, typedLobby);
    }

    public void LeaveRoom() {
        PhotonNetwork.LeaveRoom();

        controlPanel.SetActive(true);
        backButton.SetActive(false);
    }

    public void JoinRoom() {
        if (playerName == null || roomNameJoined == null) {
            Debug.Log("you have to privide the player name and the room name!");
            return;
        }

        PhotonNetwork.LocalPlayer.NickName = playerName;
        PhotonNetwork.JoinRoom(roomNameJoined);
    }

    public override void OnCreateRoomFailed(short returnCode, string message) {
        controlPanel.SetActive(true);
        backButton.SetActive(false);
        Debug.Log("Creating of new room failed!");
    }

    public override void OnJoinRoomFailed(short returnCode, string message) {
        Debug.Log("Joining a room failed!");
    }

    public override void OnJoinedRoom() {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " joined the room " + PhotonNetwork.CurrentRoom.Name);
        if (PhotonNetwork.CurrentRoom.PlayerCount == maxPlayersPerRoom) {
            backButton.SetActive(false);
            photonView.RPC("LoadLevel", RpcTarget.MasterClient);
        }
    }

    [PunRPC]
    public void LoadLevel() {
        if (PhotonNetwork.IsMasterClient) {
            PhotonNetwork.LoadLevel("Room");
        }
    }
}
