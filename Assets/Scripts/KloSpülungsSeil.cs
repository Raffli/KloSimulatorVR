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
        GameObject lastTemp = this.transform.GetChild(0).transform.gameObject;
        for (float i = 0; i < 22; i++)
        {
            GameObject temp;
            if (i == 21)
            {
                temp = Instantiate(handle, new Vector3(0,0, 0), Quaternion.identity);
                temp.transform.parent = lastTemp.transform;
                temp.transform.localScale = new Vector3(1, 1, 1);
                temp.transform.localPosition = new Vector3(0, - 1.4f, 0);

            }
            else {
                temp = Instantiate(chainPart, new Vector3(0, 0, 0), Quaternion.identity);
                temp.transform.parent = lastTemp.transform;
                temp.transform.localScale = new Vector3(1, 1, 1);
                temp.transform.localPosition = new Vector3(0, -1.2f, 0);

            }

            temp.transform.gameObject.AddComponent<FixedJoint>();
            FixedJoint hinge = temp.gameObject.GetComponent<FixedJoint>();
            hinge.connectedBody = i == 0 ? this.transform.GetChild(0).GetComponent<Rigidbody>() : lastTemp.GetComponent<Rigidbody>();
            hinge.massScale = 1.2f;
            hinge.enableCollision = true;
            //hinge.spring = 10;

            //temp.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            
            lastTemp = temp;
            temp = null;
        }
    }
}
