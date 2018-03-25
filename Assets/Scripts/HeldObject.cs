using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HeldObject : MonoBehaviour
{
    [HideInInspector]
    public Controller parent;
    public bool playedSound;

    private void Update()
    {
        if(parent != null)
        {
            GetComponent<AudioSource>().Play();
            if(GetComponent<Flusher>() != null)
            {
                GetComponent<Flusher>().initFlush();
            }

            playedSound = true;

        } else
        {
            playedSound = false;
        }
    }
}
