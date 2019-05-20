using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Loader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("LevelManager").GetComponent<LevelManager2> ().LettersCorrect > 5)
			SceneManager.LoadScene ("Scene3");
	}
}
