using MathNet.Numerics.Distributions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public HealthBar healthbar;
    private const float Speed = 0.05f;
    private Animator anim;

    public GameObject magicL;
    public GameObject magicR;
    public Vector2 magicPos;
    public float magicRate = 0.5f;
    public float nextMagic = 0.0f;

    private const double timeLoseLife = 5;
    private double loseLife = timeLoseLife;

    // Use this for initialization
    void Start () {
        Camera.main.orthographicSize = 2; //para ter a camara centrada

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        loseLife -= Time.deltaTime;
        if (loseLife <= 0)
        {
            int newLife = healthbar.getLife() - (int)logarithmic(1, 5);
            healthbar.SetLife(newLife);
            loseLife = timeLoseLife;
        }

        if (healthbar.getLife() == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //score_time.updateHighscores();
        }
        Vector3 newPosition = transform.position;
        /*if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition.x -= Speed;
            anim.Play("move");
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else*/
        if (Input.GetKey(KeyCode.RightArrow))
        {
            newPosition.x += Speed;
            anim.Play("move");
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey(KeyCode.X) && Time.time > nextMagic)
        {
            nextMagic = Time.time + magicRate;
            atack();
            anim.Play("atack");
        }
        //else if (Input.GetKey(KeyCode.Space))
        //{
        //    anim.Play("jump");
        //}

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
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Item")
        {
            int newLife = healthbar.getLife();

            collision.gameObject.SetActive(false);

            string spriteName = collision.gameObject.GetComponent<SpriteRenderer>().sprite.ToString();
            Debug.Log(collision.gameObject.GetComponent<SpriteRenderer>().sprite.ToString());

            if (spriteName.Contains("potion"))  
                newLife += 10;
            else if (spriteName.Contains("pill"))
                newLife += 15;
            else if (spriteName.Contains("medicine"))
                newLife += 20;
            else if (spriteName.Contains("backpack"))
                newLife += 30;

            healthbar.SetLife(newLife);
        }
        else if (collision.collider.tag == "monster")
        {
            int newLife = healthbar.getLife();

            string spriteName = collision.gameObject.GetComponent<SpriteRenderer>().sprite.ToString();
            Debug.Log(collision.gameObject.GetComponent<SpriteRenderer>().sprite.ToString());

            if (spriteName.Contains("monstro0"))
                newLife -= 1;
            else if (spriteName.Contains("monstro1"))
                newLife -= 2;
            else if (spriteName.Contains("monstro2"))
                newLife -= 3;
            else if (spriteName.Contains("monstro3"))
                newLife -= 4;
            
            healthbar.SetLife(newLife);
        }
    }

    private double logarithmic(double xMin, double xMax)
    {
        double a = 0.5 * (xMin + xMax); // location parameter
        double b = xMax - xMin; // scale parameter 
        return a + b * ContinuousUniform.Sample(0, 1) * ContinuousUniform.Sample(0, 1);
    }
}
