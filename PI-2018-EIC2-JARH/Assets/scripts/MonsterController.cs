using MathNet.Numerics.Distributions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

    public GameObject monster;
    public GameObject background;
    double timeToNextMonster;
    public String typeOfScenario;
    GenerateRandoms.Cenarios cenario;

  

    // Use this for initialization
    void Start () {
        monster.SetActive(false);
        timeToNextMonster = cosine(7, 11);
        cenario = GenerateRandoms.cenarioSelecionado;

        

    }

    // Update is called once per frame
    void Update () {
        timeToNextMonster -= Time.deltaTime;
       

        if (timeToNextMonster < 0)
        {
            monster.SetActive(true);
            timeToNextMonster = cosine(7, 11);

            double[] probs = new double[4];
            probs[0] = 0.4;
            probs[1] = 0.3;
            probs[2] = 0.2;
            probs[3] = 0.1;
            int typeOfMonster = Categorical.Sample(probs);

            Camera cam = Camera.main;
            float height = 2f * cam.orthographicSize;
            float width = height * cam.aspect;

            monster.transform.position = new Vector3(cam.transform.position.x + 5, transform.position.y, transform.position.z);

            if (cenario == GenerateRandoms.Cenarios.Deserto)                                //deviamos alterar os nomes dos monstros para nao haver tanto if e apenas substituir por "monstro" + 1, etc
            {
                if (typeOfMonster == 0)
                {
                    monster.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("inimigos/cobra_azul ");
                    // healthbar.SetSize(2, 3);
                }
                if (typeOfMonster == 1)
                {

                    monster.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("inimigos/cobra_azul");
                    // healthbar.SetSize(2, 3);
                }
                if (typeOfMonster == 2)
                {
                    monster.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("inimigos/cobra_azul");
                    // healthbar.SetSize(2, 3);
                }
                if (typeOfMonster == 3)
                {
                    monster.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("inimigos/cobra_azul");
                    //healthbar.SetSize(2, 3);
                }
            }
             else if (cenario== GenerateRandoms.Cenarios.Floresta)
            {

                if (typeOfMonster == 0)
                {
                    monster.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("inimigos/cobra_azul");
                    // healthbar.SetSize(2, 3);
                }
                if (typeOfMonster == 1)
                {

                    monster.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("inimigos/cobra_azul");
                    // healthbar.SetSize(2, 3);
                }
                if (typeOfMonster == 2)
                {
                    monster.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("inimigos/cobra_azul");
                    // healthbar.SetSize(2, 3);
                }
                if (typeOfMonster == 3)
                {
                    monster.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("inimigos/cobra_azul");
                    //healthbar.SetSize(2, 3);
                }
            }
            else if (cenario == GenerateRandoms.Cenarios.Gelado)
            {
                if (typeOfMonster == 0)
                {
                    monster.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("inimigos/cobra_azul");
                    // healthbar.SetSize(2, 3);
                }
                if (typeOfMonster == 1)
                {

                    monster.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("inimigos/cobra_azul");
                    // healthbar.SetSize(2, 3);
                }
                if (typeOfMonster == 2)
                {
                    monster.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("inimigos/cobra_azul");
                    // healthbar.SetSize(2, 3);
                }
                if (typeOfMonster == 3)
                {
                    monster.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("inimigos/cobra_azul");
                    //healthbar.SetSize(2, 3);
                }
            }
            else if (cenario == GenerateRandoms.Cenarios.Noturno)
            {
                if (typeOfMonster == 0)
                {
                    monster.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("inimigos/cobra_azul");
                }
                if (typeOfMonster == 1)
                {

                    monster.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("inimigos/cobra_azul");
                    // healthbar.SetSize(2, 3);
                }
                if (typeOfMonster == 2)
                {
                    monster.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("inimigos/cobra_azul");
                    // healthbar.SetSize(2, 3);
                }
                if (typeOfMonster == 3)
                {
                    monster.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("inimigos/cobra_azul");
                    //healthbar.SetSize(2, 3);
                }
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
    

