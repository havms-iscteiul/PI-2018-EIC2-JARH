using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject player;
    private const float Speed = 0.01f;
    private static int layer = 1; 
 

    public Animator anim;


    public int life = 100; 

    // Use this for initialization
    void Start () {
        
        player = Instantiate(player, new Vector3(0, 0, layer), player.transform.rotation); //instanciar o player
        player.transform.localScale = new Vector3(0.5f, 0.5f, 1); //nao sei bem o que faz, cenas do hugo
        Camera.main.orthographicSize = 1; //para ter a camara centrada
        
        anim= player.GetComponent<Animator>();
       
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 newPosition = player.transform.position;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition.x -= Speed;
            anim.Play("move");
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            newPosition.x += Speed;
            anim.Play("move");
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey("x"))
        {
            atack();
            anim.Play("atack");
        }
        
     
        player.transform.position = newPosition;
        Vector3 newCameraPosition = Camera.main.transform.position;
        newCameraPosition.x = newPosition.x;
        newCameraPosition.y = newPosition.y;
        Camera.main.transform.position = newCameraPosition;
    }



    public void atack()
    {
        //bicho vai atacar
    }
}
