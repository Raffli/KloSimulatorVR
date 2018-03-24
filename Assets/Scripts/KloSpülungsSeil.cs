using System.Collections;
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
            t.GetComponent<BoxCollider>().enabled = false;
            if (i == childCount - 1) {
                t.localPosition = new Vector3(0, - (i/9f) - 0.1f, 0);
            }
            else
                t.localPosition = new Vector3(0,- (i/9f),0);

            Debug.Log(t.localPosition.y);
            t.gameObject.AddComponent<HingeJoint>();
            HingeJoint hinge = t.gameObject.GetComponent<HingeJoint>();
            hinge.connectedBody = i == 0 ? this.RBody : this.transform.GetChild(i - 1).GetComponent<Rigidbody>();
            
            //hinge.useSpring = true;
            hinge.enableCollision = true;
            t.GetComponent<BoxCollider>().enabled = true;

        }
    }
}
