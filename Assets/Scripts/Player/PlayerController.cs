using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Agent {

    private Transform cam;
    private Vector2 input;
    private Vector3 camF;
    private Vector3 camR;

    // Condition = 0 for Idle.
    // Condition = 1 for Charge.
    // Condition = 2 for Attack. 
    // Condition = 3 for Jump/Dodge. 
    public Animator anim;

    [Header("Movement")]
    public float moveSpeed;
    public float dodgeSpeed;
    public Transform CameraTransform;
    public Rigidbody rb;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private Vector3 lookAtDirection;

    [Header("Combat")]
    [SerializeField] int attackStrength;
    [SerializeField] DamagingWeapon weapon;
    [SerializeField] float DodgeDuration;
    [SerializeField] float DodgeCoolDownDuration = 1;
    [SerializeField] float FiringDuration = 1;
    public LayerMask clickMask; //floor

    private bool attacking, Firing;
    private bool dodging = false;
    private bool dodgeCD = false;

    private void Start()
    {
        weapon.enabled = false; //The weapon should not do damage by default - only when the player is attacking.
    }

    void Update() {
        //KnockBack();
        GetInput();
        SetAnimationAndDirection();
    }

    void GetInput() {
        // Attack.

        if (Input.GetMouseButtonDown(1)) {

            //get position to look in for attack, based on ray from screen "hitting" floor layer
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, clickMask)) {
                Vector3 v3 = hit.point;
                v3.y = this.transform.position.y;
                lookAtDirection = v3;
            }
            transform.LookAt(lookAtDirection);
            //transform.eulerangles.z = 0;

            //zero look direction before intiating attack(don't know why but doesn't work without)
            lookAtDirection = Vector3.zero;
            Attack();
        } else if (Input.GetButtonDown("Dodge") && !dodgeCD) {
            Dodge();
        }


        // Get player inputs.
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        // Compute the position of the player based on camera.

        if (!dodging) {
            moveDirection = Vector3.zero;

            if (input.y > 0) moveDirection += CameraTransform.forward;
            if (input.y < 0) moveDirection += -CameraTransform.forward;
            if (input.x < 0) moveDirection += -CameraTransform.right;
            if (input.x > 0) moveDirection += CameraTransform.right;
            //Debug.Log(input.y);
            //Debug.Log(input.x);
            //Vector3 moveRight = Vector3.left * input.x;
            //Vector3 moveUp = Vector3.back * input.y;
            //moveDirection = moveRight + moveUp;

            moveDirection.y = 0f;
            SetIsMoving(moveDirection != Vector3.zero);
        }
        


        // Only move the player if it is not attacking.
        if (!attacking) {
            lookAtDirection = moveDirection;
            if (dodging) {
                transform.position += moveDirection.normalized * (moveSpeed * dodgeSpeed) * Time.deltaTime;
            } else {
                transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
            }
            //rb.MovePosition((rb.position + moveDirection) * Time.deltaTime * moveSpeed);
            transform.LookAt(transform.position + lookAtDirection);
        }
    }

    void SetAnimationAndDirection() {
        // If the player is moving, then we want to set it to charge animation.
        // Otherwise, we set it to idle.
        if (!attacking) {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
                if (dodging) {
                    anim.SetInteger("Condition", 3);
                } else {
                    anim.SetInteger("Condition", 1);
                }

            } else {

                if (Firing) {
                    anim.SetInteger("Condition", 4);
                } else {
                    anim.SetInteger("Condition", 0);
                }
                
            }
        }
    }

    void Attack() {

        if (attacking) return; //Don't do anything if already attacking.

        anim.SetInteger("Condition", 2);
        attacking = true;

    }

    /// <summary>
    /// An animation event called when the player should start dealing damage.
    /// </summary>
    public void ConnectStart() {
        weapon.enabled = true;
        Debug.Log("Connect Start");
    }

    /// <summary>
    /// An animation event called when the player should stop dealing damage.
    /// </summary>
    public void ConnectEnd(){
        weapon.enabled = false;
        Debug.Log("Connect End");
    }

    /// <summary>
    /// An animation even called when the player should finish thier attack.
    /// </summary>
    public void AttackEnd()
    {

        Debug.Log("Attack end");

        anim.SetInteger("Condition", 0);
        attacking = false;
    }


    void Dodge() {

        if (dodging) return; //Don't do anything if already dodging.

        StartCoroutine(DodgingRoutine());

    }

    IEnumerator DodgingRoutine() {
        dodging = true;
        dodgeCD = true;
        yield return new WaitForSeconds(DodgeDuration);
        dodging = false;
        yield return new WaitForSeconds(DodgeCoolDownDuration);
        dodgeCD = false;
    }

    public void Fire() {

        if (Firing) return; //Don't do anything if already dodging.
        Debug.Log("StartCoroutine fire");
        StartCoroutine(FireRoutine());

    }

    IEnumerator FireRoutine() {
        Firing = true;
        yield return new WaitForSeconds(FiringDuration);
        Firing = false;
    }

}
