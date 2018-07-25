using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//various mouse handling functions
public class MouseFinder : MonoBehaviour {

	public Vector3 MousePos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {




	}

	//finds mouse on the screen in screen co-ords in 3d co-ords
	public Vector3 FindMouse()
	{
		///////////////////////////////////////////////////////////
		/// ///////////Finding Mouse Pos Start///////////////////
		/// //////////////////////////////////////////////////////
		Vector3 ScreenPos = new Vector3 ();
		Camera c = Camera.main;

		ScreenPos.x = Input.mousePosition.x;
		ScreenPos.y = Input.mousePosition.y;

		MousePos = c.ScreenToWorldPoint (new Vector3 (ScreenPos.x,ScreenPos.y,0));
		MousePos.z = 0;
		//print (MousePos);
		return MousePos;

		///////////////////////////////////////////////////////////
		/// ///////////Finding Mouse Pos end///////////////////
		/// //////////////////////////////////////////////////////
	}

	//finds mouse on the screen in screen co-ords in 2d co-ords
	public Vector2 FindMouse2D()
	{
		///////////////////////////////////////////////////////////
		/// ///////////Finding Mouse Pos Start///////////////////
		/// //////////////////////////////////////////////////////
		Vector2 ScreenPos = new Vector2 ();
		Camera c = Camera.main;

		ScreenPos.x = Input.mousePosition.x;
		ScreenPos.y = Input.mousePosition.y;

		MousePos = c.ScreenToWorldPoint (new Vector2 (ScreenPos.x,ScreenPos.y));
		//MousePos.z = 0;
		//print (MousePos);
		return MousePos;

		///////////////////////////////////////////////////////////
		/// ///////////Finding Mouse Pos end///////////////////
		/// //////////////////////////////////////////////////////
	}

	//rounds the position of an object/mouse to the nearest chosen int
	public Vector2 RoundPosition(float RoundFactor, Vector2 position)
	{
		if (RoundFactor == 0) {
			throw new UnityException ("Factor Must Not Be 0");
		}
		float x = Mathf.Round (position.x / RoundFactor) * RoundFactor;
		float y = Mathf.Round (position.y / RoundFactor) * RoundFactor;

		return new Vector2 (x, y);
	}
}
