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

    
    //public bool check = false;
    public bool check1 = false;

    // Use this for initialization
    void Start () {
        scoret.GetComponent<TextMeshPro>();
        Timet.GetComponent<TextMeshPro>();
	}
	
	// Update is called once per frame
	void Update () {
        scoret.text = "Score:" + score;
        if (check1 == false)
        {
            StartCoroutine(Time_delay());
            int min = Mathf.FloorToInt(time / 60);
            int sec = Mathf.FloorToInt(time % 60);
            Timet.text = "Time:" + min.ToString("00") + ":" + sec.ToString("00");
        }
    }

    IEnumerator Time_delay()
    {
        check1 = true;
        time = time + 1;
        yield return new WaitForSeconds(1F);
        check1 = false;
    }

    public void addScore(int points)
    {
        this.score = score + points;
    }

    public void updateHighscores()
    {
        if(time > recordTime && score > highscore)
        {
            recordTime = time;
            highscore = score;
            PlayerPrefs.SetInt("HighScore", highscore);
            PlayerPrefs.SetFloat("RecordTime", recordTime);
        }
    }
}
