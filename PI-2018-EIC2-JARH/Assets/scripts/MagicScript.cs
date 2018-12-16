using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicScript : MonoBehaviour
{
    public float speedX = 0.5f;
    public float speedY = 0f;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speedX, speedY);
        Destroy(gameObject, 3f);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "monster")
        {
            Destroy(gameObject);
        }
    }
}
