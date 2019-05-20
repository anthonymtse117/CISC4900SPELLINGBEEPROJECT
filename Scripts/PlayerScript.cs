using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public float movespeed = 5;
	public float movement;
	public float UpDownMovement;
	public Rigidbody2D rigid;
	public Animator anim;
	public bool isFacingRight = true;
	public float jumpHeight = 100;
	public int lifes = 3;
	public GameObject lifeFull_1;
	public GameObject lifeEmpty_1;
	public GameObject lifeFull_2;
	public GameObject lifeEmpty_2;
	public GameObject lifeFull_3;
	public GameObject lifeEmpty_3;

	// Use this for initialization
	void Start () {	
		if (GetComponent<Rigidbody>() == null) {
			rigid = GetComponent<Rigidbody2D> ();
		}

		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (lifes >= 3) {
			
			lifeFull_3.GetComponent<SpriteRenderer> ().enabled = true;
			lifeEmpty_3.GetComponent<SpriteRenderer> ().enabled = false;

		} else {
			
			lifeEmpty_3.GetComponent<SpriteRenderer> ().enabled = true;
			lifeFull_3.GetComponent<SpriteRenderer> ().enabled = false;
		}


		if (lifes >= 2) {
			lifeFull_2.GetComponent<SpriteRenderer> ().enabled = true;
			lifeEmpty_2.GetComponent<SpriteRenderer> ().enabled = false;
		} else {
			lifeEmpty_2.GetComponent<SpriteRenderer> ().enabled = true;
			lifeFull_2.GetComponent<SpriteRenderer> ().enabled = false;
		}


		if (lifes >= 1) {
			lifeFull_1.GetComponent<SpriteRenderer> ().enabled = true;
			lifeEmpty_1.GetComponent<SpriteRenderer> ().enabled = false;
		} else {
			lifeEmpty_1.GetComponent<SpriteRenderer> ().enabled = true;
			lifeFull_1.GetComponent<SpriteRenderer> ().enabled = false;
		}

		UpDownMovement = Input.GetAxis ("Vertical");
		movement = Input.GetAxis ("Horizontal");

		if (movement != 0)
			anim.SetInteger ("Phase", 1);
		else
			anim.SetInteger ("Phase", 0);

		if (isFacingRight == false && movement > 0)
			Flip ();
		if (isFacingRight == true && movement < 0)
			Flip ();
	
		//if (rigid.velocity.y != 0)
		//	isGrounded = false;
		//if (rigid.velocity.y == 0)
		//	isGrounded = true;
	}
		
	void FixedUpdate(){
		rigid.velocity = new Vector2 (UpDownMovement * movespeed, rigid.velocity.y);
		rigid.velocity = new Vector2 (movement * movespeed, rigid.velocity.x);



	//	if (Input.GetKeyDown (KeyCode.Space))
			/* && isGrounded == true*/
	//		rigid.velocity = new Vector2 (0, jumpHeight);
	}

	void Flip(){
		Vector3 playerScale = transform.localScale;
		playerScale.x *= -1;
		transform.localScale = playerScale;
		isFacingRight = !isFacingRight;
	}

	void Jump(){
		rigid.AddForce (Vector2.up * jumpHeight,ForceMode2D.Impulse);
	}
}