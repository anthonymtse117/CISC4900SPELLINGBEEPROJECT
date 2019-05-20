using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {
	public GameObject[] displayWhenPlay;
	public GameObject[] displayWhenPaused;
	public GameObject[] displayWhenMuted;
	public GameObject[] displayWhenUnmuted;
	public AudioSource aud;
	public Dropdown dropdown;
	public List<string> difficultys = new List<string> (){ "EASY", "MEDIUM", "HARD" };
	public string currDifficulty;

	// Use this for initialization
	void Start () {

//		dropdown.AddOptions (difficultys);

		currDifficulty = PlayerPrefs.GetString ("Difficulty"); 
			
		displayWhenPlay = GameObject.FindGameObjectsWithTag ("displayWhenPlay");
		displayWhenPaused = GameObject.FindGameObjectsWithTag ("displayWhenPaused");
		displayWhenMuted = GameObject.FindGameObjectsWithTag ("displayWhenMuted");
		displayWhenUnmuted = GameObject.FindGameObjectsWithTag ("displayWhenUnmuted");

		foreach (GameObject g in displayWhenUnmuted)
			g.SetActive (true);
		foreach (GameObject g in displayWhenMuted)
			g.SetActive (false);
		
		if (aud == null)
			aud = GetComponent<AudioSource> ();
		aud.clip = GameObject.Find ("LevelManager").GetComponent<LevelManagerScript> ().wordAud;
		
		foreach (GameObject g in displayWhenPaused)
			g.SetActive (false);
		foreach (GameObject g in displayWhenPlay)
			g.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {


			
	}

	public void Dropdown_IndexChanged(int index){

		currDifficulty = difficultys [index];
		PlayerPrefs.SetString ("Difficulty", currDifficulty);

	}

	public void StartButton(){
		SceneManager.LoadScene ("Scene1");
	}

	public void QuitButton(){
	//	SceneManager.LoadScene ("Quit");
		Application.Quit();
	}

	public void OptionsButton(){
		SceneManager.LoadScene ("Option");
	}

	public void BackHome(){
		SceneManager.LoadScene ("Start_Scene");
	}

	public void PauseGame(){
		Time.timeScale = 0;
		foreach (GameObject g in displayWhenPaused)
			g.SetActive (true);
		foreach (GameObject g in displayWhenPlay)
			g.SetActive (false);
	}

	public void ResumeGame(){
		Time.timeScale = 1;
		foreach (GameObject g in displayWhenPaused)
			g.SetActive (false);
		foreach (GameObject g in displayWhenPlay)
			g.SetActive (true);
	}

	public void playSound(){
		aud.Play ();
	}

	public void Instructions(){
		SceneManager.LoadScene ("Instructions");
	}

	public void Mute(){
		AudioListener.volume = 0.0f;
		foreach (GameObject g in displayWhenUnmuted)
			g.SetActive (false);
		foreach (GameObject g in displayWhenMuted)
			g.SetActive (true);
	}

	public void Unmute(){
		AudioListener.volume = 0.7f;
		foreach (GameObject g in displayWhenUnmuted)
			g.SetActive (true);
		foreach (GameObject g in displayWhenMuted)
			g.SetActive (false);
	}
		
		
}
