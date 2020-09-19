using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardModel : MonoBehaviour {

    // constants
    public float horizontalVelocity = 8.0f;
    public float jumpVelocity = 15.0f;

    // variables that are sent over the network
    [HideInInspector] public bool isOwned = false;
    [HideInInspector] public bool isAlive = true;
    [HideInInspector] public int lives = 10;
    [HideInInspector] public bool isMoving;
    [HideInInspector] public bool isJumping;
    [HideInInspector] public bool isAttacking;
    [HideInInspector] public float xVelocity;
    [HideInInspector] public float yVelocity;
    [HideInInspector] public float xScale;
}
