using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MathNet.Numerics.Distributions;

public class Fight : MonoBehaviour {

    //public PlayableObject player;
    //public PlayableObject enemy;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        //calculo do sinal
        if (Input.GetKey(KeyCode.Space))
        {
            int armor = 10;
            int min_attack = 20;
            int max_attack = 40;
            int mode = (max_attack - armor <= min_attack ? min_attack : max_attack - armor);
            int damage = (int)Triangular.Sample(min_attack, max_attack, mode);
        }
        //calculo do inimigo que vai aparecer
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            double[] probs = new double[4];
            probs[0] = 0.4;
            probs[1] = 0.3;
            probs[2] = 0.2;
            probs[3] = 0.1;
            int enemyLvl = Categorical.Sample(probs);
        }
        //calculo do tempo entre cada inimigo
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            double timeToNextEnemy = cosine(3, 10);
        }
        //calculo da vida perdida do jogador
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            double lostLife = logarithmic(0, 1);
        }
    }

    double cosine(double xMin, double xMax)
    {
        double a = 0.5 * (xMin + xMax); // location parameter
        double b = (xMax - xMin) / Math.PI; // scale parameter
        return a + b * Math.Asin(ContinuousUniform.Sample(-1, 1));
    }

    private double logarithmic(double xMin, double xMax)
    {
        double a = 0.5 * (xMin + xMax); // location parameter
        double b = xMax - xMin; // scale parameter 
        return a + b * ContinuousUniform.Sample(0, 1) * ContinuousUniform.Sample(0, 1);
    }

}
