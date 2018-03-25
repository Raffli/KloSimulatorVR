using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Applications : MonoBehaviour {

	public GameObject homeScreen;
	public GameObject finderApp;
	public Finder finder;
	public GameObject poopFallerApp;
	public PoopFaller poopFaller;
	public GameObject telephoneApp;
	public CallApplication telephone;
	public AudioClip click;
	public AudioSource audioSource;

    public bool onHand;

	void OnEnable () {
		audioSource.clip = click;
	}
	
	// Update is called once per frame
	void Update () {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            if (moveY < 0)
            {
                telephoneApp.SetActive(true);
                homeScreen.SetActive(false);
                audioSource.Play();
            }
            else if (moveY > 0)
            {

            }
            else if (moveX < 0)
            {
                finderApp.SetActive(true);
                finder.StartApplication();
                homeScreen.SetActive(false);
                audioSource.Play();
            }
            else if (moveX > 0)
            {
                poopFallerApp.SetActive(true);
                poopFaller.StartApplication();
                homeScreen.SetActive(false);
                Debug.Log(homeScreen.active);
                audioSource.Play();
        }
	}
}
