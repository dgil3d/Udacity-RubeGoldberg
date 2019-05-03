using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControllerInput : MonoBehaviour {
	public SteamVR_TrackedObject trackedObj;
	public SteamVR_Controller.Device device;

	//Teleporter
	private LineRenderer laser;
	public GameObject teleportAimerObject;
	public Vector3 teleportLocation;
	public GameObject player;
	public LayerMask laserMask;

	//Dash
	public float dashSpeed = 30f;
	private bool isDashing;
	private float lerpTime;
	//private Vector3 dashStartPosition;

	//Walking
	public Transform playerCam;
	public float moveSpeed = 4f;
	private Vector3 movementDirection;
	public Rigidbody rb;

	// Use this for initialization
	void Start () 
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
		laser = GetComponentInChildren<LineRenderer>();

		rb = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		

		device = SteamVR_Controller.Input((int)trackedObj.index);
		
		//if(device.GetPress(SteamVR_Controller.ButtonMask.Grip))
		//{
			//movementDirection = playerCam.transform.forward;
			//movementDirection = new Vector3(movementDirection.x, 0, movementDirection.z);
			//movementDirection = movementDirection * moveSpeed * Time.deltaTime;
		//	rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
			//player.transform.position += movementDirection;
		//}

		if (isDashing)
		{
			lerpTime = Time.deltaTime * dashSpeed;
			//player.transform.position = Vector3.Lerp(dashStartPosition, teleportLocation, lerpTime);
			if(lerpTime >= 1)
			{
				isDashing= false;
				lerpTime = 0;
			}
		}
		else 
		{
			if(device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
			{
				laser.gameObject.SetActive(true);
				teleportAimerObject.SetActive(true);

				laser.SetPosition(0, gameObject.transform.position); //Start point of line renderer
				RaycastHit hit; //Laser's endpoint
				if(Physics.Raycast(transform.position, transform.forward, out hit, 10, laserMask))
				{
					teleportLocation = hit.point;
					
					Renderer renderer = laser.GetComponent<Renderer> ();
					Material mat = renderer.material;
					laser.SetPosition(1, teleportLocation);
					Color greenColor = Color.green; //Replace this with whatever you want for your base color at emission level '1'
					mat.SetColor ("_EmissionColor", greenColor);
					
					//aimer position
					teleportAimerObject.transform.position = new Vector3(teleportLocation.x, teleportLocation.y, teleportLocation.z);

				}
				else
				{
					teleportLocation = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
					RaycastHit groundRay;
					if(Physics.Raycast(teleportLocation, -Vector3.up, out groundRay, 10, laserMask))
					{
						teleportLocation = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
					}

					Renderer renderer = laser.GetComponent<Renderer> ();
					Material mat = renderer.material;
					laser.SetPosition(1, transform.forward * 5 + transform.position);
			        Color redColor = Color.red; //Replace this with whatever you want for your base color at emission level '1'
					mat.SetColor ("_EmissionColor", redColor);
					
					//aimer position
					teleportAimerObject.transform.position = teleportLocation + new Vector3(0, 0, 0);
				}
					
			}

			if(device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
			{
				laser.gameObject.SetActive(false);
				teleportAimerObject.SetActive(false);


				player.transform.position = teleportLocation; // Instant teleport alternative
				//dashStartPosition = player.transform.position; // Animated dash teleport
				//isDashing = true;
			}
		}

					
	}
}
