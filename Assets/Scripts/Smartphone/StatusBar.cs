using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour {

	public float batteryLeft = 0.71f; 
	public int hours;
	public int minutes;
	private float seconds = 50f;

	public Text timeText;
	public Image batteryBar;
	public GameObject messagePopup;
	public Text message;
	public GameObject smartphoneCanvas;
	public AudioClip closeHandy;
	public AudioSource audioSource;
	
	// Update is called once per frame
	void Update () {
		seconds += Time.deltaTime * 100;
		if (seconds > 59) {
			minutes++;
			seconds = 0f;
			if (minutes > 59) {
				hours++;
				minutes = 0;
				if (hours > 23) {
					hours = 0;
				}
			}
			if (minutes < 10) {
				timeText.text = hours + ":0" + minutes;
			} else {
				timeText.text = hours + ":" + minutes;
			}
			batteryLeft -= 0.01f;
			if (batteryLeft < 0.01f) {
				audioSource.Stop ();
				audioSource.loop = false;
				messagePopup.SetActive (true);
				message.text = "Battery is dead!";
				StartCoroutine (WaitForShutdown ());

			}
			batteryBar.fillAmount = batteryLeft;
		}
	}

	IEnumerator WaitForShutdown () {
		yield return new WaitForSeconds (3f);
		audioSource.clip = closeHandy;
		audioSource.Play ();
		smartphoneCanvas.SetActive (false);
	}
}
