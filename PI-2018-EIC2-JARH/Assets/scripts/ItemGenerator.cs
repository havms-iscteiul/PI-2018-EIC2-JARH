using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathNet.Numerics.Distributions;

public class ItemGenerator : MonoBehaviour {

    public GameObject item;
    double timeToNextItem;




    // Use this for initialization
    void Start () {
        item.SetActive(false);
        timeToNextItem = cosine(7, 11);

        //Instantiate(item, transform.position, transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
        timeToNextItem -= Time.deltaTime;
        if (timeToNextItem < 0)
        {
            timeToNextItem= cosine(7, 11);
            double[] probs = new double[4];
            probs[0] = 0.4;
            probs[1] = 0.3;
            probs[2] = 0.2;
            probs[3] = 0.1;
            int typeOfItem = Categorical.Sample(probs);
            Camera cam = Camera.main;
            float height = 2f * cam.orthographicSize;
            float width = height * cam.aspect;
            item.SetActive(true);
            item.transform.position=new Vector3(cam.transform.position.x+4, transform.position.y, transform.position.z);
    
            if (typeOfItem == 0)
            {
                item.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Itens/potion");
              
            }
            if (typeOfItem == 1)
            {
               
                item.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Itens/pill");
            }
            if (typeOfItem == 2)
            {
                item.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Itens/medicine");
            }
            if (typeOfItem == 3)
            {
                item.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Itens/backpack");
            }
        }
    }
    double cosine(double xMin, double xMax)
    {
        double a = 0.5 * (xMin + xMax); // location parameter
        double b = (xMax - xMin) / Math.PI; // scale parameter
        return a + b * Math.Asin(ContinuousUniform.Sample(-1, 1));
    }
}
