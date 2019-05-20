using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


	
public class Level2Loader : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("LevelManager").GetComponent<LevelManagerScript> ().LettersCorrect >= GameObject.Find ("LevelManager").GetComponent<LevelManagerScript> ().CurrentWord.Length) {
			Invoke ("ReloadScene", 4);
		}

		if (GameObject.Find ("BeeMan").GetComponent<PlayerScript> ().lifes <= 0) {
			//GameObject.Find ("BeeMan").GetComponent<SpriteRenderer> ().enabled = false;
			Destroy(GameObject.Find("BeeMan"));
			Invoke ("ReloadScene", 2);
		}
	
	}
	void ReloadScene(){
		SceneManager.LoadScene ("Scene1");
	}
		
		
}

