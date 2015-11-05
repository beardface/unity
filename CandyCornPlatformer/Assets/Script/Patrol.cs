using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {
	//This will be our maximum speed as we will always be multiplying by 1
	public float speed = 0.1f;
	public float patrolDistance = 100f;

	float direction = 1.0f;
	float currentDistance = 0.0f;

	Rigidbody2D body;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		Flip ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		currentDistance += speed * direction;

		if (currentDistance >= patrolDistance || currentDistance <= 0.0f) {
			Flip ();
			direction *= -1.0f;
		}

		//move our Players rigidbody
		body.velocity = new Vector3 (direction * speed, body.velocity.y); 
		
		
		body.rotation = 0.0f;
	}
	
	//flip if needed
	void Flip(){
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}