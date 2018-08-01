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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
        Move();
	}

    void GetInput() {
        // Attack.
        if (Input.GetMouseButtonDown(1)) {
            Attack();
        }
        // Move left.
        if (Input.GetKey(KeyCode.A)){
            SetDirection(-1);
        }
        else if (Input.GetKeyUp(KeyCode.A)) {
            SetDirection(0);
            anim.SetInteger("Condition", 0);
        }

        // Move right.
        if (Input.GetKey(KeyCode.D))
        {
            SetDirection(1);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            SetDirection(0);
            anim.SetInteger("Condition", 0);
        }
    }

    void Move() {
        // If the player is moving.
        if(direction != 0) {
            if (!attacking) {
                anim.SetInteger("Condition", 1);
                rb.MovePosition(transform.position + (Vector3.right * direction * speed * Time.deltaTime));
            } 
        }
    }

    void SetDirection(float dir) {
        if (dir < 0) transform.LookAt(transform.position + Vector3.left);
        else if (dir > 0) transform.LookAt(transform.position + Vector3.right);
        direction = dir;
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
