using MathNet.Numerics.Distributions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject player;
    public GameObject monster;
    public GameObject background;



    private const float Speed = 0.01f;
    private static int layer = 1;

    [SerializeField] private HealthBar healthBar;

    public Animator anim;

    private const int maxLife = 100;
    public int Life
    {
        get
        {
            return life;
        }
        set
        {
            if (value >= 0 && value <= 100)
            {
                life = value;
                healthBar.SetSize(life, maxLife);
            }
        }
    }
    private int life; 

    // Use this for initialization
    private void Start () {
        player = Instantiate(player, new Vector3(0, 1, layer), player.transform.rotation); //instanciar o player
        player.transform.localScale = new Vector3(0.5f, 0.5f, 1); //nao sei bem o que faz, cenas do hugo
        Camera.main.orthographicSize = 1; //para ter a camara centrada
        
        anim= player.GetComponent<Animator>();

        //cenas da vida ;)
        Life = maxLife;

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
            Life += 1;
        }
        else if (Input.GetKey("z"))
        {
            Life -= 1;
           // anim.Play("jump");
            
        }
        
        player.transform.position = newPosition;
        Vector3 newCameraPosition = Camera.main.transform.position;
        newCameraPosition.x = newPosition.x;
        newCameraPosition.y = newPosition.y;
        Camera.main.transform.position = newCameraPosition;
        
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 1));
        Vector3 newHealthBarPosition = healthBar.transform.position;
        newHealthBarPosition.x = worldPos.x + healthBar.transform.localScale.x + 0.1f;
        newHealthBarPosition.y = worldPos.y - healthBar.transform.localScale.y + 0.1f;
        healthBar.transform.position = newHealthBarPosition;

        //generate monstro
       

    }



    public void atack()
    {
        //bicho vai atacar
    }


    //  player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
    double cosine(double xMin, double xMax)
    {
        double a = 0.5 * (xMin + xMax); // location parameter
        double b = (xMax - xMin) / Math.PI; // scale parameter
        return a + b * Math.Asin(ContinuousUniform.Sample(-1, 1));
    }
}
