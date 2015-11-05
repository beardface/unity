using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
	public float time = 60.0f;
    bool count;
	
	void Start () {
		count = true;
	}
	
	// Update is called once per frame
	void FixedUpdate (){
		if (count){
			GameObject.Find ("time").GetComponent<Text> ().text = "TIME:" + (int)time;

			time -= Time.deltaTime;

			if (time <= 0) {
				count = false;
			}
		}
	}
}