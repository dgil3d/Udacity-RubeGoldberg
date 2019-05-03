using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanWind : MonoBehaviour {


void OnCollisionStay(Collision other)
	{
	var force = transform.position - other.transform.position;
	var magnitude = 1000;

	if(other.gameObject.name == "Ball")
		{
			force.Normalize();
			GetComponent<Rigidbody>().AddForce(-force * magnitude);
			//Debug.Log("Ball entered trigger");
		}
	}
}