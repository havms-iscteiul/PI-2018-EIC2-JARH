using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MathNet.Numerics.Distributions;

public class GenerateRandoms : MonoBehaviour {
    public enum Cenarios
    {
        Deserto = 1,
        Floresta = 2,
        Gelado = 3,
        Noturno = 4
    }

    public static Cenarios cenarioSelecionado;

    public GameObject bg;
    public GameObject tille;
    public Sprite deserto;
    public Sprite noturno;
    public Sprite gelado;
    public Sprite floresta;
    
    // Use this for initialization
    void Start () {
        cenarioSelecionado = (Cenarios)System.Enum.GetValues(typeof(Cenarios)).GetValue(DiscreteUniform.Sample(0, 3));
        if (cenarioSelecionado==Cenarios.Deserto){
            bg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Backgrounds/Deserto");
            tille.GetComponent<SpriteRenderer>().sprite = deserto;
        }
        if (cenarioSelecionado == Cenarios.Noturno){
            bg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Backgrounds/Noturno");
            tille.GetComponent<SpriteRenderer>().sprite = noturno;
        }
        if (cenarioSelecionado == Cenarios.Gelado){
            bg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Backgrounds/Gelado");
            tille.GetComponent<SpriteRenderer>().sprite = gelado;
        }
        if (cenarioSelecionado == Cenarios.Floresta){
            bg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Backgrounds/Floresta");
            tille.GetComponent<SpriteRenderer>().sprite = floresta;
        }
    }

    public void regenerate()
    {
        cenarioSelecionado = (Cenarios)System.Enum.GetValues(typeof(Cenarios)).GetValue(DiscreteUniform.Sample(0, 3));
    }
}
