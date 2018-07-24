using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the movement of the level for now.
//Too reliant on the player controller
public class TestLevel : MonoBehaviour {

	public GameObject Level;
	public bool isTurning;
	public bool hasTurned;

	public RayCastController RCC;

	private float TimeToRotate = 0.7f;
	private float multiplier = 100f;

	// Use this for initialization
	void Start () {
		isTurning = false;
		hasTurned = false;
		RCC =GameObject.Find ("Player").GetComponent<RayCastController> ();
	}
	
	// Update is called once per frame
	void Update () {
		/////////////////////////////////

		////////////////////////////////
		//Players ray holder rotates as well
		if(!RCC.attachTop && !RCC.attachBottom )
		{
			if (RCC.attachRight && !hasTurned) {
				RCC.TurnRight ();
				StartCoroutine (RotateRight());

			}
			if (RCC.attachLeft && !hasTurned) {
				RCC.TurnLeft ();
				StartCoroutine (RotateLeft());


			}
		}


	}

	//rotates the stage right
	public IEnumerator RotateRight()
	{
		float step = TimeToRotate * multiplier;
		isTurning = true;

		for (int i = 0; i < step; i++) {
			Level.transform.Rotate (0, 0, -90f / step);
			yield return new WaitForSecondsRealtime (TimeToRotate/step);
		}
		isTurning = false;


	}

	//rotates the stage left
	public IEnumerator RotateLeft()
	{
		float step = TimeToRotate * multiplier;
		isTurning = true;

		for (int i = 0; i < step; i++) {
			Level.transform.Rotate (0, 0, 90f / step);
			yield return new WaitForSecondsRealtime (TimeToRotate/step);
		}
		isTurning = false;
	}
}
