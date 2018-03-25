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

    public bool aktive = true;

	void OnEnable () {
		audioSource.clip = click;
	}

    // Update is called once per frame
    void Update()
    {
        if (aktive)
        {
            bool left = Input.GetKeyDown(KeyCode.JoystickButton8);
            bool down = Input.GetKeyDown(KeyCode.JoystickButton2);

            if (left)
            {
                float moveX = Input.GetAxis("Horizontal");
                if (moveX < 0)
                {

                    finderApp.SetActive(true);
                    finder.StartApplication();
                    audioSource.Play();
                    aktive = false;
                    homeScreen.SetActive(false);
                }
                else if (moveX > 0)
                {
                    poopFallerApp.SetActive(true);
                    poopFaller.StartApplication();
                    audioSource.Play();
                    aktive = false;

                    homeScreen.SetActive(false);
                }
            }
            else if (down)
            {
                telephoneApp.SetActive(true);
                audioSource.Play();
                homeScreen.SetActive(false);
                aktive = false;
            }

        }
    }

    public void SetAc(bool ac) {
        aktive = ac;
    }
}
