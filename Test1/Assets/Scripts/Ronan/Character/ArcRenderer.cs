/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class ArcRenderer : MonoBehaviour {

	public LineRenderer Lr;

	private Pounce pnce;

	private int steps = 100;
	private float velocity =200f;
	private float g;
	private float distanceX = 2f; 

	// Use this for initialization
	void Start () {
		pnce = gameObject.GetComponent<Pounce> ();
		g = Physics2D.gravity.y ;
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 _tempDir = pnce.rightStick;
		float theAngle = Vector2.Angle (Vector2.right, _tempDir);
		if(pnce.rightBeingUsed)
		{
			RenderArc (theAngle);
		}
		//print (theAngle);

	}

	void RenderArc(float Angle)
	{
		Lr.startWidth = 0.5f;
		Lr.endWidth = 0.5f;
		Lr.positionCount = steps;
		Lr.SetPositions (CalculateArc (Angle,pnce.powerVal));
	}

	Vector3[] CalculateArc(float angle,float _velocity)
	{
		float _y = 0;
		float _x = 0;
		Vector3[] positions = new Vector3[steps];

		_x = (0 - _velocity * _velocity) / 2 * g;

		float _newX = _x / steps;
		float currPos = transform.parent.transform.position.x;

		for (int i = 0; i < steps; i++) {
			_y = distanceX * Mathf.Tan (angle) - (g * currPos * currPos) / (2 * _velocity * _velocity * Mathf.Cos (angle) * Mathf.Cos (angle));
			Vector3 _temp = new Vector3 (currPos, _y,0);
			positions [i] = _temp;

			currPos += _newX;

		}
		return positions;


	}
}
*/