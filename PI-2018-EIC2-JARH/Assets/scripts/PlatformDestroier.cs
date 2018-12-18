using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroier : MonoBehaviour {


    public GameObject platformDestroctionPoint;
    private float maxDist;
    private bool playerLeft = false;

	// Use this for initialization
	void Start () {
        platformDestroctionPoint = GameObject.Find("PlatformDestructionPoint");
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < platformDestroctionPoint.transform.position.x)
        {
            if (playerLeft == false)
            {
                maxDist = platformDestroctionPoint.transform.position.x;
                playerLeft = true;
            }
            Destroy(gameObject);
        }
	}

    public bool getLeft()
    {
        return playerLeft;
    }

    public float getMax()
    {
        return maxDist;
    }
}
