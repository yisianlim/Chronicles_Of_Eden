using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Condition = 0 for Idle.
    // Condition = 1 for Charge.
    // Condition = 2 for Attack. 
    public Animator anim;

    [Header("Movement")]
    public float speed;
    public float direction;
    public Rigidbody rb;

    [Header("Combat")]
    private bool attacking;
	
	// Update is called once per frame
	void Update () {
        GetInput();
        SetAnimationAndDirection();
	}

    void GetInput() {
        // Attack.
        if (Input.GetMouseButtonDown(1)) {
            Attack();
        }

        //Move horizontally
        rb.MovePosition(rb.position + (Vector3.left * Input.GetAxis("Horizontal")) * speed * Time.deltaTime);

        // Move vertically.
        rb.MovePosition(rb.position + (Vector3.back * Input.GetAxis("Vertical")) * speed * Time.deltaTime);
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

        // Make the player face to where it is heading. 
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.LookAt(transform.position + Vector3.right);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.LookAt(transform.position + Vector3.left);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            transform.LookAt(transform.position + Vector3.forward);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            transform.LookAt(transform.position + Vector3.back);
        }
    }

    void Attack() {
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
}
