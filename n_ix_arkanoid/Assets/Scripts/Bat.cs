using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {
	private GameM GameManagerScript;
	public Rigidbody2D rigBody;
	public float speed;
	public float maxX;
	public GameObject ballPrefab;
	public Transform TheCanvas;
	public float ballForce;
	public int ballAngle;
	public GameObject newBall;

	// Use this for initialization
	void Start () {
		GameManagerScript = GameObject.Find ("gameManager").GetComponent<GameM>();
		SpawnBall();
	}
	public void SpawnBall() {
		if(ballPrefab == null) {
			Debug.Log("add ball prefab");
			return;
		}
		Vector3 ballPosition = transform.position + new Vector3(0, 0.4f, 0);
		newBall = Instantiate(ballPrefab, ballPosition, Quaternion.identity) as GameObject;
		newBall.transform.SetParent (TheCanvas);
		GameManagerScript.Lifes--;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("ballForce: " + ballForce);
		float x = Input.GetAxis("Horizontal");
		if (x == 0) {
			MoveStop ();
		}
		if (x > 0) {
			MoveRight();
		}
		if (x < 0) {
			MoveLeft();
		}
	Vector2 pos = transform.position;
	pos.x = Mathf.Clamp(pos.x, -maxX, maxX);
	transform.position = pos;

	if(newBall) {
		Rigidbody2D ballRB = newBall.GetComponent<Rigidbody2D>();
		ballRB.position = transform.position + new Vector3(0, 0.4f, 0);
	if(Input.GetButtonDown("Jump")) {
		ballAngle = Random.Range(1,7);
		if(ballAngle == 1) {
		newBall.GetComponent<Rigidbody2D>().AddForce(new Vector2 (ballForce,ballForce));
		}
		if(ballAngle == 2) {
		newBall.GetComponent<Rigidbody2D>().AddForce(new Vector2 (ballForce/2,ballForce));
		}
		if(ballAngle == 3) {
		newBall.GetComponent<Rigidbody2D>().AddForce(new Vector2 (-ballForce,-ballForce));
		}
		if(ballAngle == 4) {
		newBall.GetComponent<Rigidbody2D>().AddForce(new Vector2 (-ballForce/2,-ballForce));
		}
		if(ballAngle == 5) {
		newBall.GetComponent<Rigidbody2D>().AddForce(new Vector2 (-ballForce*2,-ballForce));
		}
		if(ballAngle == 6) {
		newBall.GetComponent<Rigidbody2D>().AddForce(new Vector2 (ballForce*2,ballForce));
		}
		newBall = null;
		}
	}
	}
	void MoveRight () {
		rigBody.velocity = new Vector2 (speed,0);
	}
	void MoveLeft () {
		rigBody.velocity = new Vector2 (-speed,0);
	}
	void MoveStop () {
		rigBody.velocity = new Vector2 (0,0);
	}
	void OnCollisionEnter(Collision col) {
		foreach (ContactPoint contact in col.contacts) {
			if(contact.thisCollider == GetComponent<BoxCollider2D>()) {
				float calc = contact.point.x - transform.position.x;
				float forceX = ballForce * calc;
				contact.otherCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceX, 0));
			}
		}
	} 
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name == "power_up_size(Clone)") {
			GetComponent<Transform> ().localScale = new Vector2 (1, .5f);
		}
		if(other.gameObject.name == "power_down_size(Clone)") {
			GetComponent<Transform> ().localScale = new Vector2 (.5f, .5f);
		}
		if(other.gameObject.name == "power_up_speed(Clone)") {
			ballForce = ballForce * 2;
		}
		if(other.gameObject.name == "power_down_speed(Clone)") {
			ballForce = ballForce / 2;
		}
		if(other.gameObject.name == "power_up_balls(Clone)") {
			GameManagerScript.Lifes+=2;
			SpawnBall();
		}
	} 
}
