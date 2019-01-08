using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameM : MonoBehaviour {

public int Lifes;
public int Cur_Bricks = 0;
public Text Life_Text;
public Text Score_Text;
public int Score;
public int Highscore;
public int OriginalHighscore;
public int nextLevel;
	// Use this for initialization
	void Start () {
	Lifes = PlayerPrefs.GetInt("Lifes", 0);
	Score = PlayerPrefs.GetInt("Score", 0);
	Highscore = PlayerPrefs.GetInt("High Score", 0);	
	}
	
	// Update is called once per frame
	void Update () {
		if(Lifes <= 0) {
			SceneManager.LoadScene(2);
		}
		if(Cur_Bricks <= 0) {
			SceneManager.LoadScene(nextLevel);
			Lifes++;
		}
	Life_Text.text = ("Lives: " + Lifes.ToString());
	Score_Text.text = ("Score: " + Score.ToString());
	PlayerPrefs.SetInt("Score", Score);
	PlayerPrefs.SetInt("Lifes", Lifes);


	if (Score > Highscore) {
		Highscore = Score;
	}	

	 OriginalHighscore = PlayerPrefs.GetInt("High Score", 0);
	 if (Highscore > OriginalHighscore) {
		 PlayerPrefs.SetInt("High Score", Highscore);
	 }
	}
}
