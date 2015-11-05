using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {
	
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;

	public float MinX = 0.0f;
	public float MaxX = 10.0f;
	Camera camera;
		
		// Use this for initialization
	void Start () {
		//set anim to our animator
		camera = GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update () 
	{
		if (target)
		{
			Vector3 point = camera.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			destination.y = 0;

			if (destination.x < MinX) {
				destination.x = MinX;
			}

			if (destination.x > MaxX) {
				destination.x = MaxX;
			}

			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
		
	}
}