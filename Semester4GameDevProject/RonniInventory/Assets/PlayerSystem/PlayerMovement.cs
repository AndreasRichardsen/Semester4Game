using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var vert = Input.GetAxis("Vertical");
        var horiz = Input.GetAxis("Horizontal");
        transform.Translate(-vert*Time.deltaTime*5, 0f, horiz*Time.deltaTime*5);
	}
}
