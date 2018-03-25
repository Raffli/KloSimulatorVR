using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoDisco : MonoBehaviour
{

    public GameObject discoWall;
    public GameObject discoLight;
    

    //disco dude shadow party
    public GameObject dude;

    public bool dudeSpeaks;
    private float speed = 1;
    private Material discoMat;
    private Color discoColor;

    public Transform dudeStartPosition;
    public Transform dudeTargetPosition;



    void Awake()
    {
    }
	// Use this for initialization
	void Start () {

        discoMat = discoWall.GetComponent<Renderer>().material;
	    StartCoroutine(Example());
    }

    void Update()
    {
        if (dudeSpeaks && dude.gameObject.transform.position != dudeTargetPosition.position)
        {
            float step = speed * Time.deltaTime;
            dude.transform.position = Vector3.MoveTowards(dude.transform.position, dudeTargetPosition.position, step);
        }
        else if(!dudeSpeaks && dude.gameObject.transform.position != dudeStartPosition.position)
        {
            float step = speed * Time.deltaTime;
            dude.transform.position = Vector3.MoveTowards(dude.transform.position, dudeStartPosition.position, step);
        }
    }
	
	// Update is called once per frame


    private void GenerateColor()
    {
        float red = Random.Range(0.25f, 1);
        float green = Random.Range(0.25f, 1);
        float blue = Random.Range(0.25f, 1);
        discoColor = new Color(red, blue, green);

        discoLight.GetComponent<Light>().color = discoColor;
        discoMat.SetColor("_EmissionColor", discoColor);
        StartCoroutine(Example());
    }



    IEnumerator Example()
    {
            
        yield return new WaitForSeconds(1f);
        GenerateColor();
    }
}




