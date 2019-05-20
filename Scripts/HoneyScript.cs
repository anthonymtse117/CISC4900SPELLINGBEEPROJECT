using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyScript : MonoBehaviour {
	public Rigidbody2D rigid;
	public Animator anim;
	public AudioSource aud;
	public float speed = 1f;
	public float maxRotation = 8f;

	// Use this for initialization
	void Start () {	
		//Debug.Log("hit the honey comb watch it explode!");
		if (GetComponent<Rigidbody>() == null) {
			rigid = GetComponent<Rigidbody2D> ();
		}
		if (aud == null) {
			aud = GetComponent<AudioSource> ();
		}

		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		// makes the honeycomb rotate back and forth
		transform.rotation = Quaternion.Euler (0f, 0f, maxRotation * Mathf.Sin (Time.time * speed));

	}

	void OnTriggerEnter2D(Collider2D other){
		//if player comes in contact with the honeycomb destroy play the destroy animation and set the game object to be inactive.
	//	Debug.Log("hit the honey comb watch it explode!");
		if (other.gameObject.CompareTag ("Player")){
			aud.Play ();
			anim.SetInteger ("HoneyHit", 1);
			Destroy(gameObject, anim.GetCurrentAnimatorClipInfo(0).Length);
		
		//GetComponent<SpriteRenderer>().enabled = false;
		//Destroy (gameObject,1);
	}
		
}
}