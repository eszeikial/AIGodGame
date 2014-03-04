using UnityEngine;
using System.Collections;



public class SteeringVehicle : MonoBehaviour {

	private bool debug = true;

	//Steering stuff
	protected float maxAcc; // max amount of force that can be applied
	protected float maxVel; // max amount of speed the object can have

	protected Vector3 velocity; // current speed and direction blah bl
	protected Vector3 steeringForce; // force to be applied this frame

	//Raytesting stuff
	private RaycastHit[] hit = new RaycastHit[3]; // array of raycasts
	private bool[] whichHit = new bool[3]; // bool array for raycast d

	private const int hitTestDist = 5;

	protected void Steer()
	{

		//STEER STUFFF
	}

	private Vector3 DodgeThings()
	{
		Vector3 desVel = new Vector3(0,0,0);
		float[] distFromHit = new float[3];
		float[] magn = new float[3];

		for(int i = 0; i < 3; i++)
		{
			whichHit[i] = false; // Reset it.
			whichHit[i] = rayTest(i); // set to true if raytest collides
			
			//After check determine DV mod
			if(whichHit[i])
			{
				distFromHit[i] = Vector3.Distance(hit[i].point,transform.position);
				magn[i] = 1 - (distFromHit[i]/hitTestDist);
				desVel += Avoid(hit[i].point) * magn[i];
			}
		}

		return desVel;
	}

	protected Vector3 Wander()
	{
		Vector3 desVel = new Vector3(0,0,0);
		return desVel;
	}

	protected Vector3 Seek()
	{
		Vector3 desVel = new Vector3(0,0,0);
		return desVel;

	}

	protected Vector3 Avoid(Vector3 target)
	{
		Vector3 desVel = new Vector3(0,0,0);

		desVel = target - transform.position;
		desVel = Quaternion.Euler(0,180,0) * desVel;

		return desVel;
	}

	private bool rayTest(int rayNum)
	{
		Vector3 vec = transform.forward.normalized * hitTestDist;
		vec = Quaternion.Euler(0,-15+15*rayNum,0) * vec;

		if(Physics.Raycast(transform.position,vec,out hit[rayNum]))
		{
			if(debug)
				Debug.DrawRay(transform.position,vec,Color.red);
			return true;
		}
		else
		{
			if(debug)
				Debug.DrawRay(transform.position,vec,Color.green);
			return false;
		}
	}

}
