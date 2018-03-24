using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KloSpülungsSeil : MonoBehaviour {

    public GameObject chainPart;
    public GameObject handle;
    public GameObject spawnPoint;

    internal Rigidbody RBody;

    internal void Start()
    {


        this.gameObject.AddComponent<Rigidbody>();
        this.RBody = this.gameObject.GetComponent<Rigidbody>();
        this.RBody.isKinematic = true;
        GameObject lastTemp = this.transform.gameObject;
        for (int i = 0; i < 22; i++)
        {
            GameObject temp;
            if (i == 22 - 1)
            {
                temp = Instantiate(handle, new Vector3(0,0, 0), Quaternion.identity);
                temp.transform.parent = lastTemp.transform;
                temp.transform.localPosition = new Vector3(0, -(i / 3f) - 0.2f, 0);

            }
            else {
                temp = Instantiate(chainPart, new Vector3(0, 0, 0), Quaternion.identity);
                temp.transform.parent = lastTemp.transform;
                temp.transform.localPosition = new Vector3(0, -(i / 3f), 0);
            }
            temp.GetComponent<BoxCollider>().enabled = false;

            temp.transform.gameObject.AddComponent<HingeJoint>();
            HingeJoint hinge = temp.gameObject.GetComponent<HingeJoint>();
            hinge.connectedBody = i == 0 ? this.RBody : lastTemp.GetComponent<Rigidbody>();
            hinge.massScale = 0.01f;
            //hinge.useSpring = true;
            hinge.enableCollision = true;
            temp.GetComponent<BoxCollider>().enabled = true;
            lastTemp = temp;
        }
    }
}
