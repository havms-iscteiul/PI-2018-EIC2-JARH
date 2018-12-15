using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    private Transform helthbar;
    private TextMesh healthText;
    private int life=30;
    private int maxLife=100;
    

	// Use this for initialization
	private void Start () {
        helthbar = transform.Find("Health");
        healthText = (TextMesh)transform.Find("Text").GetComponent(typeof(TextMesh));
        SetSize(life ,maxLife);
    }
	
	public void SetSize(int life, int maxLife)
    {
        helthbar.localScale = new Vector3(((float)life / (float)maxLife), 1f);
        healthText.text = maxLife + "/" + life;
        this.life = life;
        this.maxLife = maxLife;
    }

    public int getLife()
    {
        return life;
    }

    public int getMaxLife()
    {
        return maxLife;
    }
}
