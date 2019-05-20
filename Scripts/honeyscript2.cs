using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honeyscript2 : MonoBehaviour {

	public string Letter_ID;
	public string Letter_Name;
	public int Word_Letter_ID;
	public Rigidbody2D rigid;
	public Animator anim;
	public AudioSource aud;
	public float speed = 1f;
	public float maxRotation = 8f;
	public float timer;

	// Use this for initialization
	void Start () {
		if (GetComponent<Rigidbody>() == null) {
			rigid = GetComponent<Rigidbody2D> ();
		}

		if (aud == null)
			aud = GetComponent<AudioSource> ();

		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		transform.rotation = Quaternion.Euler (0f, 0f, maxRotation * Mathf.Sin (Time.time * speed));
		timer -= Time.deltaTime;

		if (timer <= 0) {
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			gameObject.GetComponent<BoxCollider2D> ().enabled = true;
			gameObject.GetComponentInChildren<SpriteRenderer> ().enabled = true;
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (Word_Letter_ID == GameObject.Find ("LevelManager").GetComponent<LevelManager2> ().LettersCorrect + 1) {
				if (GameObject.Find (Letter_Name).tag == Letter_ID) {
					GameObject.Find ("LevelManager").GetComponent<LevelManager2> ().LettersCorrect++;
					aud.Play ();
					GameObject.Find ("ScoreText").GetComponent<ScoreScript> ().score += 100;
					anim.SetInteger ("HoneyHit", 1);
					Destroy (gameObject, anim.GetCurrentAnimatorClipInfo (0).Length);
				}
			} 

			else {
				gameObject.GetComponent<SpriteRenderer>().enabled = false;
				gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				GameObject.Find ("ScoreText").GetComponent<ScoreScript> ().score -= 10;
				timer = 5f;


			}



		}


	}



}
