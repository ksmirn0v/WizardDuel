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
    private bool isMoving = false;
    private bool isJumping = false;
    private bool isAttacking = false;
    private float xVelocity = 0.0f;
    private float yVelocity = 0.0f;
    private float xScale = 0.0f;

    // position
    
    [PunRPC]
    private void SendPosition(float xPosition, float yPosition) {
        if (transform.position.x != xPosition && transform.position.y != yPosition) {
            transform.position = new Vector3(xPosition, yPosition);
        }
    }

    // isMoving

    public void SetIsMoving(bool value) {
        if (isMoving != value) {
            isMoving = value;
            photonView.RPC("SendIsMoving", RpcTarget.Others, value);
            photonView.RPC("SendPosition", RpcTarget.Others, transform.position.x, transform.position.y);
        }
    }

    public bool GetIsMoving() {
        return isMoving;
    }

    [PunRPC]
    private void SendIsMoving(bool value) {
        isMoving = value;
    }

    // isJumping

    public void SetIsJumping(bool value) {
        if (isJumping != value) {
            isJumping = value;
            photonView.RPC("SendIsJumping", RpcTarget.Others, value);
            photonView.RPC("SendPosition", RpcTarget.Others, transform.position.x, transform.position.y);
        }
    }

    public bool GetIsJumping() {
        return isJumping;
    }

    [PunRPC]
    private void SendIsJumping(bool value) {
        isJumping = value;
    }

    // isAttacking

    public void SetIsAttacking(bool value) {
        isAttacking = value;
        if (value) {
            photonView.RPC("SendIsAttacking", RpcTarget.Others, value);
        }
    }

    public bool GetIsAttacking() {
        return isAttacking;
    }

    [PunRPC]
    private void SendIsAttacking(bool value) {
        isAttacking = value;
    }

    // xVelocity

    public void SetXVelocity(float value) {
        if (xVelocity != value) {
            xVelocity = value;
            if (Mathf.Abs(value) > Mathf.Epsilon) {
                photonView.RPC("SendXVelocity", RpcTarget.Others, value);
            }
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
        if (yVelocity != value) {
            yVelocity = value;
            if (Mathf.Abs(value) > Mathf.Epsilon) {
                photonView.RPC("SendYVelocity", RpcTarget.Others, value);
            }
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
        if (xScale != value) {
            xScale = value;
            if (Mathf.Abs(value) > Mathf.Epsilon) {
                photonView.RPC("SendXScale", RpcTarget.Others, value);
            }
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
