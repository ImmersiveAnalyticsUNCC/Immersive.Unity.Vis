using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class Scoring : MonoBehaviour
{
    public GameObject pickups;
    public float timeremaining;
    public Text counttext;
    public Text WinText;
    public Text Timer;
    int total;

    //sets max point total
     void Start()
    {
       
        total = pickups.transform.childCount;
       
        WinText.text = "";
    
    }
    //adjust score based on how many pickups the player has collected
    //Countdown timer decrements in accordance to real time based on timer remaining set
    //displays win/lose text based on if the player collected all points in the time limit
    void Update()
    {
        int score = total - pickups.transform.childCount;
        counttext.text = score.ToString();
        if (score == total)
        {
            WinText.text = "You Win!";
            Time.timeScale = 0;
        }


        if (timeremaining > 1)
        {
            timeremaining -= Time.deltaTime;
            float seconds = Mathf.FloorToInt(timeremaining % 60);
            Timer.text = "Timer:" + seconds.ToString();
        }
        else
        {
            WinText.text = "You Lose!";
            Time.timeScale = 0;
        }
    }
    
}
