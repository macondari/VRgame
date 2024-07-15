using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FinalTimeDisplay : MonoBehaviour
{
    public TMP_Text timeDisplayText;             // Reference to UI Text element
    public StopWatch stopwatchScript;  // Reference to StopwatchController script
    public GameObject objectToActivate; // Reference to the GameObject to activate/deactivate
    public PlayerController playerControllerScript;
    public StopWatch stopWatchScript;

    private void Start()
    {
        
        objectToActivate.SetActive(false);
        timeDisplayText.gameObject.SetActive(false);

    }
    private void Update()
    {
        if (playerControllerScript.transform.position.x > 38 && playerControllerScript.transform.position.x < 42)
        {
            HalfWay();
            Debug.Log("half");
        }
        
    }
    public void HalfWay() // displays halfway message
    {
        ActivateObject();
        timeDisplayText.text = "you are half way!";
        Debug.Log("enter half");

        // Start coroutine to deactivate canvas and text after 5 seconds
        StartCoroutine(DeactivateAfterDelay(5f));
    }
    IEnumerator DeactivateAfterDelay(float delayInSeconds)
    {
        // Wait for the specified delay before proceeding
        yield return new WaitForSeconds(delayInSeconds);

        // Deactivate the canvas and text
        DeactivateObject();
    }
    public void DisplayTime()
    {
        // Get elapsed time from stopwatch controller
        float elapsedTime = stopwatchScript.GetElapsedTime();

        // Format time (you can customize this as needed)
        string formattedTime = FormatTime(elapsedTime);

        // Display time on UI Text
        timeDisplayText.text = "your play time is: " + formattedTime;

        // Show the canvas
        ActivateObject();

        // show text
    }
    public void ActivateObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true); // Activate the GameObject, in this case the canvas
            timeDisplayText.gameObject.SetActive(true); //activate text
        }
    }
    public void DeactivateObject ()
    {
        objectToActivate.SetActive(false); // Activate the GameObject, in this case the canvas
        timeDisplayText.gameObject.SetActive(false); //activate text
    }
    public string FormatTime(float timeInSeconds)
    {
        // Format time here (e.g., minutes and seconds)
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        float milliseconds = (timeInSeconds * 1000) % 1000;
        string formattedTime = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        return formattedTime;
    }
}
