using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingBlockController : MonoBehaviour {

	private bool disappearUponTouch = false;
	private float startDisappearingTime;
	public float scaleDownTime = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (disappearUponTouch == true) {
			scaleDownAndDisappear ();
			this.transform.Rotate (new Vector3 (0, 0, 250f) * Time.deltaTime);
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			disappearUponTouch = true;
			startDisappearingTime = Time.time;
		}
	}

	void scaleDownAndDisappear(){
		Destroy (this.gameObject, scaleDownTime);
		float t = (Time.time - startDisappearingTime) / scaleDownTime;
		this.transform.localScale = Vector3.Lerp (this.transform.localScale, new Vector3(0.1f, 0.1f, 0.1f), t);
	}
}
