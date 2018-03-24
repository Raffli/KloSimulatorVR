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
	
	// Update is called once per frame
	void Update () {
		float moveX = Input.GetAxis ("Horizontal");
		float moveY = Input.GetAxis ("Vertical");
		if (moveY < 0) {
			Debug.Log ("DOWN");
		} else if (moveY > 0) {
			
		} else if (moveX < 0) {
			finderApp.SetActive (true);
			finder.StartApplication ();
			homeScreen.SetActive (false);
		} else if (moveX > 0) {
            poopFallerApp.SetActive(true);
            poopFaller.StartApplication();
            homeScreen.SetActive(false);

            Debug.Log ("RIGHT");
		}
	}
}
