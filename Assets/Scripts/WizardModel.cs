using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class WizardModel : MonoBehaviourPunCallbacks {

    // constants
    public float horizontalVelocity = 8.0f;
    public float jumpVelocity = 15.0f;

    // variables that are sent over the network
    [HideInInspector] public bool isOwned = false;
    [HideInInspector] public bool isAlive = true;
    [HideInInspector] public int lives = 10;
    [HideInInspector] public bool isMoving = false;
    [HideInInspector] public bool isJumping = false;
    [HideInInspector] public bool isAttacking = false;
    private float xVelocity = 0.0f;
    private float yVelocity = 0.0f;
    private float xScale = 0.0f;

    // xVelocity

    public void SetXVelocity(float value) {
        xVelocity = value;
        if (Mathf.Abs(value) > Mathf.Epsilon) {
            photonView.RPC("SendXVelocity", RpcTarget.Others, value);
        }
    }

    public float GetXVelocity() {
        return xVelocity;
    }

    [PunRPC]
    private void SendXVelocity(float value) {
        xVelocity = value;
    }

    // yVelocity

    public void SetYVelocity(float value) {
        yVelocity = value;
        if (Mathf.Abs(value) > Mathf.Epsilon) {
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

    // xScale

    public void SetXScale(float value) {
        xScale = value;
        if (Mathf.Abs(value) > Mathf.Epsilon) {
            photonView.RPC("SendXScale", RpcTarget.Others, value);
        }
    }

    public float GetXScale() {
        return xScale;
    }

    [PunRPC]
    private void SendXScale(float value) {
        xScale = value;
    }
}
