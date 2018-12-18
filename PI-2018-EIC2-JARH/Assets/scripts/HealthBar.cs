using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    private Transform helthbar;
    private TextMesh healthText;
    private int life=100;
    private int maxLife=100;
    

	// Use this for initialization
	private void Start () {
        helthbar = transform.Find("Health");
        healthText = (TextMesh)transform.Find("Text").GetComponent(typeof(TextMesh));
        if(this.gameObject.active)
            SetLife(life);
    }
	
	public void SetLife(int life)
    {
        if (life > maxLife)
            life = maxLife;
        else if (life < 0)
            life = 0;

        helthbar.localScale = new Vector3(((float)life / (float)maxLife), 1f);
        healthText.text = maxLife + "/" + life;
        this.life = life;
    }

    public int getLife()
    {
        return life;
    }

    public int getMaxLife()
    {
        return maxLife;
    }

    public void setMaxLife(int maxLife)
    {
        this.maxLife = maxLife;
    }
}
