﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KloSpülungsSeil : MonoBehaviour {

    internal Rigidbody RBody;
    internal void Start()
    {


        this.gameObject.AddComponent<Rigidbody>();
        this.RBody = this.gameObject.GetComponent<Rigidbody>();
        this.RBody.isKinematic = true;
        int childCount = this.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform t = this.transform.GetChild(i);

            t.gameObject.AddComponent<HingeJoint>();
            t.gameObject.AddComponent<Rigidbody>();
            HingeJoint hinge = t.gameObject.GetComponent<HingeJoint>();
            hinge.connectedBody = i == 0 ? this.RBody : this.transform.GetChild(i - 1).GetComponent<Rigidbody>();

            hinge.useSpring = true;
            hinge.enableCollision = true;
        }
    }
}
