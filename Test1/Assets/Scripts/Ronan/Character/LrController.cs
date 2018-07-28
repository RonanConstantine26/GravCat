using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class LrController : MonoBehaviour {

	public Pounce pnce;
	public LrHandler lrH;
	public GameObject Aimer,AimerInner;

	public float minSize = 6;
	public float maxSize = 11;
	public float ArrowSize;

	private float StartColourR =1f;
	private float StartColourG =1f;
	private float StartColourB =1f;
	private float StartColourA =1f;

	private float EndColourR =0.62745f;
	private float EndColourG =0;
	private float EndColourB =0;
	private float EndColourA =1f;




	//Red = 160,0,0
	//white = 255,255,255

	// Use this for initialization
	void Start () {
		pnce = gameObject.GetComponent<Pounce> ();
		ArrowSize = 2;
	}
	
	// Update is called once per frame
	void Update () {
		float _dirX = pnce.rightStick.x;
		float _dirY = pnce.rightStick.y;

		//Handles changing of arrow size and colour
		ArrowSize = 2 + (pnce.powerVal -5)/3 - 1;
		lrH.Lr.startColor = ChangeColour (15, 30, pnce.powerVal);
		lrH.Lr.endColor = ChangeColour (15, 30, pnce.powerVal);

		//Handles moving of arrow 
		Quaternion targetRotation = Quaternion.identity;
		Aimer.transform.localPosition = new Vector2 ( _dirX * (minSize+ArrowSize), _dirY * (minSize+ArrowSize));
		targetRotation = Quaternion.LookRotation (Vector3.forward, -(Aimer.transform.position - transform.position));

		AimerInner.transform.localPosition = new Vector2 ( _dirX * 6,_dirY * 6);
		targetRotation = Quaternion.LookRotation (Vector3.forward, -(AimerInner.transform.position - transform.position));


	}

	//returns a colour based on two values and the current value between those two values
	Color ChangeColour(float start, float end, float current)
	{
		//-0.32755
		float rDiff = EndColourR - StartColourR;
		float gDiff = EndColourG - StartColourG;
		float bDiff = EndColourB - StartColourB;
		float aDiff = EndColourA - StartColourA;

		float difference = end - start;
		float currFactor = ((current-start) / difference);

		float rAdd = StartColourR + (rDiff * currFactor);
	//	print (rAdd);
		float gAdd = StartColourG + (gDiff * currFactor);
		float bAdd = StartColourB + (bDiff * currFactor);
		float aAdd = StartColourA + (aDiff * currFactor);

		Color _NewColour = new Color (rAdd, gAdd, bAdd, aAdd);

		return _NewColour;

	}
}
