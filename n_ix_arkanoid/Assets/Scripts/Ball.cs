using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
//	public Rigidbody2D rigBody;
//	public float ballForce;

	// Use this for initialization
	void Start () {
//		rigBody.AddForce(new Vector2(ballForce,ballForce));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Die() {
		Destroy (gameObject);
		GameObject bat_black = GameObject.Find("bat_black");
		Bat bat = bat_black.GetComponent<Bat>();
		bat.SpawnBall();
	}
}
