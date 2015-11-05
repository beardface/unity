using UnityEngine;
using System.Collections;

public class ShotMoveScript : MonoBehaviour {
	//This will be our maximum speed as we will always be multiplying by 1
	public float speed = 3f;
	public float speedDecay = 0.1f;
	public float rotationSpeed = 0.1f;
	public Vector3 direction = new Vector3(0,0,0);
	float moveSpeed;

	Rigidbody2D body;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		moveSpeed = speed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		moveSpeed -= speedDecay;
		if (moveSpeed > 0) {
			body.rotation += rotationSpeed;
			body.velocity = direction * speed; 
		}else {
			body.velocity = new Vector3 (0, body.velocity.y); 
		}


		//move our Players rigidbody
		
		
		body.rotation += rotationSpeed;
	}
}