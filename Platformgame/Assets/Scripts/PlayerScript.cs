using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float jumppower = 10.0f; 
    Rigidbody2D myRigidbody;
    public bool isGrounded = false;
    float posX = 0.0f;
    bool isGameOver = false;
    ChallengeController myChallengeController;

	// Use this for initialization
	void Start () {
        myRigidbody = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
        myChallengeController = GameObject.FindObjectOfType<ChallengeController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isGameOver) {
            myRigidbody.AddForce(Vector3.up * (jumppower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f)); //Vilken riktning man hoppar
        }
        if (transform.position.x < posX)
        {
            GameOver();
        }
    }
    
    void update() {
        
    }

    void GameOver()
    {
        isGameOver = true;
        myChallengeController.GameOver();
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
