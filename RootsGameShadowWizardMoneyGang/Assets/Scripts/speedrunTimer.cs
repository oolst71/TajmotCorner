using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class speedrunTimer : MonoBehaviour
{
    public static float currentRunTime;
    private static int seconds;
    private static int minutes;
    private static int thousandths;
    private String secText;
    private String minText;
    private String thText;
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
        currentRunTime = 0;
        seconds = 0;
        minutes = 0;
        thousandths = 0;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            minText = minutes.ToString();
            secText = seconds.ToString();
            thText = thousandths.ToString();
            if (minutes < 10)
            {
                minText = "0" + minText;
            }
            if (seconds < 10)
            {
                secText = "0" + secText;
            }
            if (thousandths < 100)
            {
                thText = "0" + thText;
                if (thousandths < 10)
                {
                    thText = "0" + thText;
                }
            }
            timerText.text = minText + ":" + secText + "." + thText;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 5)
        {
            currentRunTime += Time.deltaTime;
            seconds = (int)currentRunTime;
            //thousandths = (int)();
            thousandths = (int)((currentRunTime - Math.Truncate(currentRunTime)) * 1000);
            if (seconds >= 60)
            {
                minutes++;
                seconds = 0;
                currentRunTime = 0;
            }
            minText = minutes.ToString();
            secText = seconds.ToString();
            thText = thousandths.ToString();
            if (minutes < 10)
            {
                minText = "0" + minText;
            }
            if (seconds < 10)
            {
                secText = "0" + secText;
            }
            if (thousandths < 100)
            {
                thText = "0" + thText;
                if (thousandths < 10)
                {
                    thText = "0" + thText;
                }
            }
            timerText.text = minText + ":" + secText + "." + thText;
        }
        
    }
}
