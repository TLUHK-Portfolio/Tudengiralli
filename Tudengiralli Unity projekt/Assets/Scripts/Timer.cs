using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float startTime;
    private bool timerActive;

    void Start()
    {
        startTime = Time.time;
        timerActive = true;
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }

    void Update()
    {
        if (timerActive)
        {
            float currentTime = Time.time - startTime;
            string minutes = ((int)currentTime / 60).ToString("00");
            string seconds = (currentTime % 60).ToString("00");
            string milliseconds = ((currentTime * 1000) % 1000).ToString("000");
            gameObject.GetComponent<TextMeshProUGUI>().text = minutes + ":" + seconds + "." + milliseconds;
        }
    }
}
