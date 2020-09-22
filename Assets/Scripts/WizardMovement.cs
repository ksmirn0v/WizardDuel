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
        if (Mathf.Abs(wizardModel.GetXVelocity()) > Mathf.Epsilon) {
            rigidBody.velocity = new Vector2(wizardModel.GetXVelocity(), rigidBody.velocity.y);
            transform.localScale = new Vector3(wizardModel.GetXScale(), transform.localScale.y, transform.localScale.z);
            wizardModel.SetXVelocity(0.0f);
        }

        if (wizardModel.GetYVelocity() > Mathf.Epsilon) {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, wizardModel.GetYVelocity());
            wizardModel.SetYVelocity(0.0f);
        }
    }
}
