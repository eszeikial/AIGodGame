using UnityEngine;
using System.Collections;

public class SteeringVehicle : MonoBehaviour {

	protected float vel;
	protected float acc;
	protected float maxAcc;
	protected float maxVel;

	private RaycastHit hit = new RaycastHit[3];


	protected void Steer()
	{

	}

	protected Vector3 Wander()
	{

	}

	protected Vector3 Seek()
	{

	}

	protected Vector3 Avoid()
	{

	}

	protected bool rayTest(int rayNum)
	{
		Vector3 vec = transform.forward.normalized * 5;
		vec *= Quaternion.Euler(0,-15*rayNum,0);
	}

}
