using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpuelbaresVerhalten : MonoBehaviour {

    public Transform toiletWaterCenterTrans;
    public bool insideWater;
    public bool isFlushing;
    public float rotationSpeed;
    public float dragIncreaseInsideWater;

    private Vector3 nextPosition;
    private float rotationStep = 12f;           // In degrees
    private IEnumerator coroutine;

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.name);
        if (col.name.Equals(toiletWaterCenterTrans.name))
        {
            coroutine = FlushLikeArchimedes(col.GetComponents<Collider>()[1]);
            insideWater = true;
            GetComponent<Rigidbody>().drag *= dragIncreaseInsideWater;
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (insideWater && isFlushing)
        {
            Debug.Log("Started Coroutine");
            StartCoroutine(coroutine);
        }
    }

    IEnumerator FlushLikeArchimedes(Collider waterBottom)
    {
        this.transform.parent = toiletWaterCenterTrans;
        while(isFlushing)
        {
            yield return null;
            nextPosition = Quaternion.AngleAxis(rotationStep, Vector3.up) * transform.localPosition;
            float radius = (toiletWaterCenterTrans.position - transform.position).magnitude;
            GetComponent<Rigidbody>().velocity = (nextPosition - transform.localPosition) * rotationSpeed * Time.deltaTime;
            
        }
        waterBottom.enabled = false;
        yield return new WaitForSeconds(1f);
        waterBottom.enabled = true;
    }

}
