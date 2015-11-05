using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifePanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch(Manager.Instance.LivesLeft){
		case 1:
			GameObject.Find ("life_1").SetActive (true);
			GameObject.Find ("life_2").SetActive (false);
			GameObject.Find ("life_3").SetActive (false);
			GameObject.Find ("life_4").SetActive (false);
			break;
		case 2:
			GameObject.Find ("life_1").SetActive (true);
			GameObject.Find ("life_2").SetActive (true);
			GameObject.Find ("life_3").SetActive (false);
			GameObject.Find ("life_4").SetActive (false);
			break;
		case 3:
			GameObject.Find ("life_1").SetActive (true);
			GameObject.Find ("life_2").SetActive (true);
			GameObject.Find ("life_3").SetActive (true);
			GameObject.Find ("life_4").SetActive (false);
			Debug.Log ("Set to 3...");
			break;
		case 4:
			GameObject.Find ("life_1").SetActive (true);
			GameObject.Find ("life_2").SetActive (true);
			GameObject.Find ("life_3").SetActive (true);
			GameObject.Find ("life_4").SetActive (true);
			break;
		}
	}
}
