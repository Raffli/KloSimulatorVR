using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finder : MonoBehaviour {

	public GameObject applications;
	public GameObject profilePanel;
	public GameObject welcomePanel;
	public GameObject endPanel;
	public GameObject getProButton;
	public GameObject broke;
	public Image profilePicture;
	public Text nameAndAge;
	public Text description;
	public GameObject liked;
	public GameObject disliked;
	public AudioClip click;
	public AudioSource audioSource;
	public Sprite [] profilePictures;
	public string [] namesAndAges;
	public string [] descriptions;
	private int currentProfile;
	private bool profilesActive;


	void Update () {

        bool left = Input.GetKeyDown(KeyCode.JoystickButton8);
        bool down = Input.GetKeyDown(KeyCode.JoystickButton2);

        if (profilesActive && left) {
            float moveX = Input.GetAxis("Horizontal");
            if (moveX < 0) {
                audioSource.Play();
                ShowDislikedSprite();
            }
			else if (moveX > 0) {
				audioSource.Play ();
				ShowLikedSprite ();
			}
		}

		if (down) {
			audioSource.Play ();
			applications.SetActive (true);
            applications.GetComponent<Applications>().SetAc(true);

            this.gameObject.SetActive (false);
		}

		if (endPanel.activeSelf) {
			if (down) {
                if (!broke.active)
                {
                    audioSource.Play();
                    getProButton.SetActive(false);
                    broke.SetActive(true);
                }
                else {
                    audioSource.Play();
                    applications.SetActive(true);
                    applications.GetComponent<Applications>().SetAc(true);

                    this.gameObject.SetActive(false);
                }

			}
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
		audioSource.clip = click;
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
