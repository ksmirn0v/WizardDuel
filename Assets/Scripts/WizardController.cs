using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : MonoBehaviour {

    private WizardModel wizardModel;
    private WizardMovement wizardMovement;
    private BoxCollider2D wizardGroundCollider;

    private void Start() {
        wizardModel = GetComponent<WizardModel>();
        wizardMovement = GetComponent<WizardMovement>();
        wizardGroundCollider = GetComponentInChildren<BoxCollider2D>();
    }

    private void Update() {
        if (!wizardModel.isOwned) {
            return;
        }

        if (!wizardModel.isAlive) {
            return;
        }

        CheckMovementCondition();
        CheckJumpCondition();
        CheckAttackCondition();
    }

    private void CheckMovementCondition() {
        float horizontalTrigger = Input.GetAxis("Horizontal");
        bool triggerIsBigEnough = Mathf.Abs(horizontalTrigger) > Mathf.Epsilon;
        if (triggerIsBigEnough) {
            float directionTrigger = Mathf.Sign(horizontalTrigger);
            wizardModel.SetXScale(directionTrigger);
            wizardModel.SetXVelocity(horizontalTrigger * wizardModel.horizontalVelocity);
        }
        wizardModel.SetIsMoving(triggerIsBigEnough);
    }

    private void CheckJumpCondition() {
        if (Input.GetButtonDown("Jump") && !wizardModel.GetIsJumping()) {
            wizardModel.SetYVelocity(wizardModel.jumpVelocity);
        }

        bool wizardIsOnTheGround = wizardGroundCollider.IsTouchingLayers(LayerMask.GetMask("Foreground"));
        wizardModel.SetIsJumping(!wizardIsOnTheGround);
    }

    private void CheckAttackCondition() {
        if (Input.GetButtonDown("Fire1")) {
            wizardModel.SetIsAttacking(true);
        }
    }
}
