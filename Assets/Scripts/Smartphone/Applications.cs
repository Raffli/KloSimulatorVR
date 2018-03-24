using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Applications : MonoBehaviour {

	public GameObject homeScreen;
	public GameObject finderApp;
	public Finder finder;
	public GameObject poopFallerApp;
	public GameObject yourVideoApp;
	public GameObject telephoneApp;
	
	// Update is called once per frame
	void Update () {
		float moveX = Input.GetAxis ("Horizontal");
		float moveY = Input.GetAxis ("Vertical");
		if (moveY < 0) {
			Debug.Log ("DOWN");
		} else if (moveY > 0) {
			finderApp.SetActive (true);
			finder.StartApplication ();
			homeScreen.SetActive (false);
		} else if (moveX < 0) {
			Debug.Log ("LEFT");
		} else if (moveX > 0) {
			Debug.Log ("RIGHT");
		}
	}
}
