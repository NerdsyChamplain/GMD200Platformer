using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public TextMeshProUGUI timeDisp;
    public TimeHolder timeHolder;
    private int minutes, seconds;
    void Start()
    {
        minutes = timeHolder.timeElapsed / 60;
        seconds = timeHolder.timeElapsed - minutes * 60;
        timeDisp.text = "Total time elapsed: " + minutes.ToString() + ":" + seconds.ToString();
        if(seconds < 10)
        {
            timeDisp.text = "Total time elapsed: " + minutes.ToString() + ":0" + seconds.ToString();
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
