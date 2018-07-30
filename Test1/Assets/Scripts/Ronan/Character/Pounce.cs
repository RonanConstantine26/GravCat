using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

//handles the pounce mechanic
public class Pounce : MonoBehaviour {

	public MouseFinder MF;
	public Character Char;
	public TestLevel TL;
	public Rigidbody2D rb;
	public RayCastController RCc;

	public bool isClicked;
	public GameObject CurrGameobj;
	public GameObject PrevGameobj;
	public GameObject theLevel;

	public bool rightBeingUsed;
	public float powerVal;

	public Vector2 lastPos;

	private Vector2 initPos, endPos;
	private Vector2 OriPos;
	private float Power = 900f;
	private float AttachDistance = 1.3f;
	private float PullDistance = 10f;

	private Vector2 distFromParent;
	private bool isIncreasing;

	public Vector2 rightStick;






	void Start () {
		MF = GameObject.Find ("GameManager").GetComponent<MouseFinder> ();
		TL =GameObject.Find ("GameManager").GetComponent<TestLevel> ();
		rb = gameObject.GetComponent<Rigidbody2D> ();
		Char = gameObject.GetComponent<Character> ();
		RCc = gameObject.GetComponent<RayCastController> ();
		OriPos = new Vector2 (0, 0);
		rightBeingUsed = false; 
		powerVal = 10;
		isIncreasing = false;
		Char.canJump = true;
		lastPos = Vector2.zero;
	}
	

	void Update () {

		//Checks for controller
		InputDevice inDev = InputManager.ActiveDevice;
		//print (inDev.RightStickX);

		//updates controller
		if (inDev != null) {
			UpdateInDev (inDev);
		}

		//Increases power
		//if you change the values change them in start too
		if(rightBeingUsed)
		{
			if(powerVal<25)
			{
				if (!isIncreasing) {
					StartCoroutine (IncreasePower ());
				}
			}
		}
		else if(!rightBeingUsed)
		{
			powerVal = 10;
		}
			
		if (Input.GetKeyDown (KeyCode.Return)) {
			
		}
		
		/////////////////////////////////////////////////////
		if(inDev.RightTrigger.WasPressed &&rightBeingUsed && (!TL.isTurningRight|| !TL.isTurningLeft) && Char.canJump)
		{
			Char.canJump = false;
			Char.isImmobile = false;
			Char.canMove = false;
			Char.isJumping = true;
			RCc.attachBottom = false;
			rb.velocity = Vector2.zero;
			endPos = MF.FindMouse2D ();
			transform.parent = null;
			PrevGameobj = CurrGameobj;
			LaunchCharacter ();



		}
		//////////////////////////////////////////////////////////

		//Makes player immobile
		if (Char.isImmobile) {
			rb.isKinematic = true;
			rb.velocity = Vector2.zero;
		} else if(!Char.isImmobile) {
			//rb.gravityScale=1;
			rb.isKinematic= false;
		}



	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(RCc.attachBottom ||RCc.attachBottomAny)
		{
			Char.canMove = true;
		}
		print ("Stuff");
		Char.isJumping = false;
		//Char.isImmobile = true;
		//Handles the player collision with the environment
		if(other.gameObject.tag == "Environment" && other.collider.transform.gameObject != CurrGameobj &&!RCc.attachTop  )
		{
			//lastPos= transform.localPosition;
			Char.isImmobile = true;
			CurrGameobj = other.collider.gameObject;
			transform.parent = theLevel.transform;
			rb.velocity = Vector2.zero;

			//Debug.Break ();
		}
	}
	void OnCollisionExit2D(Collision2D other)
	{
		
	}

	//updates world from the controller input
	void UpdateInDev (InputDevice inDev)
	{
		rightStick = inDev.RightStick.Vector;

		if (rightStick.normalized.magnitude > 0.11f) {
			rightBeingUsed = true;
		} else if (rightStick.normalized.magnitude <= 0.11f) {
			rightBeingUsed = false;
		}
			
	}
	//checks level rotation
	public bool CheckLevelRot()
	{
		float _rot = theLevel.transform.eulerAngles.z;

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
		
	//Shoots the player in a chosen direction
	void LaunchCharacter()
	{
		
		rb.velocity=(rightStick*powerVal);



	}

	//increases shooting power
	IEnumerator IncreasePower()
	{
		isIncreasing = true;
		powerVal += 1;
		yield return new WaitForSecondsRealtime ((0.07f));
		isIncreasing = false;
	}

	//calculates the power of the shot
	Vector2 CalculateForce()
	{
		Vector2 _velocity = new Vector2 ();
		_velocity.x = endPos.x - initPos.x;
		_velocity.y = endPos.y - initPos.y;

		if(_velocity.y >PullDistance)
		{
			_velocity.y = PullDistance;
		}
		else if (_velocity.y <-PullDistance)
		{
			_velocity.y = -PullDistance;
		}

		if(_velocity.x >PullDistance)
		{
			_velocity.x = PullDistance;
		}
		else if (_velocity.x <-PullDistance)
		{
			_velocity.x = -PullDistance;
		}

		_velocity.x = -_velocity.x;
		_velocity.y = -_velocity.y;

		return _velocity;
	}
}
