using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finder : MonoBehaviour {

	public GameObject applications;
	public GameObject profilePanel;
	public GameObject welcomePanel;
	public GameObject endPanel;
	public Image profilePicture;
	public Text nameAndAge;
	public Text description;
	public GameObject liked;
	public GameObject disliked;
	public Sprite [] profilePictures;
	public string [] namesAndAges;
	public string [] descriptions;
	private int currentProfile;
	private bool profilesActive;


	void Update () {
		if (profilesActive && Input.GetButtonDown ("Horizontal")) {
			float moveX = Input.GetAxis ("Horizontal");
			if (moveX < 0) {
				ShowDislikedSprite ();
			} else if (moveX > 0) {
				ShowLikedSprite ();
			}
		}

		if (Input.GetButtonDown ("Cancel")) {
			applications.SetActive (true);
			this.gameObject.SetActive (false);
		}
	}

	private void ShowLikedSprite () {
		liked.SetActive (true);
		profilesActive = false;
		StartCoroutine (DisplaySpriteForThreeSeconds ());
	}

	private void ShowDislikedSprite () {
		disliked.SetActive (true);
		profilesActive = false;
		StartCoroutine (DisplaySpriteForThreeSeconds ());
	}

	private void ShowNextProfile () {
		currentProfile++;
		if (currentProfile < descriptions.Length) {
			profilePicture.sprite = profilePictures [currentProfile];
			nameAndAge.text = namesAndAges [currentProfile];
			description.text = descriptions [currentProfile];
			profilesActive = true;
		} else {
			profilePanel.SetActive (false);
			endPanel.SetActive (true);
		}
	}

	public void StartApplication () {
		if (currentProfile >= descriptions.Length) {
			endPanel.SetActive (true);
			return;
		}
		profilesActive = false;
		welcomePanel.SetActive (true);
		StartCoroutine (WaitForMatches ());
	}
		
	IEnumerator DisplaySpriteForThreeSeconds (){
		yield return new WaitForSeconds (3f);
		liked.SetActive (false);
		disliked.SetActive (false);
		ShowNextProfile ();
	}

	IEnumerator WaitForMatches () {
		yield return new WaitForSeconds (5f);
		profilePanel.SetActive (true);
		profilesActive = true;
		welcomePanel.SetActive (false);
	}
}
