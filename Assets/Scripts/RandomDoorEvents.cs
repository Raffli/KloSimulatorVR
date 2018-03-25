using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDoorEvents : MonoBehaviour {

	public AudioClip doorSound;
	public AudioClip[] personsKnocking;
	public AudioSource audioSource;
	public float minWait;
	public float maxWait;
    public DiscoDisco dudespeacks;

	private bool hasPlayed = false;
	private bool doorUsed = false;

	void OnEnable () {
		StartCoroutine (WaitForRandomSeconds ());
	}

	void Update () {
		if (!audioSource.isPlaying && hasPlayed) {
			if (doorUsed) {
				hasPlayed = false;
				doorUsed = false;
				StartCoroutine (WaitForRandomSeconds ());
			} else {
				PlayRandomPersonEvent ();
			}
		}
	}

	private void PlayDoorSound () {
		hasPlayed = true;
		audioSource.clip = doorSound;
		audioSource.Play ();
	}

	private void PlayRandomPersonEvent (){
		int randomEvent = Random.Range (0, personsKnocking.Length);
		audioSource.clip = personsKnocking[randomEvent];
		audioSource.Play ();
		doorUsed = true;
	}

	IEnumerator WaitForRandomSeconds () {
		float randomWaitTime = Random.Range (minWait, maxWait);
        dudespeacks.dudeSpeaks = false;
        yield return new WaitForSeconds (randomWaitTime);
        dudespeacks.dudeSpeaks = true;
        PlayDoorSound ();
	}

}
