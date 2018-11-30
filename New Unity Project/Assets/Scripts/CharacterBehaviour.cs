using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour {
	GameObject characterCube;

	// Use this for initialization
	public Vector3 placeNum1;
	public Vector3 placeNum2;
	public Vector3 placeNum3;

	public Vector3 startingLocation;

	void Start () {
		startingLocation = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		startingLocation = gameObject.transform.position;
	}
}
