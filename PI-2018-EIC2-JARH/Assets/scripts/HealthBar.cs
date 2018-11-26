using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    private Transform helthbar;
    private TextMesh healthText;

	// Use this for initialization
	private void Start () {
        helthbar = transform.Find("Health");
        healthText = (TextMesh)transform.Find("Text").GetComponent(typeof(TextMesh));
    }
	
	public void SetSize(int life, int maxLife)
    {
        helthbar.localScale = new Vector3(((float)life / (float)maxLife), 1f);
        healthText.text = maxLife + "/" + life;
    }
}
