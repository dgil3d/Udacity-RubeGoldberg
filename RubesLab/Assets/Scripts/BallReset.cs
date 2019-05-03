using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallReset : MonoBehaviour {
	private Vector3 originalPosition;
 	private Quaternion originalRotation;

	public CollectibleReset CollectibleScript;
	public CollectibleReset CollectibleScript2;


	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
		originalRotation = transform.rotation;

	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Ground" )
        {
			GetComponent<AudioSource> ().Play ();

            ResetBall();
            CollectibleScript.ResetAllStars();
            CollectibleScript2.ResetAllStars();
            //Debug.Log("FOUL - Reset Level");
        }
	}

	public void ResetBall()
 	{
     	this.transform.position = this.originalPosition;
    	this.transform.rotation = this.originalRotation;
    	GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
     	GetComponent<Rigidbody>().angularVelocity = new Vector3(0f,0f,0f);
 	}

}
