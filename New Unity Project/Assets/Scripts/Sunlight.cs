using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunlight : MonoBehaviour {
	public Transform targetRotation;
	public Transform targetStartRotation;
	public float totalRotationTimeMinutes = 10f;
	public float startingAngle = -90f;
	private float timeCount = 0f;
	void Start () {
		//gameObject.transform.localRotation.Set(startingAngle, 0f,0f, 1);
		targetStartRotation = gameObject.transform;
		targetRotation = gameObject.transform;
		StopCoroutine("sunUpdate");
		Debug.Log (" STARTANGLE! x "+gameObject.transform.localRotation.x+" y "+gameObject.transform.localRotation.y+" z "+gameObject.transform.localRotation.z+" w "+gameObject.transform.localRotation.w);
		StartCoroutine("sunUpdate");
	}

//	IEnumerator cusStartUp(){
		//StopCoroutine("cusStartUp");
		//StopCoroutine("startRotation");
		//StartCoroutine("startRotation");
		//yield return null;
//	}
	IEnumerator sunUpdate(){
	//IEnumerator startRotation(){
	// Update is called once per frame
		while(targetRotation.localEulerAngles.x < 630f){
			Debug.Log (" ! "+gameObject.transform.eulerAngles.x);
			//gameObject.transform.eulerAngles = Vector3.Slerp(gameObject.transform.eulerAngles, targetRotation, (smoothing *Time.deltaTime));*Time.deltaTime
			//targetRotation = new Vector3( (targetRotation.x + (360f/(totalRotationTimeMinutes)/60)*Time.deltaTime), 0f, 0f);
			targetRotation.localRotation = Quaternion.Slerp(targetRotation.localRotation, targetStartRotation.localRotation, 1f);
			timeCount = timeCount + Time.deltaTime;
			gameObject.transform.localRotation = targetRotation.localRotation;
			yield return null;
		}
		//Debug.Log ("OUT OF LOOP");
		//targetRotation = Vector3.zero;
		targetRotation = targetStartRotation;
		gameObject.transform.localRotation = targetStartRotation.localRotation;
		StopCoroutine("sunUpdate");
		StartCoroutine("sunUpdate");
		yield return null;
	}
}
