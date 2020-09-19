using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour {

    private WeaponModel weaponModel;
    private Rigidbody2D rigidBody;

    private void Awake() {
        weaponModel = GetComponent<WeaponModel>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Mathf.Abs(weaponModel.xVelocity) > Mathf.Epsilon) {
            rigidBody.velocity = new Vector2(weaponModel.xVelocity, 0.0f);
            weaponModel.xVelocity = 0.0f;
        }
    }
}
