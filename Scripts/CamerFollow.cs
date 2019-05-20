using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour {
	public Transform player;
	public float dist = 10.0f;
	// Use this for initialization
	void Start () {
		//player = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.position.x, player.position.y, player.position.z - dist);
	}
}
