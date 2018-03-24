using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finder : MonoBehaviour {

	public GameObject profilePanel;
	public GameObject welcomePanel;
	public Image profilePicture;
	public Text nameAndAge;
	public Text description;
	public Image like;
	public Image dislike;
	public Sprite [] profilePictures;
	public string [] namesAndAges;
	public string [] descriptions;

	private bool profilesActive;


	void Update () {
		if (profilesActive) {
			float moveX = Input.GetAxis ("Horizontal");
			if (moveX < 0) {
				Debug.Log ("dislike");
			} else if (moveX > 0) {
				Debug.Log ("like");
			}
		}
	}

	public void StartApplication () {
		profilesActive = false;
		welcomePanel.SetActive (true);
		StartCoroutine (WaitForMatches ());
	}

	IEnumerator WaitForMatches () {
		yield return new WaitForSeconds (5f);
		profilePanel.SetActive (true);
		profilesActive = true;
		welcomePanel.SetActive (false);
	}
}
