using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CollectibleReset : MonoBehaviour {

public PlayerState PlayerStateScript;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.name == "Ball" && PlayerStateScript.isLegal == true)
		{
			GetComponent<AudioSource> ().Play ();
			this.gameObject.SetActive(false);
			//Debug.Log("Collectible Found! ");
		}
		
	}

	public void ResetAllStars()
	{
		this.gameObject.SetActive(true);
		//wi.GetComponent<Renderer>().enabled = true;
		//Debug.Log("Star reset");
		//Debug.Log("Collectibles after reset " + ActiveCollectibles);
	}
}
