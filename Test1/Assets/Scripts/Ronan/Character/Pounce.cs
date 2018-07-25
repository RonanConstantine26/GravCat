using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles the pounce mechanic
public class Pounce : MonoBehaviour {

	public MouseFinder MF;
	public Character Char;
	public TestLevel TL;
	public Rigidbody2D rb;


	public bool isClicked;
	public GameObject CurrGameobj;
	public GameObject PrevGameobj;
	public GameObject theLevel;

	private Vector2 initPos, endPos;
	private Vector2 OriPos;
	private float Power = 100f;
	private float AttachDistance = 1.3f;
	private float PullDistance = 10f;

	private Vector2 distFromParent;





	void Start () {
		MF = GameObject.Find ("GameManager").GetComponent<MouseFinder> ();
		TL =GameObject.Find ("GameManager").GetComponent<TestLevel> ();
		rb = gameObject.GetComponent<Rigidbody2D> ();
		Char = gameObject.GetComponent<Character> ();
		OriPos = new Vector2 (0, 0);
	}
	

	void Update () {

		//print ("x " +rb.velocity.x.ToString());
		//print ("y " + rb.velocity.y.ToString());
		//print(CurrGameobj.name);

		/////////////////////////////////////////////////
		//Handling of clicking and dragging for pounce
		if (Input.GetMouseButtonDown (0) &&Vector3.Distance( MF.FindMouse(),gameObject.transform.position)<=AttachDistance && !TL.isTurning) {
			isClicked = true;
			initPos = MF.FindMouse2D ();
		
		}

		else if (Input.GetMouseButtonUp (0)) {
			
			if (isClicked) {
				isClicked = false;
				Char.isImmobile = false;
				endPos = MF.FindMouse2D ();
				transform.parent = null;
				PrevGameobj = CurrGameobj;
				LaunchCharacter ();
			}

		}
		//////////////////////////////////////////////////////////

		//Makes player immobile
		if (Char.isImmobile) {
			rb.gravityScale=0;
			rb.velocity = Vector2.zero;
		} else if(!Char.isImmobile) {
			rb.gravityScale=1;
		}

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		//Handles the player collision with the environment
		if(other.gameObject.tag == "Environment" && other.gameObject != CurrGameobj)
		{
			Char.isImmobile = true;
			CurrGameobj = other.gameObject;
			transform.parent = theLevel.transform;

		}
	}
	void OnCollisionExit2D(Collision2D other)
	{
		
	}
		
	//Shoots the player in a chosen direction
	void LaunchCharacter()
	{
		
		rb.AddForce (CalculateForce()*Power);


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
