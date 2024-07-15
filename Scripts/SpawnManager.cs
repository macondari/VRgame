using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnObject;
    private Vector3 spawnPosition = new Vector3(21, 0, 0);
    public float startDelay = 2;
    public float repeatRate = 2;
    private PlayerController playerControllerScript;
    private bool canStartSpawning = false;
    // Start is called before the first frame update
    void Start()
    { 
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //StartSpawning(); // starts spawning w/out click (delete on VR)
    }

    public void StartSpawning()
    {
        if (!canStartSpawning && !(playerControllerScript.isRotate))
        {
            canStartSpawning = true;
            InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        }
    }
    public void UpdateRepeatRate(float newRepeatRate, float startDelay)
    {
        // Cancel existing InvokeRepeating and start new one with updated repeatRate
        CancelInvoke("SpawnObstacle");
        InvokeRepeating("SpawnObstacle", startDelay, newRepeatRate);
    }
    void SpawnObstacle ()
    {
        if (canStartSpawning && !(playerControllerScript.isRotate))
        {
            spawnPosition += new Vector3(5, 0, 0);
            if (!playerControllerScript.gameOver)
            {
                Instantiate(spawnObject, spawnPosition, spawnObject.transform.rotation);
            }
        }
        if (canStartSpawning && (playerControllerScript.isRotate))
        {
            spawnPosition = playerControllerScript.transform.position;
            spawnPosition -= new Vector3(20, 0, 0);
            if (!playerControllerScript.gameOver)
            {
                Instantiate(spawnObject, spawnPosition, spawnObject.transform.rotation);
            }
        }
    }
}
