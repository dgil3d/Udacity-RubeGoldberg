using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

public bool isLegal;

	// Use this for initialization
	void Start () {
		isLegal = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerStay(Collider col)
	{
		if(col.gameObject.tag == "Spawn")
		{
			isLegal = true;
		}
	}

	public void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag == "Spawn")
		{
			isLegal = false;
		}
	}
}
