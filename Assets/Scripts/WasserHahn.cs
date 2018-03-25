using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasserHahn : MonoBehaviour
{

    public GameObject hahn;
    public GameObject wasser;
    private bool aktiv;

    private float bs = 100;

    public bool Aktiv
    {
        get
        {
            return aktiv;
        }

        set
        {
            aktiv = value;
            SetAktiv(aktiv);
            StartCoroutine(Counter());
        }
    }

    // Update is called once per frame
    void Update () {

        wasser.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, bs);
	 }

    public void SetAktiv(bool aktive)
    {
        if (!aktive)
        {
            hahn.GetComponent<ParticleSystem>().Stop();
        }
        else
        {
            hahn.GetComponent<ParticleSystem>().Play();
        }

    }

    private IEnumerator Counter()
    {
        if (Aktiv)
        {
            bs--;
        }
        else
        {
            bs++;
        }

        yield return new WaitForSeconds(0.1f);
        if (bs != 0 && bs != 100)
        {
            StartCoroutine(Counter());
        }
    }
}
