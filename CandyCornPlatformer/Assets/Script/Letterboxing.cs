using UnityEngine;
using System.Collections;

public class Letterboxing : MonoBehaviour 
{
	const float KEEP_ASPECT = 20/9f;
	
	void Start()
	{
		float aspectRatio = Screen.width / ((float)Screen.height);
		float percentage = 1 - (aspectRatio / KEEP_ASPECT);
		Camera camera = GetComponent<Camera> ();

		camera.rect = new Rect(0f, (percentage / 2), 1f, (1 - percentage));
	}
}