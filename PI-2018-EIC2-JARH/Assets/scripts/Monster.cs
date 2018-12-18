using MathNet.Numerics.Distributions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public HealthBar healthbar;
    public Score_Time score_time;

    // Use this for initialization
    void Start () {
        healthbar = Instantiate(healthbar, transform.position, transform.rotation);
        healthbar.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.active)
        {
            healthbar.gameObject.SetActive(true);
            healthbar.transform.position = new Vector3(transform.position.x, (transform.position.y + 0.5f), transform.position.z);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Magic")
        {
            Destroy(collision.gameObject);

            int armor = 0;
            if (GetComponent<SpriteRenderer>().sprite.name.Contains("0"))
                armor = 25;
            else if (GetComponent<SpriteRenderer>().sprite.name.Contains("0"))
                armor = 50;
            else if (GetComponent<SpriteRenderer>().sprite.name.Contains("0"))
                armor = 75;
            else if (GetComponent<SpriteRenderer>().sprite.name.Contains("0"))
                armor = 100;

            int min_attack = 1;
            int max_attack = 100;
            int mode = (max_attack - armor <= min_attack ? min_attack : max_attack - armor);
            int damage = (int)Triangular.Sample(min_attack, max_attack, mode);

            healthbar.SetLife(healthbar.getLife() - damage);

            if (healthbar.getLife() == 0)
            {
                gameObject.SetActive(false);
                healthbar.SetLife(healthbar.getMaxLife());
                healthbar.gameObject.SetActive(false);
                score_time.addScore(armor);
            }
        }
    }
}
