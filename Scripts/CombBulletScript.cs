using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombBulletScript : MonoBehaviour {

	public float bulletSpeed;
	public Rigidbody2D rigid;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		rigid.velocity = new Vector2 (bulletSpeed, rigid.velocity.y);
	}
}
