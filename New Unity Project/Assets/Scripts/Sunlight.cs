using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunlight : MonoBehaviour {
	//public Transform targetRotation;
	//public Transform targetStartRotation;
	public float totalRotationHours = 1f;
	private float totalRotationSeconds;
	private bool timeGo = true;
	private float rotationPercentage = 0;

	public AnimationCurve seasonsCurve;
	public AnimationCurve yearCurve;

	private float sunNorthSouth;
	public float sunNorthSouthMaxCurve = 45f;
	//public float smoothing = 1;
	void Start () {
		totalRotationSeconds = totalRotationHours * 60 * 60;
		//sunNorthSouthAmp = new Vector2 ();
		StopCoroutine("sunUpdate");
		StartCoroutine("sunUpdate");
	}
		
	IEnumerator sunUpdate(){
	//IEnumerator startRotation(){
	// Update is called once per frame
		while(timeGo){
			rotationPercentage = (Time.deltaTime/totalRotationSeconds) + rotationPercentage;
			sunNorthSouth = seasonsCurve.Evaluate(rotationPercentage) * sunNorthSouthMaxCurve;
			//Debug.Log ("angle calced " + sunNorthSouth);
			gameObject.transform.eulerAngles = new Vector3((rotationPercentage*360), sunNorthSouth, 0f);		//360 being a full rotation of the sun

			yield return null;
		}
		Debug.Log ("OUT OF LOOP");
		StopCoroutine("sunUpdate");
		if (timeGo) {
			StartCoroutine ("sunUpdate");
			yield return null;
		} else {
			yield return null;
		}
	}
}
