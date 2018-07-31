using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the movement of the level for now.
//Too reliant on the player controller
public class TestLevel : MonoBehaviour {

	public GameObject Level;
	public GameObject ThePlayer;
	public bool isTurningRight;
	public bool isTurningLeft;
	public bool hasTurned;

	public RayCastController RCC;

	public Rigidbody2D rb;

	public GameObject GroundLevel;

	private float TimeToRotate = 0.6f;
	private float TimeToRotateSmall = 0.3f;
	private float multiplier = 400f;


	private float[] possibleRots = new float[4]{ 0, -90f, 180f,90f };
	private int counter;

	private float StartVal;
	private float End;
	private float CurrVal;

	// Use this for initialization
	void Start () {
		isTurningRight = false;
		isTurningLeft = false;
		hasTurned = false;
		RCC =GameObject.Find ("Player").GetComponent<RayCastController> ();
		counter = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
		////////////////////////////////
		//rotates the level depending on how high the player is from the floor when they hit the wall
		if (Mathf.Abs (GroundLevel.transform.position.y - ThePlayer.transform.position.y) > 13.5) {
			print ("big");
			if (!RCC.attachTop && !RCC.attachBottom) {
				if (RCC.attachRight && !hasTurned && !isTurningRight) {
					
					ChangeCounter (true);


					RCC.TurnRight ();

					StartCoroutine (RotateRight ());

				}
				if (RCC.attachLeft && !hasTurned && !isTurningLeft) {
					ChangeCounter (false);
					RCC.TurnLeft ();
					StartCoroutine (RotateLeft ());

				}
			}
		} else {
			print ("small");
			if (!RCC.attachTop && !RCC.attachBottom) {
				if (RCC.attachRight && !hasTurned) {
					

					StartCoroutine (RotateRightSmall ());

				}
				if (RCC.attachLeft && !hasTurned) {


					StartCoroutine (RotateLeftSmall ());

				}
			}
		}



		if (!isTurningRight && !isTurningLeft) {

			RoundAngle ();
			//Uncomment to jump off roof
			if(RCC.attachBottom || RCC.attachBottomAny/*|| RCC.attachTopAny||RCC.attachTop*/)
			{
				ThePlayer.GetComponent<Character> ().canJump = true;

			}
		}

		//makes sure the player stays in the right position 
		/*if((!isTurningRight || !isTurningLeft ) && rb.velocity== Vector2.zero)
		{
			
			RCC.pnce.Char.isImmobile = false;
			//caThePlayer.transform.localPosition = RCC.pnce.lastPos;

		}*/


	}
	//checks the levels rotation
	bool CheckLevelRot()
	{
		float _rot = Level.transform.eulerAngles.z;

		if (_rot < 1 && _rot > -1) {
			return true;
		} else if (_rot < 91 && _rot > 89) {
			return true;
		} else if (_rot < 181 && _rot > 179) {
			return true;
		} else if (_rot < 271 && _rot > 269) {
			return true;
		} else {
			return false;
		}

	}

	//changes counter
	void ChangeCounter (bool isGoingRight)
	{
		if(isGoingRight)
		{
			counter++;
			if(counter >3)
			{
				counter = 0;
			}
		}
		else if(!isGoingRight)
		{
			counter--;
			if(counter <0)
			{
				counter = 3;
			}
		}
	}

	//bounces players to a direction
	void BouncePlayer(bool onRight/*,Vector3 oriRot*/)
	{

		ThePlayer.transform.parent = null;
		
		if (onRight) {
			ThePlayer.GetComponent<Character> ().isImmobile = false;
			ThePlayer.GetComponent<Rigidbody2D> ().AddForce (new Vector2( -4000 * Time.deltaTime,0));


		} else {
			ThePlayer.GetComponent<Character> ().isImmobile = false;
			ThePlayer.GetComponent<Rigidbody2D> ().AddForce (new Vector2( 4000 * Time.deltaTime,0));

		}
	}


	//rotates the stage right
	public IEnumerator RotateRight()
	{
		

		float step = TimeToRotate * multiplier*Time.deltaTime*2;
		isTurningRight = true;
		float amount = 0;

		for (int i = 0; i < step; i++) {
			
			Level.transform.Rotate (0, 0, (-45f / step));
			amount += Mathf.Abs ((-45f / step));
			//print (amount);
			Level.transform.position= new Vector3 (0, (11/step*i), 0);
			yield return new WaitForSecondsRealtime (TimeToRotate/step);
		}

		for (int i = 0; i < step; i++) {
			
			Level.transform.Rotate (0, 0, (-45f / step));
			amount += Mathf.Abs ((-45f / step));
			//print (amount-90);
			Level.transform.position= new Vector3 (0, (11-11/step*i), 0);
			yield return new WaitForSecondsRealtime (TimeToRotate/step);
			if(Mathf.Abs(amount-90)<=1.5f)
			{
				print ("Hi");
				float _diff = amount - 90f;
				Vector3 _tempVec = Level.transform.eulerAngles;
				//_tempVec.z = _tempVec.z - _diff;
				_tempVec.z = possibleRots[counter];
				Level.transform.eulerAngles = _tempVec;
				i = (int)step;

			}
		}
		Vector3 _tempVec2 = Level.transform.eulerAngles;
		//_tempVec.z = _tempVec.z - _diff;
		_tempVec2.z = possibleRots[counter];
		Level.transform.eulerAngles = _tempVec2;
		Level.transform.position= new Vector3 (0, 0, 0);


		Level.transform.position= new Vector3 (0, 0, 0);

		isTurningRight = false;
		ThePlayer.GetComponent<Character> ().canJump = true;
		RoundAngle ();


	}

//	rotates the stage only a bit and then returns it to its orignal rotation
	public IEnumerator RotateRightSmall()
	{
		BouncePlayer(true);
		float step = TimeToRotateSmall * multiplier*Time.deltaTime*2;
		isTurningRight = true;
		float amount = 0;

		for (int i = 0; i < step; i++) {

			Level.transform.Rotate (0, 0, (-3f / step));
			amount += Mathf.Abs ((-3f / step));
			//print (amount);
			Level.transform.position= new Vector3 (0, (1f/step*i), 0);
			yield return new WaitForSecondsRealtime (TimeToRotateSmall/step);
		}

		for (int i = 0; i < step; i++) {

			Level.transform.Rotate (0, 0, (3f / step));
			amount += Mathf.Abs ((3f / step));
			//print (amount-90);
			Level.transform.position= new Vector3 (0, (1f-1f/step*i), 0);
			yield return new WaitForSecondsRealtime (TimeToRotateSmall/step);

		}

		isTurningRight = false;
		ThePlayer.GetComponent<Character> ().canJump = true;
		RoundAngle ();

	}


	///////////////////////////////////////////////////	

	//rotates the stage left fully
	public IEnumerator RotateLeft()
	{
		


		float step = TimeToRotate * multiplier*Time.deltaTime*2;
		isTurningLeft = true;
		float amount = 0;

		for (int i = 0; i < step; i++) {

			Level.transform.Rotate (0, 0, (45f / step));
			amount += Mathf.Abs ((45f / step));
			//print (amount);
			Level.transform.position= new Vector3 (0, (11/step*i), 0);
			yield return new WaitForSecondsRealtime (TimeToRotate/step);
		}

		for (int i = 0; i < step; i++) {

			Level.transform.Rotate (0, 0, (45f / step));
			amount += Mathf.Abs ((45f / step));
			//print (amount-90);
			Level.transform.position= new Vector3 (0, (11-11/step*i), 0);
			yield return new WaitForSecondsRealtime (TimeToRotate/step);
			if(Mathf.Abs(amount-90)<=1.5f)
			{
				//print ("Hi");
				float _diff = amount - 90f;
				Vector3 _tempVec = Level.transform.eulerAngles;
				//_tempVec.z = _tempVec.z - _diff;
				_tempVec.z = possibleRots[counter];
				Level.transform.eulerAngles = _tempVec;
				i = (int)step;

			}
		}
		Vector3 _tempVec2 = Level.transform.eulerAngles;
		//_tempVec.z = _tempVec.z - _diff;
		_tempVec2.z = possibleRots[counter];
		Level.transform.eulerAngles = _tempVec2;
		Level.transform.position= new Vector3 (0, 0, 0);

		isTurningLeft = false;
		ThePlayer.GetComponent<Character> ().canJump = true;
		RoundAngle ();
	}
	//rotates the stage only a bit and then returns it to its orignal rotation
	public IEnumerator RotateLeftSmall()
	{
		
		BouncePlayer(false);
		float step = TimeToRotateSmall * multiplier*Time.deltaTime*2;
		//print (step);
		isTurningLeft = true;
		float amount = 0;

		for (int i = 0; i < step; i++) {

			Level.transform.Rotate (0, 0, (3f / step));
			amount += (3f / step);
			//print (amount);
			Level.transform.position= new Vector3 (0, (1f/step*i), 0);
			yield return new WaitForSecondsRealtime (TimeToRotateSmall/step);
		}

		for (int i = 0; i < step; i++) {

			Level.transform.Rotate (0, 0, (-3f / step));
			amount += (-3f / step);
			//print (amount);
			Level.transform.position= new Vector3 (0, (1f-1f/step*i), 0);
			yield return new WaitForSecondsRealtime (TimeToRotateSmall/step);

		}

		isTurningLeft = false;
		ThePlayer.GetComponent<Character> ().canJump = true;
		RoundAngle ();

	}

	public void RoundAngle()
	{
		float angle = Level.transform.eulerAngles.z;

		angle = Mathf.Round (angle / 90) * 90;
		Level.transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, angle);
		print (angle);
	}



}


