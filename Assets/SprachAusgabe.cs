using UnityEngine;
using System.Collections;

public class SprachAusgabe : MonoBehaviour
{
    public AudioSource audioSource;
    private string words;


    void Play()
    {
    }

    public void SetWordsToSay(string words) {
        this.words = words;
        Play();
    } 


}