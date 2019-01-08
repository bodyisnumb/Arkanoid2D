using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {
	public Text HighscoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		HighscoreText.text = "Highscore: " + PlayerPrefs.GetInt("High Score", 0);
	}
}
