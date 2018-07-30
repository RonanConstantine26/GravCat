using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles all raycasts for the player
public class RayCastController : MonoBehaviour {

	public GameObject[] Rays;
	public GameObject RayHolder,AimerHolder;
	public Pounce pnce;

	public TestLevel TL;

	public bool attachRight,attachLeft,attachTop,attachBottom;
	public bool attachRightAny,attachLeftAny,attachTopAny,attachBottomAny;

	// Use this for initialization
	void Start () {
		pnce = gameObject.GetComponent<Pounce> ();
		TL =GameObject.Find ("GameManager").GetComponent<TestLevel> ();
	}
	
	// Update is called once per frame
	void Update () {
		List<RaycastHit2D> hits =CreateRay ();
	}

	//raycasts to find walls
	//returns all raycasthits
	List<RaycastHit2D> CreateRay()
	{
		if (Rays != null) {
			attachTop = false;
			attachTopAny = false;
			attachBottom = false;
			attachBottomAny = false;
			attachLeftAny = false;
			attachLeft = false;
			attachRight = false;
			attachRightAny = false;


			List<RaycastHit2D> hits = new List<RaycastHit2D>();

			foreach (GameObject ray in Rays) {
				string _name = ray.name;

				if(_name.Contains("Left"))
				{
					RaycastHit2D _hit = Physics2D.Raycast (ray.transform.position, Vector2.left,0.3f);
					hits.Add (_hit);
					if (_hit.transform != null && _hit.transform.tag == "Environment") {
						//print (_hit.transform.gameObject);
						attachLeft = true;
					} /*else {
						
						attachLeft = false;
					}*/

					if (_hit.transform != null && _hit.transform.tag == "Area") {
						//print (_hit.transform.gameObject);
						attachLeftAny = true;
					}/* else {
						attachLeftAny = false;
					}*/
				}
				if(_name.Contains("Right"))
				{
					RaycastHit2D _hit = Physics2D.Raycast (ray.transform.position, Vector2.right,0.3f);
					hits.Add (_hit);
					if (_hit.transform != null && (_hit.transform.tag == "Environment" ) ){
						//print (_hit.transform.gameObject);
						attachRight = true;
					}
					/*else {
						attachRight = false;
					}*/

					if (_hit.transform != null && _hit.transform.tag == "Area") {
						//print (_hit.transform.gameObject);
						attachRightAny = true;
					}/* else {
						attachRightAny = false;
					}*/
				}
				if(_name.Contains("Top"))
				{
					RaycastHit2D _hit = Physics2D.Raycast (ray.transform.position, Vector2.up,0.3f);
					hits.Add (_hit);
					if (_hit.transform != null && _hit.transform.tag == "Environment" ) {
						//print (_hit.transform.gameObject);
						attachTop = true;
					}
					/*else {
						attachTop = false;
					}*/

					if (_hit.transform != null && _hit.transform.tag == "Area") {
						//print (_hit.transform.gameObject);
						attachTopAny = true;
					} /*else {
						attachTopAny = false;
					}*/
				}
				if(_name.Contains("Bottom"))
				{
					RaycastHit2D _hit = Physics2D.Raycast (ray.transform.position, Vector2.down,0.3f);
					hits.Add (_hit);
					if (_hit.transform != null && _hit.transform.tag == "Environment" ) {
						//print (_hit.transform.gameObject);
						attachBottom = true;
					}
				/*	else {
						attachBottom = false;
					}*/

					if (_hit.transform != null && _hit.transform.tag == "Area") {
						//print (_hit.transform.gameObject);
						attachBottomAny = true;
					} /*else {
						attachBottomAny = false;
					}*/
				}
			}

			return hits;


		}
		return null;
	}

	//turns raycast holder & Aimer Holder right
	public void TurnRight()
	{
		RayHolder.transform.Rotate (0, 0, 90f);
		AimerHolder.transform.Rotate (0, 0, 90f);
		print("turned right");
	}
	//turns raycast holder & Aimer Holder left
	public void TurnLeft()
	{
		RayHolder.transform.Rotate (0, 0, -90f);
		AimerHolder.transform.Rotate (0, 0, -90f);
		print ("turned left");
	}
}
