using UnityEngine;
using System.Collections;


public class Manager : MonoBehaviour {
	public static Manager Instance {
		get;
		private set;
	}

	public int LivesLeft = 4;
	
	void Awake(){
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(transform.gameObject);
		}
	}
	
}