using MathNet.Numerics.Distributions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {
    public HealthBar healthbar;
    public GameObject monster;
    double timeToNextMonster;
    //default
    int typeOfMonster = 0;
    GenerateRandoms.Cenarios cenario;

    // Use this for initialization
    void Start () {
        monster.SetActive(false);
        healthbar = Instantiate(healthbar, transform.position, transform.rotation);
        healthbar.gameObject.SetActive(false);
        timeToNextMonster = cosine(7, 11);
        cenario = GenerateRandoms.cenarioSelecionado;
    }

    // Update is called once per frame
    void Update () {
        timeToNextMonster -= Time.deltaTime;

        if (timeToNextMonster < 0 && !monster.active)
        {
            timeToNextMonster = cosine(7, 11);

            double[] probs = new double[4];
            probs[0] = 0.4;
            probs[1] = 0.3;
            probs[2] = 0.2;
            probs[3] = 0.1;
            typeOfMonster = Categorical.Sample(probs);

            monster.SetActive(true);
            healthbar.gameObject.SetActive(true);
            monster.transform.position = new Vector3(Camera.main.transform.position.x + 5, transform.position.y, transform.position.z);
            healthbar.transform.position = new Vector3(Camera.main.transform.position.x + 5, (transform.position.y + 0.5f), transform.position.z);
            healthbar.SetLife(healthbar.getMaxLife());

            monster.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("inimigos/" + cenario.ToString() + "/monstro" + typeOfMonster);
        }
    }

    double cosine(double xMin, double xMax)
    {
        double a = 0.5 * (xMin + xMax); // location parameter
        double b = (xMax - xMin) / Math.PI; // scale parameter
        return a + b * Math.Asin(ContinuousUniform.Sample(-1, 1));
    }
}