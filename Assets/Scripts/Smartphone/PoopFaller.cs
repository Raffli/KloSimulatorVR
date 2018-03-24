using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoopFaller : MonoBehaviour {

    // Use this for initialization
    public Sprite abflussRechts;
    public Sprite abflussLinks;
    public Sprite abflussMitte;

    public Image gameScreen;
    public GameObject wurstiObject;
    public GameObject background;
    public Image tile1;
    public Image tile2;

    public GameObject homeScreen;

    public GameObject gameOverScreen;
	public AudioClip music;
	public AudioClip poopDead;
	public AudioSource audioSource;

    private int position = 1;
    private int activeTile1 = 1;
    private int activeTile2 = 1;

    private bool play;



    public void StartApplication()
    {
        NewTiles();
        play = true;
        background.SetActive(true);
		audioSource.clip = music;
		audioSource.loop = true;
    }

    // Update is called once per frame
    void Update () {
        if (play) {
            WurstiMove();
            CheckDeath();
            CheckNewLevel();
        }
    }

    private void CheckNewLevel() {
        if (wurstiObject.transform.localPosition.y < -0.8f) {
            wurstiObject.transform.localPosition = new Vector3(wurstiObject.transform.localPosition.x, 0.8f, 0);
            NewTiles();
        }
    }

    private void NewTiles() {
        activeTile1 = Random.RandomRange(0, 3);
        activeTile2 = Random.RandomRange(0, 3);
        if (activeTile1 == 0) {
            tile1.sprite = abflussLinks;
        } else if (activeTile1 == 1) {
            tile1.sprite = abflussMitte;

        }
        else {
            tile1.sprite = abflussRechts;

        }

        if (activeTile2 == 0)
        {
            tile2.sprite = abflussLinks;
        }
        else if (activeTile2 == 1)
        {
            tile2.sprite = abflussMitte;

        }
        else
        {
            tile2.sprite = abflussRechts;

        }



    }

    private void CheckDeath() {
        if (wurstiObject.transform.localPosition.y <= 0.45f && wurstiObject.transform.localPosition.y >= 0.1f)
        {
            if (activeTile1 != position)
            {
                StartGameOver();
            }
        }
        else if (wurstiObject.transform.localPosition.y <= -0.4f && wurstiObject.transform.localPosition.y >= - 0.75f) {
            if (activeTile2 != position) {
                StartGameOver();
            }
        }
    }


    IEnumerator DeathTime()
    {
        yield return new WaitForSeconds(4);
        Die();
    }

    private void StartGameOver() {
		audioSource.Stop ();
		audioSource.loop = false;
		audioSource.clip = poopDead;
		audioSource.Play ();
        gameOverScreen.SetActive(true);
        play = false;
        StartCoroutine(DeathTime());
    }

    private void Die() {
        transform.GetChild(0).transform.gameObject.SetActive(false);
        wurstiObject.transform.localPosition = new Vector3(-0.02f, 0.8f, 0);
        position = 1;
        homeScreen.SetActive(true);
        gameOverScreen.SetActive(false);
    }

    private void WurstiMove() {
        bool pressed = Input.GetButtonDown("Horizontal");
        if (pressed)
        {
            float moveX = Input.GetAxis("Horizontal");
            if (moveX < 0)
            {
                position--;
                if (position <= 0)
                {
                    position = 0;
                }
            }
            else if (moveX > 0)
            {
                position++;
                if (position >= 2)
                {
                    position = 2;
                }
            }

            if (position == 0)
            {
                wurstiObject.transform.localPosition = new Vector3(-0.3f, wurstiObject.transform.localPosition.y, 0);
            }
            else if (position == 1)
            {
                wurstiObject.transform.localPosition = new Vector3(-0.02f, wurstiObject.transform.localPosition.y, 0);
            }
            else
            {
                wurstiObject.transform.localPosition = new Vector3(0.3f, wurstiObject.transform.localPosition.y, 0);

            }
        }
        wurstiObject.transform.localPosition = new Vector3(wurstiObject.transform.localPosition.x, wurstiObject.transform.localPosition.y - 0.0035f, 0);


    }
}
