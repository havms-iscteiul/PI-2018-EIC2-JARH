using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
    public GameObject platform;
    public Transform generationPoint;
    public float distanceBetwen;
    private float platformWith;
    

	// Use this for initialization
	void Start () {
        platformWith = platform.GetComponent<BoxCollider2D>().size.x;	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWith + distanceBetwen, transform.position.y, transform.position.z);
            platform = Instantiate(platform, transform.position, transform.rotation);
        }

	}
}