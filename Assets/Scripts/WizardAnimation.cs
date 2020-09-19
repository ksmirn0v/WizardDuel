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
        if (wizardModel.isMoving) {
            animator.SetBool("IsMoving", !wizardModel.isJumping);
        } else {
            animator.SetBool("IsMoving", false);
        }
        animator.SetBool("IsJumping", wizardModel.isJumping);

        if (wizardModel.isAttacking) {
            wizardModel.isAttacking = false;
            animator.SetTrigger("AttackTrigger");
        }

        if (!wizardModel.isAlive) {
            animator.SetTrigger("DeadTrigger");
            enabled = false;
        }
    }
}
