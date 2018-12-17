using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour {
    public HealthBar healthbar;
     private const float Speed = 0.05f;
   private Animator anim;
    private static int layer = 1;
    public Score_Time score_time;

    public GameObject magicL;
    public GameObject magicR;
    public Vector2 magicPos;
    public float magicRate = 0.5f;
    public float nextMagic = 0.0f;


    // Use this for initialization
    void Start () {
        //player = Instantiate(player, new Vector3(0, 1, layer), player.transform.rotation); //instanciar o player
       // player.transform.localScale = new Vector3(0.5f, 0.5f, 1); //nao sei bem o que faz, cenas do hugo
        Camera.main.orthographicSize = 2; //para ter a camara centrada

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if(healthbar.getLife() == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            score_time.updateHighscores();
        }
        Vector3 newPosition = transform.position;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition.x -= Speed;
            anim.Play("move");
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            newPosition.x += Speed;
            anim.Play("move");
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey("x") && Time.time > nextMagic)
        {
            nextMagic = Time.time + magicRate;
            atack();
            anim.Play("atack");
           // Life += 1;
        }
        else if (Input.GetKey("z"))
        {
            //Life -= 1;
            anim.Play("jump");

        }

        transform.position = newPosition;
        Vector3 newCameraPosition = Camera.main.transform.position;
        newCameraPosition.x = newPosition.x;
        newCameraPosition.y = newPosition.y;
        Camera.main.transform.position = newCameraPosition;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 1));
        Vector3 newHealthBarPosition = healthbar.transform.position;
        newHealthBarPosition.x = worldPos.x + healthbar.transform.localScale.x + 0.1f;
        newHealthBarPosition.y = worldPos.y - healthbar.transform.localScale.y + 0.1f;
        healthbar.transform.position = newHealthBarPosition;

    }


    public void atack()
    {
        magicPos = transform.position;
        if (GetComponent<SpriteRenderer>().flipX)
        {
            magicPos += new Vector2(+0.45f, -0.2f);
            Instantiate(magicR, magicPos, Quaternion.identity);
        }
        else
        {
            magicPos += new Vector2(-0.45f, -0.2f);
            Instantiate(magicL, magicPos, Quaternion.identity);
        }
        //bicho vai atacar
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Item")
        {
            int life = healthbar.getLife();
            int maxLife = healthbar.getMaxLife();
            int newLife;
            collision.gameObject.SetActive(false);
            Debug.Log(collision.gameObject.GetComponent<SpriteRenderer>().sprite.ToString());
            if (collision.gameObject.GetComponent<SpriteRenderer>().sprite.ToString().Contains("potion"))
            {
                
                newLife = life + 10;
                if (newLife < maxLife)
                {
                    healthbar.SetSize(newLife, maxLife);
                }
            }
            if (collision.gameObject.GetComponent<SpriteRenderer>().sprite.ToString().Contains("pill"))
            {
                newLife = life + 15;
                if (newLife < maxLife)
                {
                    healthbar.SetSize(newLife, maxLife);
                }
            }
            if (collision.gameObject.GetComponent<SpriteRenderer>().sprite.ToString().Contains("medicine"))
            {
                newLife = life + 20;
                if (newLife < maxLife)
                {
                    healthbar.SetSize(newLife, maxLife);
                }
            }
            if (collision.gameObject.GetComponent<SpriteRenderer>().sprite.ToString().Contains("backpack"))
            {
                newLife = life + 30;
                if (newLife < maxLife)
                {
                    healthbar.SetSize(newLife, maxLife);
                }
            }

        }
        if (collision.collider.tag == "monster")
        {
            int newLife = healthbar.getLife() -10;
            healthbar.SetSize(newLife, 100);
        }


    }
}
