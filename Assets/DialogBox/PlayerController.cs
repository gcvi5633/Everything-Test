using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Rigidbody myRigidbody;
    public float moveSpeed;
    public float jumpSpeed;

    public bool canMove;
    public bool canJump;

    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!canMove) {
            return;
        }
        Movement();
    }

    void Movement() {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        myRigidbody.velocity = new Vector2(h*moveSpeed,myRigidbody.velocity.y);

        Jump();
    }

    void Jump() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x,jumpSpeed);
        }
    }
}
