using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float direction;
    public Rigidbody rb;
    public Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
        Move();
	}

    void GetInput() {
        // Move left.
        if (Input.GetKey(KeyCode.A)){
            SetDirection(-1);
        }
        else if (Input.GetKeyUp(KeyCode.A)) {
            SetDirection(0);
        }

        // Move right.
        if (Input.GetKey(KeyCode.D))
        {
            SetDirection(1);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            SetDirection(0);
        }
    }

    void Move() {
        // If the player is not moving.
        if (direction == 0)
        {
            anim.SetInteger("Condition", 0);
            return;
        }
        else {
            anim.SetInteger("Condition", 1);
        }
        rb.MovePosition(transform.position + (Vector3.right * direction * speed * Time.deltaTime));
    }

    void SetDirection(float dir) {
        if (dir < 0) transform.LookAt(transform.position + Vector3.left);
        else if (dir > 0) transform.LookAt(transform.position + Vector3.right);
        direction = dir;
    }
}
