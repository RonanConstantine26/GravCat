using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LrHandler : MonoBehaviour {

	public LineRenderer Lr;
	public GameObject Aimer;
	public GameObject AimerInner;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		UpdateLineRenderer ();

	}

	void UpdateLineRenderer()
	{
		Lr.startWidth = 1f;
		Lr.endWidth = 0f;
		Lr.positionCount = 2;
		Lr.SetPosition (0,AimerInner.transform.position);
		Lr.SetPosition (1,Aimer.transform.position);
	}


}
