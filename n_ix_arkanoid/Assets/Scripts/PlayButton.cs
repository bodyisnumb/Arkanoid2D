using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

public void changeScene(int scene) {
	SceneManager.LoadScene(scene);
	PlayerPrefs.SetInt("Score", 0);
	PlayerPrefs.SetInt("Lifes", 3);
}
}
