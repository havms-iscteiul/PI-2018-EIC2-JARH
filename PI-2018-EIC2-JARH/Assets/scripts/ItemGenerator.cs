using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathNet.Numerics.Distributions;

public class ItemGenerator : MonoBehaviour {

    public GameObject item;
    public HealthBar healthbar;
    double timeToNextItem;




    // Use this for initialization
    void Start () {
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
            
            item.transform.position=new Vector3(cam.transform.position.x+4, transform.position.y, transform.position.z);

            if (typeOfItem == 0)
            {
                item.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Itens/potion_1");
               // healthbar.SetSize(2, 3);
            }
            if (typeOfItem == 1)
            {
               
                item.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Itens/pill");
               // healthbar.SetSize(2, 3);
            }
            if (typeOfItem == 2)
            {
                item.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Itens/pills");
               // healthbar.SetSize(2, 3);
            }
            if (typeOfItem == 3)
            {
                item.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Itens/backpack-1");
                //healthbar.SetSize(2, 3);
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
