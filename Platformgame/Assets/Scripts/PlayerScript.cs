using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float jumppower = 10.0f; 
    Rigidbody2D myRigidbody;
    public bool isGrounded = false;


	// Use this for initialization
	void Start () {
        myRigidbody = transform.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            myRigidbody.AddForce(Vector3.up * (jumppower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f)); //Vilken riktning man hoppar
        }
	}
    void OnCollosionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground") {
            isGrounded = true;
        }
    }
    void OnCollosionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollosionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
