using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMovement : MonoBehaviour {

    private WizardModel wizardModel;
    private Rigidbody2D rigidBody;

    private void Start() {
        wizardModel = GetComponent<WizardModel>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Mathf.Abs(wizardModel.xVelocity) > Mathf.Epsilon) {
            rigidBody.velocity = new Vector2(wizardModel.xVelocity, rigidBody.velocity.y);
            transform.localScale = new Vector3(wizardModel.xScale, transform.localScale.y, transform.localScale.z);
            wizardModel.xVelocity = 0;
        }

        if (wizardModel.yVelocity > Mathf.Epsilon) {
            rigidBody.velocity = new Vector2(rigidBody.velocity.y, wizardModel.yVelocity);
            wizardModel.yVelocity = 0;
        }
    }
}
