using UnityEngine;
using System.Collections;

public class GroundDetection : MonoBehaviour {
	public PlayerController refPlayerController;
	
	void OnTriggerEnter2D(Collider2D other) {
		if (refPlayerController) {
			refPlayerController.groundHitYN=true;
		}
	}
	
	void OnTriggerStay2D(Collider2D other) {
		if (refPlayerController) {
			refPlayerController.groundHitYN=true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (refPlayerController) {
			refPlayerController.groundHitYN=false;
		}
	}
}