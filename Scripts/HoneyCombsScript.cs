using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyCombsScript : MonoBehaviour {

	public char Letter_ID;
	public string Letter_Name;
	public int Word_Letter_ID;
	public Rigidbody2D rigid;
	public Animator anim;
//	public AudioSource correctAud;
//	public AudioSource incorrectAud;
	public float speed = 1f;
	public float maxRotation = 8f;
	public float timer;
	public bool shouldMove = false;
	public Transform target;
	public Renderer[] Rends;

	// Use this for initialization
	void Start () {
		if (GetComponent<Rigidbody>() == null) {
			rigid = GetComponent<Rigidbody2D> ();
		}

		Rends = gameObject.GetComponentsInChildren<Renderer> ();
			

	//	if (correctAud == null)
	//		correctAud = GetComponent<AudioSource> ();

	//	if (incorrectAud == null)
	//		incorrectAud = GetComponent<AudioSource> ();

		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.rotation = Quaternion.Euler (0f, 0f, maxRotation * Mathf.Sin (Time.time * speed));
		timer -= Time.deltaTime;

		if ((timer <= 0) && (timer > -1)) {
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			gameObject.GetComponent<BoxCollider2D> ().enabled = true;
			gameObject.GetComponentInChildren<SpriteRenderer> ().enabled = true;
		}

		if (shouldMove == false)
			target = GameObject.Find ("LevelManager").GetComponent<LevelManagerScript> ().letterLocations [GameObject.Find ("LevelManager").GetComponent<LevelManagerScript> ().LettersCorrect].transform;
		if (shouldMove == true)
			Invoke ("move", 1f);

	}
		
	void disableSprite(){
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		gameObject.GetComponent<BoxCollider2D> ().enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (gameObject.GetComponent<HoneyCombsScript> ().Letter_ID.CompareTo (GameObject.Find ("LevelManager").GetComponent<LevelManagerScript> ().currentLetter) == 0) {
				if(GameObject.Find ("LevelManager").GetComponent<LevelManagerScript> ().LettersCorrect < GameObject.Find ("LevelManager").GetComponent<LevelManagerScript> ().CurrentWord.Length-1)
				GameObject.Find("LevelManager").GetComponent<LevelManagerScript>().correctSound.Play();
				else 
					GameObject.Find("LevelManager").GetComponent<LevelManagerScript>().WinSound.Play();
				
				gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				GameObject.Find ("LevelManager").GetComponent<LevelManagerScript> ().LettersCorrect++;
				GameObject.Find ("ScoreText").GetComponent<ScoreScript> ().score += 100;
				anim.SetInteger ("HoneyHit", 1);
				Invoke ("disableSprite", 1.25f);
				timer = -1f;
				shouldMove = true;

			
			} else {
				GameObject.Find("LevelManager").GetComponent<LevelManagerScript>().IncorrectSound.Play();
				gameObject.GetComponent<SpriteRenderer> ().enabled = false;
				gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				GameObject.Find ("BeeMan").GetComponent<PlayerScript> ().lifes -= 1;
				timer = 5f;

			}
		}
	}

	void move(){
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, Time.deltaTime * 10);
		gameObject.transform.parent =	target.transform;
		foreach (Renderer Rend in Rends)
			Rend.material.color = Color.black;
		
	}	
		
}
