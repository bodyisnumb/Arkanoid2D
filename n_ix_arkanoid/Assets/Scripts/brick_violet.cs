using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick_violet : MonoBehaviour {
	public int i = 0;
	GameM GameManagerScript;
	public Transform powerUpSpeedObj;
	public Transform powerUpSizeObj;
	public Transform powerDownSpeedObj;
	public Transform powerDownSizeObj;
	public Transform powerUpBallsObj;
	public int whichPowerUp;

	// Use this for initialization
	void Start () {
	GameManagerScript = GameObject.Find ("gameManager").GetComponent<GameM>();
	GameManagerScript.Cur_Bricks++;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
void OnCollisionEnter2D() {
	if (i == 4) {
	BonusSpawn();
	Destroy (gameObject);
	GameManagerScript.Cur_Bricks--;
	GameManagerScript.Score+=10;
	GameObject bat_black = GameObject.Find("bat_black");
	Bat bat = bat_black.GetComponent<Bat>();
	bat.ballForce += 10;
	}
	else if (i < 4) {
		i++;
	}
}	
	void BonusSpawn() {
			whichPowerUp = Random.Range(1,11);
			if(whichPowerUp == 1) {
				Instantiate(powerUpSizeObj, transform.position,powerUpSizeObj.rotation);
			}
			if(whichPowerUp == 2) {
				Instantiate(powerUpSpeedObj, transform.position,powerUpSpeedObj.rotation);
			}
			if(whichPowerUp == 3) {
				Instantiate(powerDownSpeedObj, transform.position,powerDownSpeedObj.rotation);
			}
			if(whichPowerUp == 4) {
				Instantiate(powerDownSizeObj, transform.position,powerDownSizeObj.rotation);
			}
			if(whichPowerUp == 5) {
				Instantiate(powerUpBallsObj, transform.position,powerUpBallsObj.rotation);
			}
	}
}
