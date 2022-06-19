using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerClock : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    private bool isStopTime = false;

    // Start is called before the first frame update

    void Setup() {
        startTime = Time.time;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isStopTime) return;
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        timerText.text = minutes + ":" + seconds;
        //Debug.Log(minutes + ":" + seconds);
    }

    public void OnClose() {
        gameObject.SetActive(false);
    }

    public void OnOpen()
    {
        gameObject.SetActive(true);
        Setup();
    }

    public void StopTime() {
        isStopTime = true;
    }
}
