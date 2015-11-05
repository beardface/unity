using UnityEngine;
using System.Collections;

public class RandomJump : MonoBehaviour {
	//This will be our maximum speed as we will always be multiplying by 1
	public float max_jump = 0.1f;
	public float min_jump = 0.0f;
	public float jump_delay = 20f;
	float jump_count_down;

	Rigidbody2D body;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		jump_count_down = jump_delay;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		jump_count_down--;

		if (jump_count_down <= 0) {
			
			//move our Players rigidbody
			body.velocity = new Vector3 (body.velocity.x, Random.Range(min_jump, max_jump)); 

			jump_count_down = jump_delay;
		}

		body.rotation = 0.0f;
	}
}