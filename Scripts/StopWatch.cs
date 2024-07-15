using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StopWatch : MonoBehaviour
{
    public TMP_Text stopwatchText;  // Reference to the UI Text component where time will be displayed

    public float elapsedTime = 0f;
    public bool isRunning = false;

    void Start()
    {
        // Initialize the stopwatch
        UpdateStopwatchText();
    }

    void Update()
    {
        if (isRunning)
        {
            // Update the elapsed time
            elapsedTime += Time.deltaTime;
            UpdateStopwatchText();
        }
    }

    void UpdateStopwatchText()
    {
        // Format the elapsed time into minutes, seconds, and milliseconds
        float minutes = Mathf.FloorToInt(elapsedTime / 60);
        float seconds = Mathf.FloorToInt(elapsedTime % 60);
        float milliseconds = (elapsedTime * 1000) % 1000;

        // Update the Text component with the formatted time
        stopwatchText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    public void StartStopwatch()
    {
        // Start or resume the stopwatch
        isRunning = true;
    }
    public void StopStopwatch()
    {
        // Stop the stopwatch
        isRunning = false;
    }
    public void ResetStopwatch()
    {
        // Reset the stopwatch
        elapsedTime = 0f;
        UpdateStopwatchText();
    }
    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}
