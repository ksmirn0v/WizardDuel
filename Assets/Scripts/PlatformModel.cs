using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformModel : MonoBehaviourPunCallbacks {

    // constants
    public float verticalVelocity = 7.5f;

    // variables that are sent over the network
    private float yVelocity = 0.0f;

    // yVelocity

    public void SetYVelocity(float value) {
        if (yVelocity != value) {
            yVelocity = value;
            photonView.RPC("SendYVelocity", RpcTarget.Others, value);
        }
    }

    public float GetYVelocity() {
        return yVelocity;
    }

    [PunRPC]
    private void SendYVelocity(float value) {
        yVelocity = value;
    }
}
