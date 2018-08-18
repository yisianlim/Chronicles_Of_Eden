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
    public Animator anim;

    [Header("Movement")]
    public float speed;
    public Rigidbody rb;
    private Vector3 moveDirection;
    private Vector3 lookAtDirection;

    [Header("Combat")]
    [SerializeField] int attackStrength;
    [SerializeField] float attackDistance; //The distance in front of the player in which targets have to be to be hit.
    [SerializeField] [Range(0, 90)] float attackArc; //The size (in degrees) of the arc in which enemies can hit targets.
    [SerializeField] float preImpactDelay; //The delay after the attack is initialised before the target takes damage.
    [SerializeField] float totalAttackDuration;

    private bool attacking;

    void Update () {
        //KnockBack();
        GetInput();
        SetAnimationAndDirection();
	}

    void GetInput() {
        // Attack.
        if (Input.GetMouseButtonDown(1)) {
            Attack();
        }

       
        // Get player inputs.
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        // Compute the position of the player based on camera. 
        Vector3 moveRight = Vector3.left * input.x;
        Vector3 moveUp = Vector3.back * input.y;
        moveDirection = moveRight + moveUp;
        lookAtDirection = moveDirection;
        

        // Only move the player if it is not attacking.
        if (!attacking)
        {
            rb.MovePosition(rb.position + moveDirection * Time.deltaTime * speed);
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
                anim.SetInteger("Condition", 1);
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

        //Begin attack.
        anim.SetInteger("Condition", 2);
        attacking = true;

        //Wait for specified delay and then apply damage to all targets in range.
        yield return new WaitForSeconds(preImpactDelay);
        new List<DamageReciever>(targets).ForEach(target => target.ApplyDamage(attackStrength, transform.position));

        //Wait for delay after damage has been dealt, then end the attack.
        yield return new WaitForSeconds(totalAttackDuration - preImpactDelay);
        attacking = false;
        anim.SetInteger("Condition", 0);
    }

}
