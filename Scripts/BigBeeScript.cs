using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBeeScript : MonoBehaviour {

	public GameObject bulletComb;
	public Transform Firepoint;
	public float spawnTimer = 1;
	public Animator anim;
	// Use this for initialization
	void Start () {
		anim.SetInteger ("Phase", 1);
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer -= Time.deltaTime;
		if (spawnTimer <= 0) {
			Instantiate (bulletComb, Firepoint.transform.position, Firepoint.transform.rotation);
			spawnTimer = 1;
		}


		
	}
}
