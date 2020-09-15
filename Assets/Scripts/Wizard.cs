using Photon.Pun;
using UnityEngine;

public class Wizard : MonoBehaviourPunCallbacks {

    [SerializeField] float movementVelocity = 8.0f;
    [SerializeField] float jumpVelocity = 15.0f;
    [SerializeField] GameObject fireball;
    [SerializeField] float fireballVelocity = 15.0f;

    private Rigidbody2D rigidBody;
    private Animator animator;
    private CapsuleCollider2D capsuleCollider;
    private Transform fireballTransform;
    private bool isAlive = true;

    public void Fire() {
        GameObject fireballObject = Instantiate(fireball, fireballTransform.position, fireballTransform.rotation) as GameObject;
        fireballObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * fireballVelocity, 0.0f);
    }

    public void TriggerDeath() {
        animator.SetTrigger("DeadTrigger");
        isAlive = false;
        GameManager.instance.LeaveRoom();
    }

    private void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponentInChildren<CapsuleCollider2D>();
        fireballTransform = transform.GetChild(0).GetChild(0);
    }

    private void Update() {
        if (!photonView.IsMine && PhotonNetwork.IsConnected) {
            return;
        }

        if (!isAlive) {
            return;
        }
        Move();
        Jump();
        Attack();
    }

    private void Move() {
        float horizontalTrigger = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(movementVelocity * horizontalTrigger, rigidBody.velocity.y);
        if (Mathf.Abs(horizontalTrigger) > Mathf.Epsilon) {
            float directionTrigger = Mathf.Sign(horizontalTrigger);
            transform.localScale = new Vector3(directionTrigger, transform.localScale.y, transform.localScale.z);

            if (!animator.GetBool("IsJumping")) {
                animator.SetBool("IsMoving", true);
            } else {
                animator.SetBool("IsMoving", false);
            }
        } else {
            animator.SetBool("IsMoving", false);
        }
    }


    private void Jump() {
        if (Input.GetButtonDown("Jump") && !animator.GetBool("IsJumping")) {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpVelocity);
        }
        ChangeJumpAnimation();
    }

    private void ChangeJumpAnimation() {
        if (capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Foreground"))) {
            animator.SetBool("IsJumping", false);
        } else {
            animator.SetBool("IsJumping", true);
        }
    }

    private void Attack() {
        if (Input.GetButtonDown("Fire1")) {
            animator.SetTrigger("AttackTrigger");
        }
    }
}
