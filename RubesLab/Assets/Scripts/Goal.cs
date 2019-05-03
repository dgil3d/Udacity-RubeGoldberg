using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
	public CollectibleReset CollectibleScript;
	public CollectibleReset CollectibleScript2;
	public BallReset BallScript;
	public GameLogic gameLogic;

	public bool Winner;


	void OnCollisionEnter(Collision col)
	{
		if(col.transform.name == "Ball" && gameLogic.ActiveCollectibles == 0 )
		{
			GetComponent<AudioSource> ().Play ();
            BallScript.ResetBall();
            CollectibleScript.ResetAllStars();
            CollectibleScript2.ResetAllStars();
            Winner = true;
            
            gameLogic.PlayerWon();
            //Debug.Log("Goal!");
		}
		else
		{
			Winner = false;
		}
	}
}
