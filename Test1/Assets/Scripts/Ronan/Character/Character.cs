using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is where you define any important characteristic of the player
public class Character : MonoBehaviour {

	public bool isImmobile;
	public RayCastController RCC;

	private Vector3 size;

	// Use this for initialization
	void Start () {
		RCC = gameObject.GetComponent<RayCastController> ();
		isImmobile = false;
		size = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isImmobile) {
			Vector3 _Rot = new Vector3 (0, 0, /*-RCC.pnce.theLevel.transform.rotation.eulerAngles.z*/ 0);
			transform.localRotation = Quaternion.Euler(_Rot);
		} 
		else if(!isImmobile) {
			Vector3 _Rot = new Vector3 (0, 0, RCC.pnce.theLevel.transform.rotation.eulerAngles.z);
			transform.localRotation = Quaternion.Euler(_Rot);
		}
	}
}
