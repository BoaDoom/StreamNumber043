using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour {
	GameObject characterCube;


	public float timePassed;
	public float timeAtMovementStart = 0;
	public float timeToSpendAtLocation;

	public float randomTime = 0f;
	//public float timePassedSinceMovement;
	public Vector2 minMaxTimeAtLocation = new Vector2 (5f, 15f);
	private float periodOfPossibleMovement;

	public Vector3 startingLocation;

	public GameObject[] listOfLocationMarkers;

	public Vector3 lockedStartingLocation = new Vector3(-2.71f, 6.5f, 460.5f);

	void Start () {
		startingLocation = gameObject.transform.position;
		listOfLocationMarkers = GameObject.FindGameObjectsWithTag("positionMarker");
		periodOfPossibleMovement = minMaxTimeAtLocation.y - minMaxTimeAtLocation.x;
		moveToNewPosish ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timeToSpendAtLocation > Time.time) {
			moveToNewPosish ();
		}
	}

	public void moveToNewPosish(){
		chooseNewLocation ();
		timeAtMovementStart = Time.time;
		randomTime = minMaxTimeAtLocation.x +(periodOfPossibleMovement * Random.value);
		timeToSpendAtLocation = timeAtMovementStart + randomTime;
	}

	public void chooseNewLocation(){
		int lengthOfListOfLocationMarkers = listOfLocationMarkers.Length
		Random rnd = Random.Range (0, ((listOfLocationMarkers.Length) - 1));
		//int r = rnd.Range  listOfLocationMarkers.Count;
		gameObject.transform = listOfLocationMarkers[rnd].GetComponent(transform);
	}
}
