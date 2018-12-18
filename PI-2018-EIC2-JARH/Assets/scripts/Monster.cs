using MathNet.Numerics.Distributions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public HealthBar healthbar;
    public Score_Time score_time;

    private const float maxMonsterSpeed = 0.025f;
    private float monsterSpeed = maxMonsterSpeed;

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
            Vector3 newPosition = transform.position;
            newPosition.x -= monsterSpeed;
            transform.position = newPosition;
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            monsterSpeed = 0;
        }
        else
        {
            monsterSpeed = maxMonsterSpeed;
        }

        if (collision.collider.tag == "Magic")
        {
            Destroy(collision.gameObject);

            AnimatorStateInfo monsterName = gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

            int armor = 0;
            if (monsterName.IsName("Deserto0") || monsterName.IsName("Floresta0") || monsterName.IsName("Noturno0") || monsterName.IsName("Gelado0"))
                armor = 25;
            else if (monsterName.IsName("Deserto1") || monsterName.IsName("Floresta1") || monsterName.IsName("Noturno1") || monsterName.IsName("Gelado1"))
                armor = 50;
            else if (monsterName.IsName("Deserto2") || monsterName.IsName("Floresta2") || monsterName.IsName("Noturno2") || monsterName.IsName("Gelado2"))
                armor = 75;
            else if (monsterName.IsName("Deserto3") || monsterName.IsName("Floresta3") || monsterName.IsName("Noturno3") || monsterName.IsName("Gelado3"))
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
