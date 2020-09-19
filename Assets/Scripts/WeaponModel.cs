using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModel : MonoBehaviour {

    // variables that are sent over the network
    [HideInInspector] public bool isAlive;
    [HideInInspector] public float xVelocity = 0.0f;

    // constants
    public float horizontalVelocity = 15.0f;
}
