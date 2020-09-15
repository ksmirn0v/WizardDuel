using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class PlayerName : MonoBehaviour {

    private const string PLAYER_NAME_KEY = "PlayerName";

    private void Start() {
        InputField inputField = GetComponent<InputField>();
        if (inputField && PlayerPrefs.HasKey(PLAYER_NAME_KEY)) {
            string defaultName = PlayerPrefs.GetString(PLAYER_NAME_KEY);
            inputField.text = defaultName;
            PhotonNetwork.NickName = defaultName;
        }
    }

    public void SetPlayerName(string name) {
        if (string.IsNullOrEmpty(name)) {
            Debug.LogError("No name is given.");
            return;
        }
        PhotonNetwork.NickName = name;
        PlayerPrefs.SetString(PLAYER_NAME_KEY, name);
    }
}
