using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScript : MonoBehaviour {

    public TextMeshProUGUI scoret;
    public TextMeshProUGUI Timet;


    // Use this for initialization
    void Start()
    {
        scoret.GetComponent<TextMeshPro>();
        Timet.GetComponent<TextMeshPro>();
        scoret.text = "High Score:" + PlayerPrefs.GetInt("HighScore");
        float time = PlayerPrefs.GetFloat("RecordTime");
        int min = Mathf.FloorToInt(time / 60);
        int sec = Mathf.FloorToInt(time % 60);
        Timet.text ="Record Time:" + min.ToString("00") + ":" + sec.ToString("00");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


}
