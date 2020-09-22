using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    private PlatformModel platformModel;
    private Rigidbody2D rigidBody;

    private void Start() {
        platformModel = GetComponent<PlatformModel>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, platformModel.GetYVelocity());
    }
}
