using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInteraction : MonoBehaviour {
	public SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device device;
	public float throwForce = 1.5f;

	public float swipeSum;
	public float touchLast;
	public float touchCurrent;
	public float distance;
	public bool hasSwipedLeft;
	public bool hasSwipedRight;
	
	public ObjectMenuManager objectMenuManager;
	public bool ballIsLive;
	public GameLogic gameLogic;

	// Use this for initialization
	void Start () 
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
		//Debug.Log("Started");
	}
	
	// Update is called once per frame
	void Update () 
	{
		device = SteamVR_Controller.Input((int)trackedObj.index);
		
		if(device.GetPressUp(SteamVR_Controller.ButtonMask.ApplicationMenu))
		{
			MenuSwitch();
		}
		
		if(device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
		{
			touchLast = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
		}

		if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
		{
			touchCurrent = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
			distance = touchCurrent - touchLast;
			touchLast = touchCurrent;
			swipeSum += distance;
			
			if(!hasSwipedRight)
			{
				if(swipeSum > 0.5f)
				{
					swipeSum = 0;
					SwipeRight();
					hasSwipedRight = true;
					hasSwipedLeft = false;
				}	
			}
			
			if(!hasSwipedLeft)
			{
				if(swipeSum < -0.5f)
				{
					swipeSum = 0;
					SwipeLeft();
					hasSwipedLeft = true;
					hasSwipedRight = false;
				}	
			}
			
		}

		if(device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
		{
			swipeSum = 0;
			touchCurrent = 0;
			touchLast = 0;
			hasSwipedLeft = false;
			hasSwipedRight = false;
		}
		if(device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
		{
			//Spawn object currently selected by menu
			SpawnObject();
		}
		//Debug.Log("Found device");
	}

	void MenuSwitch()
	{
		objectMenuManager.MenuOn();
	}

	void SpawnObject()
	{
		objectMenuManager.SpawnCurrentObject();
	}

	void SwipeLeft()
	{
		objectMenuManager.MenuLeft();
		//Debug.Log("Swipe Left");
	}

	void SwipeRight()
	{
		objectMenuManager.MenuRight();
		//Debug.Log("Swipe Right");
	}

	public void OnTriggerStay(Collider coli)
	{
		if(coli.gameObject.CompareTag("throwable") || coli.gameObject.CompareTag("Ball"))
		{
			if(device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
			{
				if(coli.gameObject.CompareTag("Ball"))
				{
					ballIsLive = false;
					gameLogic.RoundBegin();
				}
				ThrowObject(coli);
			}
			else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
			{
				if(coli.gameObject.CompareTag("Ball"))
				{
					ballIsLive = true;
					gameLogic.RoundBegin();
				}
				GrabObject(coli);
			}
		}
	}


	void GrabObject(Collider coli)
	{
		coli.transform.SetParent(gameObject.transform);
		coli.GetComponent<Rigidbody>().isKinematic = true;
		device.TriggerHapticPulse(2000);
		//Debug.Log("You are touching down the trigger on an object");

	}

	void ThrowObject(Collider coli)
	{
		coli.transform.SetParent(null);
		Rigidbody rigidBody = coli.GetComponent<Rigidbody>();
		rigidBody.isKinematic = false;
		rigidBody.velocity = device.velocity * throwForce;
		rigidBody.angularVelocity = device.angularVelocity;
		ballIsLive = false;
		//Debug.Log("You have released the trigger");
	}
}
