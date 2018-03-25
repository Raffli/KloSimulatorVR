using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class Flusher : MonoBehaviour {

    public GameObject toiletteWater;
    private Vector3 lastHandProjected;

    private bool driving = false;

    [Tooltip("If true, the drive will stay manipulating as long as the button is held down, if false, it will stop if the controller moves out of the collider")]
    public bool hoverLock = false;

    private Vector3 worldPlaneNormal = new Vector3(1.0f, 0.0f, 0.0f);

    Valve.VR.InteractionSystem.Hand handHoverLocked = null;

    private void Start()
    {
        toiletteWater = GameObject.Find("flush_water_trigger");
    }

    public void initFlush()
    {
        toiletteWater.GetComponent<FlushingWater>().flush();
    }

    private void Update()
    {
        
    }


}
