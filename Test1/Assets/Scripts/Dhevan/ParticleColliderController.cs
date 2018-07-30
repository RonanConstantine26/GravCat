using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColliderController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnParticleCollision2D(GameObject other){
		Debug.Log ("Particle Hit");
		// Do Something
	}
}
