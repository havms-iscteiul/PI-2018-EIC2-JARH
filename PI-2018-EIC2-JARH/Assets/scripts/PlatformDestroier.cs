using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroier : MonoBehaviour {


    public GameObject platformDestroctionPoint;

	// Use this for initialization
	void Start () {
        platformDestroctionPoint = GameObject.Find("PlatformDestructionPoint");
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < platformDestroctionPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
	}
}
