using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {
    public HealthBar healthbar;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
            if (collision.gameObject.GetComponent<SpriteRenderer>().sprite.ToString() == "pill")
            {
                newLife = life + 15;
                if (newLife < maxLife)
                {
                    healthbar.SetSize(newLife, maxLife);
                }
            }
            if (collision.gameObject.GetComponent<SpriteRenderer>().sprite.ToString() == "medicine")
            {
                newLife = life + 20;
                if (newLife < maxLife)
                {
                    healthbar.SetSize(newLife, maxLife);
                }
            }
            if (collision.gameObject.GetComponent<SpriteRenderer>().sprite.ToString() == "backpack")
            {
                newLife = life + 30;
                if (newLife < maxLife)
                {
                    healthbar.SetSize(newLife, maxLife);
                }
            }

        }
       
    }
}
