using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject Player;
	public GameObject MainCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 _tempPos = MainCamera.transform.position;
		_tempPos.x = Player.transform.position.x;
		_tempPos.z = -10f;

		MainCamera.transform.position = _tempPos;
	}
}
