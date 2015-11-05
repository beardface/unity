using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	//This will be our maximum speed as we will always be multiplying by 1
	public float maxSpeed = 2f;
	public int jumpPower = 2;
	public float fallDeathY = -5.5f;
	public float climbSpeed = 0.03f;

	public bool groundHitYN = true;
	public bool onLadder = false;

	//a boolean value to represent whether we are facing left or not
	bool facingLeft = true;
	//a value to represent our Animator
	Animator anim;
	Rigidbody2D body;
	bool doubleJumpAvail = true;
	// Use this for initialization
	void Start () {
		//set anim to our animator
		anim = GetComponent<Animator>();
		body = GetComponent<Rigidbody2D>();
		
		body.gravityScale = 1.0f;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!IsInvoking ("DelayDeath")) {
			ProcessMovement ();
			ProcessShots ();

			checkDeathByFall ();
		} else {
			body.velocity = new Vector3(0,0,0);
		}
	}

	void ProcessDown(){
		if (Input.GetKey ("down") && (onLadder)) {
			body.MovePosition(body.position + (new Vector2(0, -1*climbSpeed)));
		} 
	}

	void ProcessUp(){
		if (groundHitYN) {
			doubleJumpAvail = true;
		}
		
		if (Input.GetKey ("up") && (onLadder)) {
			body.MovePosition(body.position + (new Vector2(0, climbSpeed)));
		} else {
			if (Input.GetKeyDown ("up") && (doubleJumpAvail || groundHitYN)) {
				body.AddForce (new Vector2 (0, jumpPower), ForceMode2D.Impulse);
				
				if (!groundHitYN) {
					doubleJumpAvail = false;
				}
			} 
		}
	}

	void ProcessMovement() {
		if (onLadder) {
			body.gravityScale = 0.0f;
		} else {
			body.gravityScale = 1.0f;
		}

		float move = Input.GetAxis ("Horizontal");//Gives us of one if we are moving via the arrow keys
		if (Mathf.Abs(move) > 0.1f) {
			anim.Play ("Run");
		} else {
			anim.Play ("Idle");
		}
		//move our Players rigidbody
		body.velocity = new Vector3 (move * maxSpeed, body.velocity.y);
		//set our speed
		//anim.SetFloat ("Speed", Mathf.Abs (move));
		//if we are moving left but not facing left flip, and vice versa
		if (move > 0 && !facingLeft) {
			Flip ();
		} else if (move < 0 && facingLeft) {
			Flip ();
		}

		ProcessUp ();
		ProcessDown ();

		body.rotation = 0.0f;
	}

	public void checkDeathByFall(){
		if (body.position.y <= fallDeathY) {
			Debug.Log ("You died");
			Invoke("DelayDeath", 2f);
		}
	}

	void DelayDeath()
	{
		Manager.Instance.LivesLeft--;
		if (Manager.Instance.LivesLeft == 0) {
			Manager.Instance.LivesLeft = 4;
		}
		Application.LoadLevel (Application.loadedLevel);
	}


	public float GetDirection() {
		if (facingLeft) {
			return 1.0f;
		} else {
			return -1.0f;
		}
	}

	void ProcessShots() {
		// 5 - Shooting
		bool shoot = Input.GetKey ("space");
		// Careful: For Mac users, ctrl + arrow is a bad idea
		
		if (shoot) {
			FireWeaponScript weapon = GetComponent<FireWeaponScript> ();
			if (weapon != null) {
				// false because the player is not an enemy
				weapon.Attack (false, GetDirection ());
			}
		}
	}

	//flip if needed
	void Flip(){
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}