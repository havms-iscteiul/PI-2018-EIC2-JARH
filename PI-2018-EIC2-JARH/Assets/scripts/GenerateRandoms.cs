using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MathNet.Numerics.Distributions;

public class GenerateRandoms : MonoBehaviour {

    private Cenarios cenarioSelecionado;

    private GameObject plataform;
    
    // Use this for initialization
    void Start () {
        cenarioSelecionado = (Cenarios)System.Enum.GetValues(typeof(Cenarios)).GetValue(DiscreteUniform.Sample(0, 3));
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
