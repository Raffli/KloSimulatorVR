using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flusher : MonoBehaviour {

    public GameObject toiletteWater;

    public void initFlush()
    {
        toiletteWater.GetComponent<FlushingWater>().flush();
    }
}
