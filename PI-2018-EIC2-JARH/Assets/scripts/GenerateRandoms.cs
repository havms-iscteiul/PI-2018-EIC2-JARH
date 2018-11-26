using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MathNet.Numerics.Distributions;

public class GenerateRandoms : MonoBehaviour {

    private Cenarios cenarioSelecionado;

    public GameObject bg;
    //public GameObject tille;
    
    // Use this for initialization
    void Start () {
        //tille.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Tilles/spitesheet_ground_23");
        cenarioSelecionado = (Cenarios)System.Enum.GetValues(typeof(Cenarios)).GetValue(DiscreteUniform.Sample(0, 3));
        if(cenarioSelecionado==Cenarios.Deserto){
            bg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Backgrounds/Deserto");
            
        }
        if (cenarioSelecionado == Cenarios.Noturno){
            bg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Backgrounds/Noturno");
        }
        if (cenarioSelecionado == Cenarios.Gelado){
            bg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Backgrounds/Gelado");
        }
        if (cenarioSelecionado == Cenarios.Floresta){
            bg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Backgrounds/Floresta");
        }
    }
	
	// Update is called once per frame
	void Update () {
    }

    public enum Cenarios
    {
        Deserto = 1,
        Floresta = 2,
        Gelado = 3,
        Noturno = 4
    }
}
