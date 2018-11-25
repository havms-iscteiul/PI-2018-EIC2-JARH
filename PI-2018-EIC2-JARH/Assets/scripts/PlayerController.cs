using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject player;
    private const float Speed = 0.01f;
    private static int layer = 1; 
    public Sprite right; 
    public Sprite left;

    public int life = 100; 

    public SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        
        player = Instantiate(player, new Vector3(0, 0, layer), player.transform.rotation); //instanciar o player
        player.transform.localScale = new Vector3(0.5f, 0.5f, 1); //nao sei bem o que faz, cenas do hugo
        Camera.main.orthographicSize = 1; //para ter a camara centrada

        spriteRenderer = player.AddComponent<SpriteRenderer>();
        //sprites
        //spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = right; // meter o bicho virado para a esquerda
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 newPosition = player.transform.position;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition.x -= Speed;
            spriteRenderer.sprite = left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            newPosition.x += Speed;
            spriteRenderer.sprite = right;
        }
        player.transform.position = newPosition;
        Vector3 newCameraPosition = Camera.main.transform.position;
        newCameraPosition.x = newPosition.x;
        newCameraPosition.y = newPosition.y;
        Camera.main.transform.position = newCameraPosition;
    }
}
