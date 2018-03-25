using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlushableBehaviour : MonoBehaviour
{

    public float approachSpeed;
    public float rotationSpeed;
    public Transform toiletCenter;
    public float aasd;

    private IEnumerator flush;

    void Update()
    {
        if (transform.position.magnitude > toiletCenter.position.magnitude)
        {
            //FlushLikeArchimedis();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.name);
        if (col.gameObject.tag.Equals("toilet"))
        {
            flush = FlushLikeArchimedis();
            Destroy(GetComponent<Rigidbody>());
            StartCoroutine("FlushLikeArchimedis");
        }
    }

    IEnumerator FlushLikeArchimedis()
    {
        while(transform.position.magnitude > toiletCenter.position.magnitude)
        {
            transform.LookAt(toiletCenter);
            transform.Translate((toiletCenter.position.z - transform.position.z > 0 ?
                toiletCenter.position - transform.position : transform.position - toiletCenter.position) * Time.deltaTime * approachSpeed);
            transform.RotateAround(toiletCenter.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
        return null;
    }
}
