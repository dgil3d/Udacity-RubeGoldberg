using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

    public GameObject player;
    public GameObject eventSystem;
    public GameObject startUI;
    public GameObject ball;

	public bool liveBall;

	public HandInteraction HandScript;
	public HandInteraction HandScript2;

	public Goal GoalScript;
	public BallReset BallScript;

	public GameObject[] Stars;
	public int ActiveCollectibles;
	public CollectibleReset CollectibleScript;
	public CollectibleReset CollectibleScript2;

	public int currLevel;
	public string[] levelNames = new string[4] { "rube_level1", "rube_level2", "rube_level3", "rube_level4"};
	
	// Use this for initialization
	void Start () {
		//winUI.SetActive(false);
		currLevel = SceneManager.GetActiveScene().buildIndex;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Stars = GameObject.FindGameObjectsWithTag("Collectible");
		ActiveCollectibles = Stars.Length;
	}
	public void RoundBegin()
	{
		if(HandScript.ballIsLive == true || HandScript2.ballIsLive == true)
		{
			liveBall = true;
			startUI.GetComponent<Canvas>().enabled = false;
		}
		else if (HandScript.ballIsLive == false && HandScript2.ballIsLive == false)
		{
			liveBall = false;
			startUI.GetComponent<Canvas>().enabled = true;
		}
	}

	public void PlayerFoul()
	{
		if (liveBall == true)
		{
			GetComponent<AudioSource> ().Play ();
			BallScript.ResetBall();
			CollectibleScript.ResetAllStars();
			CollectibleScript2.ResetAllStars();
		}
	}

	public void PlayerWon()
	{
			//winUI.SetActive(true);
			currLevel = (currLevel + 1) % 4;
			SteamVR_LoadLevel.Begin(levelNames[currLevel]);
			//Debug.Log("Load Next Level");
		
	}



}
