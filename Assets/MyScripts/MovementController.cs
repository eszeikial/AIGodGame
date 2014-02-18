using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit; // contains info about the hit location
		Ray forwardRay = new Ray (transform.position, transform.forward);

		Ray leftRay = new Ray (transform.position, transform.forward);
		leftRay.direction = Quaternion.Euler (0, -15, 0) * leftRay.direction;

		Ray rightRay = new Ray (transform.position, transform.forward);
		rightRay.direction = Quaternion.Euler (0, 15, 0) * rightRay.direction;

		if (Physics.Raycast (forwardRay, out hit, 3f)) 
		{
						Debug.DrawRay (forwardRay.origin, forwardRay.direction * 3, Color.red, .1f);
						Debug.DrawRay (rightRay.origin, rightRay.direction * 3, Color.red, .1f);
						Debug.DrawRay (leftRay.origin, leftRay.direction * 3, Color.red, .1f);
				} else {
						Debug.DrawRay (forwardRay.origin, forwardRay.direction * 3, Color.black, .1f);
						Debug.DrawRay (rightRay.origin, rightRay.direction * 3, Color.black, .1f);
						Debug.DrawRay (leftRay.origin, leftRay.direction * 3, Color.black, .1f);
				}

	}
}
