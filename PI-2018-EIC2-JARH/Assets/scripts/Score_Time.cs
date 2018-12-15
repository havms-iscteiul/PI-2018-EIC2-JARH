using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score_Time : MonoBehaviour {

    int score = 0;
    public float time = 0.0f;
   

    public TextMeshProUGUI scoret;
    public TextMeshProUGUI Timet;
    private int highscore;
    private float recordTime;
    

    public bool check = false;
    public bool check1 = false;

    // Use this for initialization
    void Start () {
        scoret.GetComponent<TextMeshPro>();
        Timet.GetComponent<TextMeshPro>();
	}
	
	// Update is called once per frame
	void Update () {
        if (check == false)
        {
            StartCoroutine(Score_delay());
            scoret.text = "Score:" + score;

        }
        if (check1 == false)
        {
            StartCoroutine(Time_delay());
            int min = Mathf.FloorToInt(time / 60);
            int sec = Mathf.FloorToInt(time % 60);
            Timet.text = min.ToString("00") + ":" + sec.ToString("00");
            //Timet.text = "Time:" + time;

        }
    }


    IEnumerator Score_delay()
    {
        check = true;
        score = score + 1;
        yield return new WaitForSeconds(0.5F);
        check = false;
    }

    IEnumerator Time_delay()
    {
        check1 = true;
        time = time + 1;
        yield return new WaitForSeconds(1F);
        check1 = false;
    }

    public void updateHighscores()
    {
        if(time >recordTime)
        {
            recordTime = time;
            highscore = score;
            PlayerPrefs.SetInt("HighScore", highscore);
            PlayerPrefs.SetFloat("RecordTime", recordTime);
        }
    }
}
