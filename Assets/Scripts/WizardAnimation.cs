using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAnimation : MonoBehaviour {

    private WizardModel wizardModel;
    private Animator animator;

    void Start() {
        wizardModel = GetComponent<WizardModel>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (wizardModel.GetIsMoving()) {
            animator.SetBool("IsMoving", !wizardModel.GetIsJumping());
        } else {
            animator.SetBool("IsMoving", false);
        }
        animator.SetBool("IsJumping", wizardModel.GetIsJumping());

        if (wizardModel.GetIsAttacking()) {
            wizardModel.SetIsAttacking(false);
            animator.SetTrigger("AttackTrigger");
        }

        if (!wizardModel.isAlive) {
            animator.SetTrigger("DeadTrigger");
            enabled = false;
        }
    }
}
