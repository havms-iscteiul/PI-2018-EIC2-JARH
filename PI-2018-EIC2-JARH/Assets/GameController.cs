using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Terrain;
    public GameObject Player;
    public Camera Camera;

    private const int Speed = 2;

    private Cenarios cenarioSelecionado;

    public Cenarios CenarioSelecionado
    {
        get { return cenarioSelecionado; }
        set
        {
            cenarioSelecionado = value;
            AlterarCenario();
        }
    }

    // Use this for initialization
    void Start()
    {
        //cenarioSelecionado = Cenarios.Deserto;//altera so o valor do cs
        //CenarioSelecionado = Cenarios.Deserto;//altera sc e corre AlterarCenario()
        //Player = Instantiate(Player, Player.transform.position, Player.transform.rotation);
        Terrain = Instantiate(Terrain, Terrain.transform.position, Terrain.transform.rotation);
        Terrain = Instantiate(Terrain, new Vector3(Terrain.transform.position.x + 10, Terrain.transform.position.y, Terrain.transform.position.z), Terrain.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    Player.transform.position.Set(Player.transform.position.x, Player.transform.position.y - Speed, Player.transform.position.z);
        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    Player.transform.position.Set(Player.transform.position.x, Player.transform.position.y + Speed, Player.transform.position.z);
        //
        //}
        //else if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    Player.transform.position.Set(Player.transform.position.x - Speed, Player.transform.position.y, Player.transform.position.z);
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    Player.transform.position.Set(Player.transform.position.x + Speed, Player.transform.position.y, Player.transform.position.z);
        //}
        //Camera.transform.position.Set(Player.transform.position.x, Player.transform.position.y, Camera.transform.position.z);
        //Terrain.transform.position.Set(Player.transform.position.x, Player.transform.position.y, Terrain.transform.position.z);
    }

    void AlterarCenario()
    {

    }

    public enum Cenarios
    {
        Deserto = 1,
        Floresta = 2,
        Gelado = 3,
        Noturno = 4
    }
}

