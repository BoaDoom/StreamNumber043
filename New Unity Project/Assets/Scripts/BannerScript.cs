using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BannerScript : MonoBehaviour {
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//
//  Simple Clock Script / Andre "AEG" Bürger / VIS-Games 2012
//
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
	public GameObject TwitchChatObject;
	public bool digital;
	public TextMesh currentTime;
    //-- set start time 00:00
    public int minutes = 0;
    public int hour = 0;
    
    //-- time speed factor
    public float clockSpeed = 1.0f;     // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster

    //-- internal vars
	Text timeTextText;

    int seconds;
//    float msecs;
	string text;
    GameObject pointerSeconds;
    GameObject pointerMinutes;
    GameObject pointerHours;

//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
void Start() 
{
		if (!digital) {
			pointerSeconds = transform.Find ("rotation_axis_pointer_seconds").gameObject;
			pointerMinutes = transform.Find ("rotation_axis_pointer_minutes").gameObject;
			pointerHours = transform.Find ("rotation_axis_pointer_hour").gameObject;
		}/*
		if (digital) {
			currentTime = transform.Find ("timeText").gameObject;
		}
		*/
//    msecs = 0.0f;
    seconds = 0;
}
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
void Update() 
{
		var date = System.DateTime.Now;
		//converts the above var to a readable string
		text = date.ToString("HH:mm:ss");

    //-- calculate time

//		msecs = System.DateTime.Now.Millisecond;
		seconds =  Mathf.RoundToInt(System.DateTime.Now.Second);
		minutes =  Mathf.RoundToInt(System.DateTime.Now.Minute);
		hour =  Mathf.RoundToInt(System.DateTime.Now.Hour);
		if (hour > 11) {
			hour -= 12;
		}
		//print(seconds +" "+minutes+" "+hour);
		/*
    if(msecs >= 1.0f)
    {
        msecs -= 1.0f;
        seconds++;
        if(seconds >= 60)
        {
            seconds = 0;
            minutes++;
            if(minutes > 60)
            {
                minutes = 0;
                hour++;
                if(hour >= 24)
                    hour = 0;
            }
        }
    }
    */


    //-- calculate pointer angles


    //-- draw pointers
		if (!digital) {
			float rotationSeconds = (360.0f / 60.0f)  * seconds;
			float rotationMinutes = (360.0f / 60.0f)  * minutes;
			float rotationHours   = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

			pointerSeconds.transform.localEulerAngles = new Vector3 (0.0f, 0.0f, rotationSeconds);
			pointerMinutes.transform.localEulerAngles = new Vector3 (0.0f, 0.0f, rotationMinutes);
			pointerHours.transform.localEulerAngles = new Vector3 (0.0f, 0.0f, rotationHours);
		}
		if (digital) {
			//threeDigitString = ;
			//tells the var to look for the precise moment you are at

			//prints it to inspector
			currentTime.text = text; 

			//currentTime.text = hour.ToString("D2") + " : " + minutes.ToString("D2") + " : " + seconds.ToString("D2");
		}

}
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
}
