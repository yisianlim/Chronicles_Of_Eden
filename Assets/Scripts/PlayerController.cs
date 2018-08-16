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

    [Header("Knockback")]
    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    [Header("Combat")]
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

        // Only move if it is not attacking or not being knockback (attacked).
        // Note: move relative to isometric geometry.
        if (knockBackCounter <= 0)
        {
            // Get player inputs.
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            input = Vector2.ClampMagnitude(input, 1);

            // Compute the position of the player based on camera. 
            Vector3 moveRight = Vector3.left * input.x;
            Vector3 moveUp = Vector3.back * input.y;
            moveDirection = moveRight + moveUp;
            lookAtDirection = moveDirection;
        }
        else {
            knockBackCounter -= Time.deltaTime;
            lookAtDirection = -moveDirection;
        }

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
        // Check if the player is close to any enemies.
        GameObject enemy = GameUtils.FindClosestEnemy(GameObject.FindGameObjectsWithTag("Enemy"), transform.position);
        
        // If the player is close enough to attack. 
        if (enemy != null) {
            float dist = Vector3.Distance(enemy.transform.position, transform.position);
            if (dist < 0.6)
            {
                // Affect enemy stat.
                EnemyStat enemyStat = enemy.GetComponent<EnemyStat>();
                enemyStat.TakeDamage(10, transform.position);
            }
        }

        // Manage the animation.
        if (attacking) return;
        anim.SetInteger("Condition", 2);
        StartCoroutine(AttackRoutine());
     }

    // Set attacking to true and then false, after 1 second.
    IEnumerator AttackRoutine() {
        attacking = true;
        yield return new WaitForSeconds(1);
        attacking = false;
        anim.SetInteger("Condition", 0);
    }

    public void KnockBack(Vector3 knockBackDirection) {
        knockBackCounter = knockBackTime;
        moveDirection = knockBackDirection * knockBackForce;
    }
}
