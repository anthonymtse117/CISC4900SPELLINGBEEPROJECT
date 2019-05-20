using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildLetter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponentInParent<SpriteRenderer>().enabled == false)
			gameObject.GetComponent<SpriteRenderer>().enabled = false;

			if(GetComponentInParent<SpriteRenderer>().enabled == true)
			gameObject.GetComponent<SpriteRenderer>().enabled =true;
	
		}
}
