using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour {
	GameObject characterCube;

	public int lastLocation = -1;

	public float smoothing = 7f;
	public float timeAtArriving = 0;
	public float timeToSpendAtLocation = 5f;

	public float randomTime = 0f;
	public Vector2 minMaxTimeAtLocation = new Vector2 (5f, 15f);
	private float periodOfPossibleMovement;

	public Vector3 startingLocation;

	public GameObject[] listOfLocationMarkers;

	public Vector3 lockedStartingLocation = new Vector3(-2.71f, 6.5f, 460.5f);

	void Start () {
		listOfLocationMarkers = GameObject.FindGameObjectsWithTag("positionMarker");
		periodOfPossibleMovement = minMaxTimeAtLocation.y - minMaxTimeAtLocation.x;
		StartCoroutine(timerCheck(timeToSpendAtLocation));
	}
		
	IEnumerator timerCheck (float timeToCheck) {
		while (timeToCheck > Time.time) {
			yield return null;
		}
		StopCoroutine("chooseNewLocation");
		StartCoroutine("chooseNewLocation");
		yield return null;
	}
		

	IEnumerator chooseNewLocation(){
		int lengthOfListOfLocationMarkers = listOfLocationMarkers.Length;
		int rnd = Random.Range (0, (lengthOfListOfLocationMarkers));
		while (rnd == lastLocation) {
			rnd = Random.Range (0, (lengthOfListOfLocationMarkers));
		}
		lastLocation = rnd;
		Vector3 targetPosition = listOfLocationMarkers[rnd].GetComponent<Transform>().position;
		//Debug.Log(rnd);
		while(Vector3.Distance(transform.position, targetPosition) > 0.01f){
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPosition, smoothing *Time.deltaTime);
			yield return null;
		}

		timeAtArriving = Time.time;
		randomTime = minMaxTimeAtLocation.x +(periodOfPossibleMovement * Random.value);
		timeToSpendAtLocation = timeAtArriving + randomTime;
		StopCoroutine("timerCheck");
		StartCoroutine(timerCheck(timeToSpendAtLocation));
		yield return null;
	}
		
}
