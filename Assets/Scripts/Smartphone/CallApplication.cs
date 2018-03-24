using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallApplication : MonoBehaviour {

	public GameObject applications;
	public Text contactName;
	public Text callDuration;
	public GameObject callingPanel;

	private int minutes = 0;
	private float seconds = 0;
	private bool momAlreadyCalled;
	private bool onCall = false;
	private string secondsText = "";
	private string minutesText = "";

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Vertical")) {
			if (!onCall) {
				float moveY = Input.GetAxis ("Vertical");
				if (moveY < 0) {
					contactName.text = "Mama (Handy)";
				} else if (moveY > 0) {
					contactName.text = "Mama (zu Hause)";
				}
				CallMom ();
			} else {
				float moveY = Input.GetAxis ("Vertical");
				if (moveY < 0) {
					EndCall ();
				}
			}				
		}

		if (Input.GetButtonDown ("Cancel")) {
			applications.SetActive (true);
			this.gameObject.SetActive (false);
		}

		if (onCall) {
			seconds += Time.deltaTime;
			if (seconds > 59) {
				minutes++;
				seconds = 0f;
			}
			if (seconds < 10) {
				secondsText = ":0" + (int)seconds; 
			} else {
				secondsText = ":" + (int)seconds; 
			}

			if (minutes < 10) {
				minutesText = "0" + minutes;
			} else {
				minutesText = "" + minutes;
			}
			callDuration.text = minutesText + secondsText;
		}

	}

	void CallMom () {
		callingPanel.SetActive (true);
		onCall = true;
	}

	void EndCall () {
		callingPanel.SetActive (false);
		onCall = false;
		minutes = 0;
		seconds = 0;
	}
}
