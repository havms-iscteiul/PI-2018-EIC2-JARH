using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public SpriteRenderer Terrain;
    public GameObject Player;

    private const float Speed = 0.01f;
    private const int initialCoordenate = 0;

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
        float TerrainWidth = Terrain.size.x;
        float TerrainHeight = Terrain.size.y;
        float initialCoordenateTerrainWidth = TerrainWidth / 2;
        float initialCoordenateTerrainHeight = TerrainHeight / 2;

        //cenarioSelecionado = Cenarios.Deserto;//altera so o valor do cs
        //CenarioSelecionado = Cenarios.Deserto;//altera sc e corre AlterarCenario()
        Player = Instantiate(Player, new Vector3(0, 0, Terrain.transform.position.z), Player.transform.rotation);
        Player.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        Camera.main.orthographicSize = 1;
        Terrain = Instantiate(Terrain, new Vector3(initialCoordenateTerrainWidth, initialCoordenateTerrainHeight, Terrain.transform.position.z), Terrain.transform.rotation);
        Terrain = Instantiate(Terrain, new Vector3(initialCoordenateTerrainWidth - TerrainWidth, initialCoordenateTerrainHeight, Terrain.transform.position.z), Terrain.transform.rotation);
        Terrain = Instantiate(Terrain, new Vector3(initialCoordenateTerrainWidth, initialCoordenateTerrainHeight - TerrainHeight, Terrain.transform.position.z), Terrain.transform.rotation);
        Terrain = Instantiate(Terrain, new Vector3(initialCoordenateTerrainWidth - TerrainWidth, initialCoordenateTerrainHeight - TerrainHeight, Terrain.transform.position.z), Terrain.transform.rotation);

        Terrain = Instantiate(Terrain, new Vector3(initialCoordenateTerrainWidth + TerrainWidth, initialCoordenateTerrainHeight, Terrain.transform.position.z), Terrain.transform.rotation);
        Terrain = Instantiate(Terrain, new Vector3(initialCoordenateTerrainWidth - TerrainWidth * 2, initialCoordenateTerrainHeight, Terrain.transform.position.z), Terrain.transform.rotation);
        Terrain = Instantiate(Terrain, new Vector3(initialCoordenateTerrainWidth + TerrainWidth, initialCoordenateTerrainHeight - TerrainHeight, Terrain.transform.position.z), Terrain.transform.rotation);
        Terrain = Instantiate(Terrain, new Vector3(initialCoordenateTerrainWidth - TerrainWidth * 2, initialCoordenateTerrainHeight - TerrainHeight, Terrain.transform.position.z), Terrain.transform.rotation);


        Terrain = Instantiate(Terrain, new Vector3(initialCoordenateTerrainWidth + TerrainWidth * 2, initialCoordenateTerrainHeight, Terrain.transform.position.z), Terrain.transform.rotation);
        Terrain = Instantiate(Terrain, new Vector3(initialCoordenateTerrainWidth - TerrainWidth * 3, initialCoordenateTerrainHeight, Terrain.transform.position.z), Terrain.transform.rotation);
        Terrain = Instantiate(Terrain, new Vector3(initialCoordenateTerrainWidth + TerrainWidth * 2, initialCoordenateTerrainHeight - TerrainHeight, Terrain.transform.position.z), Terrain.transform.rotation);
        Terrain = Instantiate(Terrain, new Vector3(initialCoordenateTerrainWidth - TerrainWidth * 3, initialCoordenateTerrainHeight - TerrainHeight, Terrain.transform.position.z), Terrain.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = Player.transform.position;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPosition.y += Speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            newPosition.y -= Speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition.x -= Speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            newPosition.x += Speed;
        }
        Player.transform.position = newPosition;
        Vector3 newCameraPosition = Camera.main.transform.position;
        newCameraPosition.x = newPosition.x;
        newCameraPosition.y = newPosition.y;
        Camera.main.transform.position = newCameraPosition;
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

