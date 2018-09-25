using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

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
    [SerializeField] float attackDistance; //The distance in front of the player in which targets have to be to be hit.
    [SerializeField] [Range(0, 130)] float attackArc; //The size (in degrees) of the arc in which enemies can hit targets.
    [SerializeField] float preImpactDelay; //The delay after the attack is initialised before the target takes damage.
    [SerializeField] float totalAttackDuration;
    [SerializeField] float DodgeDuration;
    public LayerMask clickMask;

    private bool attacking;
    private bool dodging = false;

    void Update () {
        //KnockBack();
        GetInput();
        SetAnimationAndDirection();
	}

    void GetInput() {
        // Attack.
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, clickMask)) {
                Vector3 v3 = hit.point;
                v3.y = .5f;
                //Debug.Log(v3);
                lookAtDirection = v3;
            }
            transform.LookAt(lookAtDirection);
            lookAtDirection = Vector3.zero;
            Attack();
        } else if (Input.GetButtonDown("Dodge")) {
            Dodge();
        }

       
        // Get player inputs.
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        // Compute the position of the player based on camera.
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

        // Only move the player if it is not attacking.
        if (!attacking)
        {
            lookAtDirection = moveDirection;
            if (dodging) {
                transform.position += moveDirection.normalized * (moveSpeed*dodgeSpeed) * Time.deltaTime;
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
        if (!attacking)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                if (dodging) {
                    anim.SetInteger("Condition", 3);
                } else {
                    anim.SetInteger("Condition", 1);
                }
                
            }
            else
            {
                anim.SetInteger("Condition", 0);
            }
        }
    }

    void Attack() {

        if (attacking) return; //Don't do anything if already attacking.

        //Find all units in range of attack, then run the attack routine.
        
        DamageReciever[] targets = FOVScanner.FOVScanForObjectsOfType<DamageReciever>(transform.position, lookAtDirection, attackDistance, attackArc);
        StartCoroutine(AttackRoutine(targets));

     }


    IEnumerator AttackRoutine(DamageReciever[] targets) {

        //Debug.Log("Routine Started");
        //Begin attack.d
        anim.SetInteger("Condition", 2);
        attacking = true;

        //Wait for specified delay and then apply damage to all targets in range.
        yield return new WaitForSeconds(preImpactDelay);
        //new List<DamageReciever>(targets).ForEach(target => target.ApplyDamage(attackStrength, transform.position));

        foreach (DamageReciever target in targets) 
        {
            if (target) {
                Debug.Log("damage applied");
                target.ApplyDamage(attackStrength, transform.position);
            } 
        }

        //Wait for delay after damage has been dealt, then end the attack.
        yield return new WaitForSeconds(totalAttackDuration - preImpactDelay);
        attacking = false;
        anim.SetInteger("Condition", 0);
    }

    void Dodge() {

        if (dodging) return; //Don't do anything if already dodging.

        StartCoroutine(DodgingRoutine());

    }

    IEnumerator DodgingRoutine() {
        dodging = true;
        yield return new WaitForSeconds(DodgeDuration);
        dodging = false;
    }

}
