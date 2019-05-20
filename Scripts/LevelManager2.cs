using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager2 : MonoBehaviour {

	public int LettersCorrect = 0;
	// Use this for initialization
	void Start () {

		GameObject.Find ("Word_Letter_1").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("Word_Letter_2").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("Word_Letter_3").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("Word_Letter_4").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("Word_Letter_5").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("Word_Letter_6").GetComponent<SpriteRenderer> ().enabled = false;
	}

	// Update is called once per frame
	void Update () {

		if (LettersCorrect == 1)
			GameObject.Find ("Word_Letter_1").GetComponent<SpriteRenderer> ().enabled = true;
		if (LettersCorrect == 2)
			GameObject.Find ("Word_Letter_2").GetComponent<SpriteRenderer> ().enabled = true;
		if (LettersCorrect == 3)
			GameObject.Find ("Word_Letter_3").GetComponent<SpriteRenderer> ().enabled = true;
		if (LettersCorrect == 4)
			GameObject.Find ("Word_Letter_4").GetComponent<SpriteRenderer> ().enabled = true;
		if (LettersCorrect == 5)
			GameObject.Find ("Word_Letter_5").GetComponent<SpriteRenderer> ().enabled = true;
		if (LettersCorrect == 6)
			GameObject.Find ("Word_Letter_6").GetComponent<SpriteRenderer> ().enabled = true;
	}



}
