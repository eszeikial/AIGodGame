using UnityEngine;
using System.Collections;

public class CameraControlScript : MonoBehaviour {

	enum CameraDist{Close,Medium,Far,VeryFar};

	int cType;

	// Use this for initialization
	void Start () {
		cType = (int)CameraDist.Far;
	}

	// Update is called once per frame
	void Update () {

		Vector3 PP = transform.position; //Previous Position
		float moveAmt = 0; // Distance to move cam.
		float xMod = 0; //Adjustment to make to cam pos
		float zMod = 0;
		float height = 0;//Camera height. gets set next block.

		adjustCameraHeight (); // If player presses space, switch heights.

		//Choose Camera speed and height based on CType
		switch (cType)
		{
		case (int)CameraDist.Close: moveAmt = .2f; height = 10; break;
		case (int)CameraDist.Medium: moveAmt = .5f; height = 25; break;
		case (int)CameraDist.Far: moveAmt = 1f; height = 50; break;
		case (int)CameraDist.VeryFar:moveAmt = 2.5f; height = 150; break;
		}

		//Camera Movement
		if (Input.GetKey ("w"))
			zMod += moveAmt;
		if (Input.GetKey ("s"))
			zMod -= moveAmt;
		if (Input.GetKey ("a"))
			xMod -= moveAmt;
		if (Input.GetKey ("d"))
			xMod += moveAmt;


		//Move the camera to the new point.
		transform.position = new Vector3 (PP.x + xMod, height, PP.z + zMod);

		//Left mouse click ON DOWN frame only
		if (Input.GetMouseButtonDown (0)) 
		{
			RaycastHit hit; // contains info about the hit location
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			//Physics.raycast returns true if the ray hits a collider.
			if(Physics.Raycast(ray,out hit,height*2))
			{
				//if we hit a collider, draw a blue debug line.
				Debug.DrawRay(ray.origin,ray.direction*(height*2),Color.blue,3.0f);
			}
		}
	}

	private void adjustCameraHeight()
	{
		if (Input.GetKeyDown ("space")) 
		{
			cType++; // goes to next camera position.
			if(cType > 3) //if camera type is OOB
				cType = 0; //return to closest camera
		}
	}
}
