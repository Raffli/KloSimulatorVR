using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlushingWater : MonoBehaviour {

    public bool insideWater;
    public bool isFlushing;
    public float rotationSpeed;
    public float dragIncreaseInsideWater;

    private List<Collider> colliders;
    private IEnumerator flushRoutine;
    private Vector3 nextPosition;
    private float rotationStep = 12f;           // In degrees

    public void flush()
    {
        foreach(Collider col in colliders)
        {
            StartCoroutine(FlushLikeArchimedes(col.transform));
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.name);
        if (col.name.Equals("flushable"))
        {
            colliders.Add(col);
            col.GetComponent<Rigidbody>().drag *= dragIncreaseInsideWater;
        }
    }

    IEnumerator FlushLikeArchimedes(Transform objTransInWater)
    {
        objTransInWater.parent = this.transform;
        while (isFlushing)
        {
            yield return null;
            nextPosition = Quaternion.AngleAxis(rotationStep, Vector3.up) * transform.localPosition;
            float radius = (objTransInWater.position - transform.position).magnitude;
            GetComponent<Rigidbody>().velocity = (nextPosition - transform.localPosition) * rotationSpeed * Time.deltaTime;

        }
        yield return PassThroughFlushable(GetComponent<Collider>());
    }

    IEnumerator PassThroughFlushable(Collider waterBottom)
    {
        waterBottom.enabled = false;
        Debug.Log(waterBottom);
        yield return new WaitForSeconds(1f);
        waterBottom.enabled = true;
        Debug.Log(waterBottom.enabled);
        yield return null;
    }
}
