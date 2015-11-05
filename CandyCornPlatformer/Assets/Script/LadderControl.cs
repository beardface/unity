using UnityEngine;
using System.Collections;

public class LadderControl : MonoBehaviour {
	public PlayerController refPlayerController;

	void Start(){
		if (refPlayerController) {
			refPlayerController.onLadder=false;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (refPlayerController) {
			refPlayerController.onLadder=true;
		}
	}
	
	void OnTriggerStay2D(Collider2D other) {
		if (refPlayerController) {
			refPlayerController.onLadder=true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (refPlayerController) {
			refPlayerController.onLadder=false;
		}
	}

}
