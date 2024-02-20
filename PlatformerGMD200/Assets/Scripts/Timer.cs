using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TimeHolder timeHolder;
    public TextMeshProUGUI timeDisp;
    private int minutes, seconds;
    private bool canAdd = true;
    void Start()
    {
        minutes = 0;
        seconds = 0;
        canAdd = true;
    }
    // Update is called once per frame
    void Update()
    {
        minutes = timeHolder.timeElapsed / 60;
        seconds = timeHolder.timeElapsed - minutes * 60;
        if(seconds > 10)
        {
            timeDisp.text = minutes.ToString() + ":" + seconds.ToString();
        }
        else
        {
            timeDisp.text = minutes.ToString() + ":0" + seconds.ToString();
        }
        
        if (canAdd )
        {
            StartCoroutine(TimeAdd(1.0f));
            canAdd = false;
        }
        
    }
    private IEnumerator TimeAdd(float delay)
    {
        yield return new WaitForSeconds(delay);
        timeHolder.timeElapsed += 1;
        canAdd = true;
    }
}
