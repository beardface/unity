using UnityEngine;
using System.Collections;

public class CandyBowlDetection : MonoBehaviour {
	public PlayerController refPlayerController;
	
	void OnTriggerEnter2D(Collider2D other) {
		if (refPlayerController) {
			Application.LoadLevel("Winner");
		}
	}
}