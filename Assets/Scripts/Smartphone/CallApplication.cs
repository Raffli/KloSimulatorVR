using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class CallApplication : MonoBehaviour {

	public GameObject applications;
	public Text contactName;
	public Text callDuration;
	public GameObject callingPanel;
	public AudioClip freizeichen;
	public AudioClip telefonatMama;
	public AudioSource audioSource;

	private int minutes = 0;
	private float seconds = 0;
	private bool momAlreadyCalled = false;
	private bool onCall = false;
	private string secondsText = "";
	private string minutesText = "";

    private int counter = 100;

	// Update is called once per frame
	void Update () {
        counter--;
        if (counter <= 0)
        {
            bool left = Input.GetKeyDown(KeyCode.JoystickButton8);
            bool down = Input.GetKeyDown(KeyCode.JoystickButton2);

            if (!onCall)
            {
                if (left)
                {
                    float moveX = Input.GetAxis("Horizontal");
                    if (moveX < 0)
                    {
                        contactName.text = "Mama (Handy)";
                    }
                    else if (moveX > 0)
                    {
                        contactName.text = "Mama (zu Hause)";
                    }
                }
                CallMom();
            }
            else
            {
                if (down)
                {
                    EndCall();
                }
            }


            if (down)
            {
                applications.SetActive(true);
                applications.GetComponent<Applications>().SetAc(true);
                this.gameObject.SetActive(false);
                counter = 100;

            }

            if (onCall)
            {
                seconds += Time.deltaTime;
                if (seconds > 59)
                {
                    minutes++;
                    seconds = 0f;
                }
                if (seconds < 10)
                {
                    secondsText = ":0" + (int)seconds;
                }
                else
                {
                    secondsText = ":" + (int)seconds;
                }

                if (minutes < 10)
                {
                    minutesText = "0" + minutes;
                }
                else
                {
                    minutesText = "" + minutes;
                }
                callDuration.text = minutesText + secondsText;

                if (!audioSource.isPlaying)
                {
                    EndCall();
                }
            }

        }
	}

	void CallMom () {
		callingPanel.SetActive (true);
		onCall = true;
		if (momAlreadyCalled) {
			audioSource.clip = freizeichen;
			audioSource.loop = true;
		} else {
			audioSource.clip = telefonatMama;
			momAlreadyCalled = true;
		}
		audioSource.Play ();
	}

	void EndCall () {
		callingPanel.SetActive (false);
		onCall = false;
		minutes = 0;
		seconds = 0;
		audioSource.Stop ();
	}
}
